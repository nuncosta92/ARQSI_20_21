using ArqsiP1.DataModels;
using ArqsiP1.DomainModels.Tag;
using ArqsiP1.Dto;
using ArqsiP1.Mappers;
using ArqsiP1.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArqsiP1.Services
{
    public class TagService
    {
        TagMapper _mapper;
        Tag _tag;
        ITagRepo _repo;

        public TagService(ITagRepo repo)
        {
            _mapper = new TagMapper();
            _repo = repo;
        }


        internal List<TagDto> GetAllTags()
        {
            List<TagDto> tagsToDto = new List<TagDto>();
            List<TagSchema> tagsFromSchema = _repo.RetrieveAllTags();

            tagsFromSchema.ForEach(
                tagSchema =>
                {
                    Tag tag = _mapper.toDomain(tagSchema);
                    tagsToDto.Add(_mapper.toDto(tag));
                });

            return tagsToDto;
        }

        public TagDto CreateTag(TagDto dto)
        {
            _tag = _mapper.toDomain(dto);

            //**Block to generate/change connection model**//
            TagSchema schema = _mapper.toSchema(_tag);
            
            schema = _repo.CreateTag(schema);
            _tag = _mapper.toDomain(schema);
            return _mapper.toDto(_tag);
        }

        
        internal List<Tag> getTagsWithPlayerId(int playerId)
        {
            List<TagSchema> schemaList = _repo.FindTagsWithPlayerId(playerId);
            List<Tag> tagList = new List<Tag>();

            schemaList.ForEach(
                tagSchema =>
                {
                    Tag tag = _mapper.toDomain(tagSchema);
                    tagList.Add(tag);
                });
            return tagList;
        }

        internal List<Tag> getTagsWithConnectionId(int connectionId)
        {
            List<TagSchema> schemaList = _repo.FindTagsWithConnectionId(connectionId);
            List<Tag> tagList = new List<Tag>();

            schemaList.ForEach(
                tagSchema =>
                {
                    Tag tag = _mapper.toDomain(tagSchema);
                    tagList.Add(tag);
                });
            return tagList;
        }

        internal List<Tag> getTagsWithPostId(int postId)
        {
            List<TagSchema> schemaList = _repo.FindTagsWithPostId(postId);
            List<Tag> tagList = new List<Tag>();

            schemaList.ForEach(
                tagSchema =>
                {
                    Tag tag = _mapper.toDomain(tagSchema);
                    tagList.Add(tag);
                });
            return tagList;
        }

        internal TagDto GetTagById(int id)
        {
            _tag = _mapper.toDomain(_repo.RetrieveTag(id));
            return _mapper.toDto(_tag);
        }



        public TagDto UpdateTag(TagDto dto)
        {
            _tag = _mapper.toDomain(dto);

            TagSchema schema = _mapper.toSchema(_tag);
            schema = _repo.UpdateTag(schema);
            _tag = _mapper.toDomain(schema);
            return _mapper.toDto(_tag);
        }

        internal List<TagDto> RetrieveTagsByName(String tag)
        {
            List<TagDto> tagToDto = new List<TagDto>();
            List<TagSchema> tagFromSchema = _repo.RetrieveTagsByName(tag);

            tagFromSchema.ForEach(
                tagSchema =>
                {
                    Tag tag = _mapper.toDomain(tagSchema);
                    tagToDto.Add(_mapper.toDto(tag));
                });

            return tagToDto;
        }

        internal List<TagDto> RetrieveTagsByConnectionId(int connectionId)
        {
            List<TagDto> tagToDto = new List<TagDto>();
            List<TagSchema> tagFromSchema = _repo.RetrieveTagsConnectionId(connectionId);

            tagFromSchema.ForEach(
                tagSchema =>
                {
                    Tag tag = _mapper.toDomain(tagSchema);
                    tagToDto.Add(_mapper.toDto(tag));
                });

            return tagToDto;
        }

        internal List<TagDto> RetrieveTagsByPlayerId(int playerId)
        {
            List<TagDto> tagToDto = new List<TagDto>();
            List<TagSchema> tagFromSchema = _repo.RetrieveTagsByPlayerId(playerId);

            tagFromSchema.ForEach(
                tagSchema =>
                {
                    Tag tag = _mapper.toDomain(tagSchema);
                    tagToDto.Add(_mapper.toDto(tag));
                });

            return tagToDto;
        }
    }
}
