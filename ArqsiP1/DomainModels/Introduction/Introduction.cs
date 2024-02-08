using ArqsiP1.DomainModels.Introduction.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArqsiP1.DomainModels.Introduction
{
    public class Introduction
    {

        public int? introductionId;
        public int playerId;
        public int itermediatePlayerId;
        public int targetPlayerId;
        public Message message;
        public Status status;


        public Introduction(int playerId, int itermediatePlayerId, int targetPlayerId, String message, String status)
        {
            this.playerId = playerId;
            this.itermediatePlayerId = itermediatePlayerId;
            this.targetPlayerId = targetPlayerId;
            this.message = new Message (message);
            this.status = new Status(status); 
        }

        public Introduction(int? IntroductionId, int playerId, int itermediatePlayerId, int targetPlayerId, String message, String status)
        {
            this.introductionId = IntroductionId;
            this.playerId = playerId;
            this.itermediatePlayerId = itermediatePlayerId;
            this.targetPlayerId = targetPlayerId;
            this.message = new Message(message);
            this.status = new Status(status); 
        }

    }
}
