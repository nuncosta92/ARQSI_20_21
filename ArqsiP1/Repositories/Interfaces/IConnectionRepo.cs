using ArqsiP1.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArqsiP1.Repositories.Interfaces
{
    public interface IConnectionRepo
    {
        List<ConnectionSchema> RetrieveAllConnections();

        ConnectionSchema UpdateConnection(ConnectionSchema schema);

        ConnectionSchema CreateConnection(ConnectionSchema schema);

        ConnectionSchema VerifyConnection(int userA, int userB);

        ConnectionSchema RetrieveConnection(int id);

        ConnectionSchema UpdateStrength(ConnectionSchema schema);

        
        List<ConnectionSchema> RetrievePendingConnections(int playerLogado);

        List<ConnectionSchema> RetrieveActiveConnections(int playerLogado);

        ConnectionSchema DeleteConnection(ConnectionSchema schema);

        List<ConnectionSchema> RetrieveConnectionsByPlayer(int player);
    }
}

