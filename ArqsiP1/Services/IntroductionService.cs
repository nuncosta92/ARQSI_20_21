using ArqsiP1.DataModels;
using ArqsiP1.DomainModels.Introduction;
using ArqsiP1.DomainModels.Player;
using ArqsiP1.Dto;
using ArqsiP1.Mappers;
using ArqsiP1.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArqsiP1.Services
{


    public class IntroductionService
    {
        IntroductionMapper _mapper;
        Introduction _introduction;
        IIntroductionRepo _repo;
        IConnectionRepo _connectionRepo;
  
        public IntroductionService(IIntroductionRepo repo, IConnectionRepo connectionRepo)
        {
            _mapper = new IntroductionMapper();
            _repo = repo;
            _connectionRepo = connectionRepo;
        }

        public IntroductionService(IIntroductionRepo repo)
        {
            _mapper = new IntroductionMapper();
            _repo = repo;
        }

        internal List<IntroductionDto> GetAllIntroductions()
        {
            List<IntroductionDto> introductionToDto = new List<IntroductionDto>();
            List<IntroductionSchema> introductionFromSchema = _repo.RetrieveAllIntroductions();

            introductionFromSchema.ForEach(
                introductionSchema =>
                {
                    Introduction introduction = _mapper.toDomain(introductionSchema);
                    introductionToDto.Add(_mapper.toDto(introduction));
                });

            return introductionToDto;
        }

        internal IntroductionDto GetIntroductionById(int id)
        {
            _introduction = _mapper.toDomain(_repo.RetrieveIntroduction(id));
          return _mapper.toDto(_introduction);
        }

        public IntroductionDto CreateIntroduction(IntroductionDto dto)
        {
            _introduction = _mapper.toDomain(dto);

            //**Block to generate/change player model**//


            IntroductionSchema schema = _mapper.toSchema(_introduction);
            schema = _repo.CreateIntroduction(schema);
            _introduction = _mapper.toDomain(schema);
            return _mapper.toDto(_introduction);
        }

        public List<IntroductionDto>  GetIntroductionPendingByPlayerId(int playerid) {

            List<IntroductionDto> introductionToDto = new List<IntroductionDto>();
            List<IntroductionSchema> introductionFromSchema = _repo.RetrieveAllPendingIntroductions(playerid);

            introductionFromSchema.ForEach(
                introductionSchema =>
                {
                    Introduction introduction = _mapper.toDomain(introductionSchema);
                    introductionToDto.Add(_mapper.toDto(introduction));
                });

            return introductionToDto;
        }

        public IntroductionDto UpdateIntroduction(IntroductionDto dto)
        {
            _introduction = _mapper.toDomain(dto);

            IntroductionSchema schema = _mapper.toSchema(_introduction);
            schema = _repo.UpdateIntroduction(schema);
            _introduction = _mapper.toDomain(schema);
            return _mapper.toDto(_introduction);
        }

        public ConnectionDto acceptIntoduction(int playerId, int itermediatePlayerId, int targetPlayerId)
        {
            IntroductionSchema introSchema = _repo.getIntroduction(playerId, itermediatePlayerId, targetPlayerId);
            introSchema.status = "APPROVED";
            _repo.UpdateIntroduction(introSchema);
            _introduction = _mapper.toDomain(introSchema);
            ConnectionService connectionService = new ConnectionService(_connectionRepo);
            return connectionService.createRequestedConnection(_introduction);
        }

        public IntroductionDto rejectIntroduction(int playerId, int itermediatePlayerId, int targetPlayerId)
        {
            IntroductionSchema introSchema = _repo.getIntroduction(playerId, itermediatePlayerId, targetPlayerId);
            introSchema.status = "DISAPPROVED";
            return _mapper.toDto(_mapper.toDomain(_repo.UpdateIntroduction(introSchema)));
        }
    }
}
