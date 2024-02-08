using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ArqsiP1.DataModels
{
    public class TagSchema
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int tagId { get; set; }

        [ForeignKey("Player")]
        public int? playerId { get; set; }
        [ForeignKey("Connection")]
        public int? connectionId { get; set; }

        public int? postId { get; set; }

        public String tag { get; set; }

        public TagSchema()
        {

        }
        public TagSchema(int? playerId, int? connectionId, int? postId, String tag)
        {
          //  if ((connectionId == null) && (postId == null))
                this.playerId = playerId;

        //    else if ((playerId == null) && (connectionId == null))
                this.connectionId = connectionId;

      //      else
                this.postId = postId;

            this.tag = tag;
        }

        public TagSchema(int? tagId, int? playerId, int? connectionId, int? postId, String tag)
        {
            this.tagId = tagId.GetValueOrDefault();
           // if ((connectionId == null) && (postId == null))
                this.playerId = playerId;

          //  else if ((playerId == null) && (connectionId == null))
                this.connectionId = connectionId;

         //   else
                this.postId = postId;

            this.tag = tag;
        }
    }
}
