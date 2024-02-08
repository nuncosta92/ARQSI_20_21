using ArqsiP1.Contexts;
using ArqsiP1.DataModels;
using ArqsiP1.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArqsiP1.Repositories
{
    public class ConnectionRepo : IConnectionRepo
    {
        private Context _db;

        public ConnectionRepo(Context db)
        {
            _db = db;
        }

        public List<ConnectionSchema> RetrieveAllConnections()
        {
            var allConnections = _db.Connection;
            List<ConnectionSchema> connectionsList = new List<ConnectionSchema>();
            foreach (var connection in allConnections)
            {
                connectionsList.Add(connection);
            }
            return connectionsList;
        }

        public ConnectionSchema UpdateConnection(ConnectionSchema schema)
        {
            ConnectionSchema connectionSchema = _db.Connection.Where(connection => connection.userA == schema.userA && connection.userB == schema.userB).FirstOrDefault<ConnectionSchema>();
            connectionSchema.strength = schema.strength;
            connectionSchema.status = schema.status;
            _db.Connection.Update(connectionSchema);
            _db.SaveChanges();
            return _db.Connection.Find(connectionSchema.connectionId);
        }

        public ConnectionSchema RetrieveConnection(int id)
        {
            return _db.Connection.Find(id);
        }

        public ConnectionSchema CreateConnection(ConnectionSchema schema)
        {
            _db.Connection.Add(schema);
            _db.SaveChanges();
            return schema;
        }

        public ConnectionSchema VerifyConnection(int userA, int userB)
        {
            return _db.Connection.Where(connection => connection.userA == userA && connection.userB == userB).FirstOrDefault<ConnectionSchema>();
        }



        ConnectionSchema IConnectionRepo.UpdateStrength(ConnectionSchema schema)
        {
            var connection = _db.Connection.Where(s => s.connectionId == schema.connectionId)
                       .FirstOrDefault<ConnectionSchema>();

            connection.strength = schema.strength;
            _db.SaveChanges();
            return connection;
        }

        //List<ConnectionSchema> IConnectionRepo.RetrieveAllConnectionsByStatus(String status, int playerLogado)
        //{ 
        //    return _db.Connection.Where(connection => (connection.status == status) && (connection.userB == playerLogado)).ToList<ConnectionSchema>();
        //}

        ConnectionSchema IConnectionRepo.DeleteConnection(ConnectionSchema schema)
        {

            _db.Connection.Remove(schema);
            _db.SaveChanges();
            return schema;
        }

        List<ConnectionSchema> IConnectionRepo.RetrieveConnectionsByPlayer(int player)
        {
            return _db.Connection.Where(connection => ((connection.userA == player) && (connection.status == "APPROVED"))).ToList<ConnectionSchema>();
        }

        public List<ConnectionSchema> RetrievePendingConnections(int playerLogado)
        {
            return _db.Connection.Where(connection => (connection.status == "REQUESTED") && (connection.userB == playerLogado)).ToList<ConnectionSchema>();
        }

        public List<ConnectionSchema> RetrieveActiveConnections(int playerLogado)
        {
                return _db.Connection.Where(connection => (connection.status == "APPROVED") && (connection.userA == playerLogado)).ToList<ConnectionSchema>();
        }
    }
}
