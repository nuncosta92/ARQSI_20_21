using ArqsiP1.Contexts;
using ArqsiP1.DataModels;
using ArqsiP1.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArqsiP1.Repositories
{
    public class TagRepo : ITagRepo
    {
        private Context _db;

        public TagRepo(Context db)
        {
            _db = db;
        }

        TagSchema ITagRepo.CreateTag(TagSchema schema)
        {
            _db.Tag.Add(schema);
            _db.SaveChanges();
            return schema;
        }

        List<TagSchema> ITagRepo.RetrieveAllTags()
        {
            var allTags = _db.Tag;
            List<TagSchema> tagsList = new List<TagSchema>();
            foreach (var player in allTags)
            {
                tagsList.Add(player);
            }
            return tagsList;
        }

        TagSchema ITagRepo.RetrieveTag(int id)
        {
            return _db.Tag.Find(id);
        }

        List<TagSchema> ITagRepo.FindTagsWithPlayerId(int playerId)
        {
            return _db.Tag.Where(tag => tag.playerId == playerId).ToList<TagSchema>();
        }

        List<TagSchema> ITagRepo.FindTagsWithConnectionId(int connectionId)
        {
            return _db.Tag.Where(tag => tag.connectionId == connectionId).ToList<TagSchema>();
        }

        List<TagSchema> ITagRepo.FindTagsWithPostId(int postId)
        {
            return _db.Tag.Where(tag => tag.postId == postId).ToList<TagSchema>();
        }


        TagSchema ITagRepo.UpdateTag(TagSchema schema)
        {
            var tag = _db.Tag.Where(s => s.tagId == schema.tagId).FirstOrDefault<TagSchema>();

            tag.tag = schema.tag;
            _db.SaveChanges();
            return tag;
        }

        List<TagSchema> ITagRepo.RetrieveTagsByName(String tag)
        {
            return _db.Tag.Where(s => s.tag.ToLower() == tag.ToLower()).ToList<TagSchema>();
        }

        public List<TagSchema> RetrieveTagsByPlayerId(int playerId)
        {
            return _db.Tag.Where(s => s.playerId == playerId).ToList<TagSchema>();
        }

        public List<TagSchema> RetrieveTagsConnectionId(int connectionId)
        {
            return _db.Tag.Where(s => s.connectionId == connectionId).ToList<TagSchema>();
        }
    }
}
