using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArqsiP1.Dto
{
    public class TagDto
    {
        public int? tagId { get; set; }
        public int? playerId { get; set; }
        public int? connectionId { get; set; }
        public int? postId { get; set; }
        public String tag { get; set; }


        public TagDto()
        {

        }

        public TagDto(int? playerId, int? connectionId, int? postId, String tag)
        {
            //   if ((connectionId == null) && (postId == null))
            this.playerId = playerId;

            //  else if ((playerId == null) && (connectionId == null))
            this.connectionId = connectionId;

            //  else
            this.postId = postId;

            this.tag = tag;
        }

        public TagDto(int? tagId, int? playerId, int? connectionId, int? postId, String tag)
        {
            this.tagId = tagId;
            //     if ((connectionId == null) && (postId == null))
            this.playerId = playerId;

            //    else if ((playerId == null) && (connectionId == null))
            this.connectionId = connectionId;

            //   else
            this.postId = postId;

            this.tag = tag;
        }
    }
}
