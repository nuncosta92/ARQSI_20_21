using ArqsiP1.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArqsiP1.Repositories.Interfaces
{
    public interface ITagRepo
    {
        List<TagSchema> RetrieveAllTags();
        TagSchema RetrieveTag(int id);

        TagSchema UpdateTag(TagSchema schema);

        TagSchema CreateTag(TagSchema schema);

        List<TagSchema> FindTagsWithPlayerId(int playerId);
        List<TagSchema> FindTagsWithConnectionId(int connectionId);
        List<TagSchema> FindTagsWithPostId(int postId);

        List<TagSchema> RetrieveTagsByName(String tag);
        List<TagSchema> RetrieveTagsByPlayerId(int playerId); 
         List<TagSchema> RetrieveTagsConnectionId(int connectionId);
    }
}
