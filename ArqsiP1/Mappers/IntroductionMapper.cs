using ArqsiP1.DataModels;
using ArqsiP1.DomainModels.Introduction;
using ArqsiP1.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArqsiP1.Mappers
{
    public class IntroductionMapper
    {
        public Introduction toDomain(IntroductionDto dto)
        {
            if (dto.introductionId == null)
                return new Introduction(dto.playerId, dto.itermediatePlayerId, dto.targetPlayerId, dto.message, dto.status);

            else
                return new Introduction(dto.introductionId, dto.playerId, dto.itermediatePlayerId, dto.targetPlayerId, dto.message, dto.status);

        }

        public IntroductionDto toDto(Introduction introduction)
        {
            if (introduction.introductionId == null)
                return new IntroductionDto(introduction.playerId, introduction.itermediatePlayerId, introduction.targetPlayerId, introduction.message.message, introduction.status.status.ToString());
            else
                return new IntroductionDto(introduction.introductionId, introduction.playerId, introduction.itermediatePlayerId, introduction.targetPlayerId, introduction.message.message, introduction.status.status.ToString());
        }

        public Introduction toDomain(IntroductionSchema schema)
        {
            if (schema.introductionId == null)
                return new Introduction(schema.playerId, schema.itermediatePlayerId, schema.targetPlayerId, schema.message, schema.status);
            else
                return new Introduction(schema.introductionId, schema.playerId, schema.itermediatePlayerId, schema.targetPlayerId, schema.message, schema.status);

        }

        public IntroductionSchema toSchema(Introduction introduction)
        {
            if (introduction.introductionId == null)
                return new IntroductionSchema(introduction.playerId, introduction.itermediatePlayerId, introduction.targetPlayerId, introduction.message.message, introduction.status.status.ToString());
            else
                return new IntroductionSchema(introduction.introductionId, introduction.playerId, introduction.itermediatePlayerId, introduction.targetPlayerId, introduction.message.message, introduction.status.status.ToString());

        }
    }
}


