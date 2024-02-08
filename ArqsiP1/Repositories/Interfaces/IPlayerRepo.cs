using ArqsiP1.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArqsiP1.Repositories.Interfaces
{
    public interface IPlayerRepo
    {

        List<PlayerSchema> RetrieveAllPlayers();

        List<PlayerSchema> RetrievePlayersByName(String name);
        PlayerSchema RetrievePlayer(int id);

        PlayerSchema UpdatePlayer(PlayerSchema schema);

        PlayerSchema RetrievePlayerByEmail (String email);

        PlayerSchema CreatePlayer(PlayerSchema schema);

        PlayerSchema UpdatePlayerHumor(PlayerSchema schema);

    }

}
