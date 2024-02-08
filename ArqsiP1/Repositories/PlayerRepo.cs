using ArqsiP1.Contexts;
using ArqsiP1.DataModels;
using ArqsiP1.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ArqsiP1.Repositories
{
    public class PlayerRepo : IPlayerRepo
    {
        private Context _db;

        public PlayerRepo(Context db)
        {
            _db = db;
        }
        PlayerSchema IPlayerRepo.CreatePlayer(PlayerSchema schema)
        {
            _db.Player.Add(schema);
            _db.SaveChanges();
            return schema;
        }
        List<PlayerSchema> IPlayerRepo.RetrievePlayersByName(String name)
        {
            return _db.Player.Where(s => s.nome == name).ToList<PlayerSchema>();
        }

        List<PlayerSchema> IPlayerRepo.RetrieveAllPlayers()
        {
            var allPlayers = _db.Player;
            List<PlayerSchema> playersList = new List<PlayerSchema>();
            foreach (var player in allPlayers) {
                playersList.Add(player);
            }
            return playersList;
        }

        PlayerSchema IPlayerRepo.RetrievePlayer(int id)
        {
           return _db.Player.Find(id);
        }

        PlayerSchema IPlayerRepo.RetrievePlayerByEmail(String email)
        {
            var player = _db.Player.Where(s => s.email==email)
                       .FirstOrDefault<PlayerSchema>();

            return player;
        }

        PlayerSchema IPlayerRepo.UpdatePlayer(PlayerSchema schema)
        {
            _db.Player.Update(schema);
            _db.SaveChanges();
            return schema;
        }
        PlayerSchema IPlayerRepo.UpdatePlayerHumor(PlayerSchema schema)
        {
            var player = _db.Player.Where(s => s.playerId== schema.playerId)
                       .FirstOrDefault<PlayerSchema>();

            player.emotionalState = schema.emotionalState;
            _db.SaveChanges();
            return player;
        }
    }
}
