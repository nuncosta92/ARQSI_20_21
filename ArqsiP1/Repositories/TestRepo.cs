using ArqsiP1.Contexts;
using ArqsiP1.DataModels;
using ArqsiP1.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArqsiP1.Repositories
{
    public class TestRepo : ITestRepo
    {
        private Context _db;

        public TestRepo(Context db)
        {
            _db = db;
        }

        public void TearDown()
        {
            var allPlayers = _db.Player;
            foreach (var player in allPlayers)
            {
                _db.Remove(player);
            }

            _db.SaveChanges();

            var allConnections = _db.Connection;
            foreach (var connection in allConnections)
            {
                _db.Remove(connection);
            }

            _db.SaveChanges();

            var allIntroductions = _db.Introduction;
            foreach (var introduction in allIntroductions)
            {
                _db.Remove(introduction);
            }

            _db.SaveChanges();

            var allTags = _db.Tag;
            foreach (var tag in allTags)
            {
                _db.Remove(tag);
            }

            _db.SaveChanges();
        }
    }
}
