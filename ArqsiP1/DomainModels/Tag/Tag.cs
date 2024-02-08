using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArqsiP1.DomainModels.Tag
{
    public class Tag
    {
        public int? tagId;
        public int? playerId;
        public int? connectionId;
        public int? postId;
        public String tag;

        public Tag(int? playerId, int? connectionId, int? postId, String tag)
        {
            if((connectionId==null) && (postId == null))
                this.playerId = playerId;

            else if ((playerId == null) && (postId == null))
                this.connectionId = connectionId;

            else
                this.postId = postId;

            this.tag = tag;
        }

        public Tag(int? tagId, int? playerId, int? connectionId, int? postId, String tag)
        {
            this.tagId = tagId;

            if ((connectionId == null) && (postId == null))
                this.playerId = playerId;

            else if ((playerId == null) && (postId == null))
                this.connectionId = connectionId;

            else
                this.postId = postId;

            this.tag = tag;
        }
    }
}
