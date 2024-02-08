using ArqsiP1.Contexts;
using ArqsiP1.DataModels;
using ArqsiP1.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArqsiP1.Repositories
{
    public class IntroductionRepo : IIntroductionRepo
    {

        private Context _db;

        public IntroductionRepo(Context db)
        {
            _db = db;
        }
        IntroductionSchema IIntroductionRepo.CreateIntroduction(IntroductionSchema schema)
        {
            _db.Introduction.Add(schema);
            _db.SaveChanges();
            return schema;
        }

        List<IntroductionSchema> IIntroductionRepo.RetrieveAllIntroductions()
        {
            var allIntroductions = _db.Introduction;
            List<IntroductionSchema> IntroductionsList = new List<IntroductionSchema>();
            foreach (var player in allIntroductions)
            {
                IntroductionsList.Add(player);
            }
            return IntroductionsList;
        }

        IntroductionSchema IIntroductionRepo.RetrieveIntroduction(int id)
        {
            return _db.Introduction.Find(id);
        }

        IntroductionSchema IIntroductionRepo.UpdateIntroduction(IntroductionSchema schema)
        {
            _db.Introduction.Update(schema);
            _db.SaveChanges();
            return _db.Introduction.Find(schema.introductionId);
        }

        IntroductionSchema IIntroductionRepo.getIntroduction(int playerId, int itermediatePlayerId, int targetPlayreId)
        {
            var intro = _db.Introduction.Where(s => s.playerId == playerId).Where(s => s.itermediatePlayerId == itermediatePlayerId).Where(s => s.targetPlayerId == targetPlayreId).FirstOrDefault<IntroductionSchema>();
            return intro;
        }

        void IIntroductionRepo.DeleteIntroduction(IntroductionSchema schema)
        {
            _db.Introduction.Remove(schema);
            _db.SaveChanges();
        }

        public List<IntroductionSchema> RetrieveAllPendingIntroductions(int playerid)
        {
            List<IntroductionSchema> IntroductionsList = _db.Introduction.Where(s => s.itermediatePlayerId == playerid).Where(s => s.status=="REQUESTED").ToList();;
            //List<IntroductionSchema> IntroductionsList = new List<IntroductionSchema>();
            //foreach (var player in allIntroductions)
            //{
            //    IntroductionsList.Add(player);
            //}
            return IntroductionsList;
        }
    }
}
