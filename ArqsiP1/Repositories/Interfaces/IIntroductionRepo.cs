using ArqsiP1.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArqsiP1.Repositories.Interfaces
{
    public interface IIntroductionRepo
    {

        List<IntroductionSchema> RetrieveAllIntroductions();
        IntroductionSchema RetrieveIntroduction(int id);

        IntroductionSchema UpdateIntroduction(IntroductionSchema schema);

        IntroductionSchema CreateIntroduction(IntroductionSchema schema);

        IntroductionSchema getIntroduction(int playerId, int itermediatePlayerId, int targetPlayreId);
        List<IntroductionSchema> RetrieveAllPendingIntroductions(int playerid);

        void DeleteIntroduction(IntroductionSchema schema);
    }
}
