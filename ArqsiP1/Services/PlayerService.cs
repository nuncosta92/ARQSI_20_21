using ArqsiP1.DataModels;
using ArqsiP1.DomainModels.Player;
using ArqsiP1.DomainModels.Player.ValueObjects;
using ArqsiP1.Dto;
using ArqsiP1.Mappers;
using ArqsiP1.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArqsiP1.Services
{


    public class PlayerService
    {
        PlayerMapper _mapper;
        Player _player;
        IPlayerRepo _repo;
        ITagRepo _repoTag;

        public PlayerService(IPlayerRepo repo)
        {
            _mapper = new PlayerMapper();
            _repo = repo;
        }

        

        public PlayerService(IPlayerRepo repo, ITagRepo repoTag)
        {
            _mapper = new PlayerMapper();
            _repo = repo;
            _repoTag = repoTag;
        }



        internal List<PlayerDto> GetAllPlayers()
        {
            List<PlayerDto> playersToDto = new List<PlayerDto>();
            List<PlayerSchema> playersFromSchema = _repo.RetrieveAllPlayers();

            playersFromSchema.ForEach(
                playerSchema =>
                {
                    Player player = _mapper.toDomain(playerSchema);
                    playersToDto.Add(_mapper.toDto(player));
                });

            return playersToDto;
        }

        internal List<PlayerDto> RetrievePlayersByName(String nome)
        {
            List<PlayerDto> playersToDto = new List<PlayerDto>();
            List<PlayerSchema> playersFromSchema = _repo.RetrievePlayersByName(nome);

            playersFromSchema.ForEach(
                playerSchema =>
                {
                    Player player = _mapper.toDomain(playerSchema);
                    playersToDto.Add(_mapper.toDto(player));
                });

            return playersToDto;
        }

        internal PlayerDto RetrievePlayerByEmail(string email)
        {
            _player = _mapper.toDomain(_repo.RetrievePlayerByEmail(email));
            return _mapper.toDto(_player);
        }

        internal PlayerDto GetPlayerById(int id)
        {
          _player = _mapper.toDomain(_repo.RetrievePlayer(id));
          return _mapper.toDto(_player);
        }

        public PlayerDto CreatePlayer(PlayerDto dto)
        {
            _player = _mapper.toDomain(dto);

            //**Block to generate/change player model**//
            if (!_player.email.email.Contains("@"))
                throw new ArgumentException("Email not valid", nameof(dto));
            if (!_player.email.email.Split("@")[1].Contains('.'))
                throw new ArgumentException("Email not valid", nameof(dto));

            if (!(_repo.RetrievePlayerByEmail(_player.email.email) == null)) 
            throw new ArgumentException("Email already exists", nameof(dto));
            
            PlayerSchema schema = _mapper.toSchema(_player);
            schema = _repo.CreatePlayer(schema);
            _player = _mapper.toDomain(schema);
            return _mapper.toDto(_player);
        }

        public PlayerDto UpdatePlayer(PlayerDto dto)
        {
            _player = _mapper.toDomain(dto);

            //**Block to generate/change player model**//
            if (!_player.email.email.Contains("@"))
                throw new ArgumentException("Email not valid", nameof(dto));
            if (!_player.email.email.Split("@")[1].Contains('.'))
                throw new ArgumentException("Email not valid", nameof(dto));

            PlayerSchema schema = _mapper.toSchema(_player);
            schema = _repo.UpdatePlayer(schema);
            _player = _mapper.toDomain(schema);
            return _mapper.toDto(_player);
        }

        internal PlayerDto UpdatePlayerHumor(PlayerDto dto)
        {

            PlayerSchema schema = _repo.RetrievePlayer(dto.playerId.GetValueOrDefault());
            _player = _mapper.toDomain(schema);
            _player.emotionalState = new EmotionalState (dto.emotionalState);

            //**Block to generate/change player model**//

            schema = _mapper.toSchema(_player);
            schema = _repo.UpdatePlayerHumor(schema);
            _player = _mapper.toDomain(schema);
            return _mapper.toDto(_player);
        }


        internal List<PlayerDto> GetAllPlayersSugested(int id)
        {

            int playerLogado = id; //temporario, depois tera um metodo para obter o id do player logado

            List<TagDto> tagToDto = new List<TagDto>();
            List<TagSchema> tagsPlayer = _repoTag.FindTagsWithPlayerId(playerLogado);
            List<TagSchema> tagsLikePlayer = new List<TagSchema>();

            List<PlayerSchema> playersFromSchema = new List<PlayerSchema>();
            List<PlayerDto> playersToDto = new List<PlayerDto>();

            foreach (TagSchema t in tagsPlayer)
            {
                tagsLikePlayer = _repoTag.RetrieveTagsByName(t.tag);
                foreach (TagSchema s in tagsLikePlayer)
                {
                    if (s.playerId == null) {
                        continue;
                    }

                    PlayerSchema playerSchema = _repo.RetrievePlayer(s.playerId.GetValueOrDefault());
                    if (!playerSchema.playerId.Equals(playerLogado))
                    { 
                        playersFromSchema.Add(playerSchema);
                    }
                }
            }


            playersFromSchema.ForEach(
                playerSchema =>
                {
                    Player player = _mapper.toDomain(playerSchema);
                    playersToDto.Add(_mapper.toDto(player));
                });

            return playersToDto;
        }
    }
}
