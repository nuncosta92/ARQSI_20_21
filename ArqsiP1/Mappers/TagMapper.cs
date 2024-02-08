using ArqsiP1.DataModels;
using ArqsiP1.DomainModels.Tag;
using ArqsiP1.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArqsiP1.Mappers
{
    public class TagMapper
    {
        public Tag toDomain(TagDto dto)
        {
            if (dto.tagId == null)
                return new Tag(dto.playerId, dto.connectionId, dto.postId, dto.tag);

            else
                return new Tag(dto.tagId, dto.playerId, dto.connectionId, dto.postId, dto.tag);

        }

        public TagDto toDto(Tag tag)
        {
            if (tag.tagId == null)
                return new TagDto(tag.playerId, tag.connectionId, tag.postId, tag.tag);
            else
                return new TagDto(tag.tagId, tag.playerId, tag.connectionId, tag.postId, tag.tag);
        }

        public Tag toDomain(TagSchema schema)
        {
            if (schema.tagId == null)
                return new Tag(schema.playerId, schema.connectionId, schema.postId, schema.tag);

            else
                return new Tag(schema.tagId, schema.playerId, schema.connectionId, schema.postId, schema.tag);

        }

        public TagSchema toSchema(Tag tag)
        {
            if (tag.tagId == null)
                return new TagSchema(tag.playerId, tag.connectionId, tag.postId, tag.tag);
            else
                return new TagSchema(tag.tagId, tag.playerId, tag.connectionId, tag.postId, tag.tag);
        }
    }
}
