using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArqsiP1.Dto
{
    public class IntroductionDto
    {


        public int? introductionId { get; set; }
        public int playerId { get; set; }
        public int itermediatePlayerId { get; set; }
        public int targetPlayerId { get; set; }
        public String message { get; set; }
        public String status { get; set; }

        public IntroductionDto()
        {

        }

        public IntroductionDto(int playerId, int itermediatePlayerId, int targetPlayerId, String message, String status)
            {
                this.playerId = playerId;
                this.itermediatePlayerId = itermediatePlayerId;
                this.targetPlayerId = targetPlayerId;
                this.message = message;
                this.status = status;
            }

            public IntroductionDto(int? IntroductionId, int playerId, int itermediatePlayerId, int targetPlayerId, String message, String status)
            {
            this.introductionId = IntroductionId;
            this.playerId = playerId;
            this.itermediatePlayerId = itermediatePlayerId;
            this.targetPlayerId = targetPlayerId;
            this.message = message;
            this.status = status;
        }
    }
}
