using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ArqsiP1.DataModels
{
    public class IntroductionSchema
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int introductionId { get; set; }

        [ForeignKey("Player")]
        public int playerId { get; set; }
        [ForeignKey("Intermediate")]
        public int itermediatePlayerId { get; set; }
        [ForeignKey("Target")]
        public int targetPlayerId { get; set; }
        public String message { get; set; }
        public String status { get; set; }

        public IntroductionSchema()
        {

        }
        public IntroductionSchema(int playerId, int itermediatePlayerId, int targetPlayerId, String message, String status)
        {
            this.playerId = playerId;
            this.itermediatePlayerId = itermediatePlayerId;
            this.targetPlayerId = targetPlayerId;
            this.message = message;
            this.status = status;
        }

        public IntroductionSchema(int? IntroductionId, int playerId, int itermediatePlayerId, int targetPlayerId, String message, String status)
        {
            this.introductionId = IntroductionId.GetValueOrDefault();
            this.playerId = playerId;
            this.itermediatePlayerId = itermediatePlayerId;
            this.targetPlayerId = targetPlayerId;
            this.message = message;
            this.status = status;
        }
    }
}
