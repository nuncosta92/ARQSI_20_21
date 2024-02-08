using ArqsiP1.DataModels;
using ArqsiP1.DomainModels.Connection;
using ArqsiP1.DomainModels.Connection.ValueObjects;
using ArqsiP1.DomainModels.Introduction;
using ArqsiP1.Dto;
using ArqsiP1.Mappers;
using ArqsiP1.Repositories.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArqsiP1.Services
{
    public class ConnectionService
    {
        ConnectionMapper _mapper;
        Connection _connection;
        ConnectionSchema _connectionSchema;
        IConnectionRepo _repo;

        public ConnectionService(IConnectionRepo repo)
        {
            _mapper = new ConnectionMapper();
            _repo = repo;
        }

        internal List<ConnectionDto> GetAllConnections()
        {
            List<ConnectionDto> connectionsToDto = new List<ConnectionDto>();
            List<ConnectionSchema> connectionssFromSchema = _repo.RetrieveAllConnections();

            connectionssFromSchema.ForEach(
                connetionSchema =>
                {
                    Connection connection = _mapper.toDomain(connetionSchema);
                    connectionsToDto.Add(_mapper.toDto(connection));
                });

            return connectionsToDto;
        }

        public ConnectionDto CreateConnection(ConnectionDto dto)
        {
            _connection = _mapper.toDomain(dto);

            //**Block to generate/change connection model**//
            ConnectionSchema schema = _mapper.toSchema(_connection);
            schema = _repo.CreateConnection(schema);
            _connection = _mapper.toDomain(schema);
            return _mapper.toDto(_connection);
        }
        
        // True if exists, False if it doesn't
        internal Boolean VerifyConnection(int userA, int userB)
        {
            return _repo.VerifyConnection(userA, userB) != null;
        }



        internal ConnectionDto GetConnectionById(int id)
        {
            _connection = _mapper.toDomain(_repo.RetrieveConnection(id));
            return _mapper.toDto(_connection);
        }

        public ConnectionDto UpdateStrength(int id, int strenght)
        {
            ConnectionSchema schema = _repo.RetrieveConnection(id);
            _connection = _mapper.toDomain(schema);
            _connection.strength = new Strength(strenght);
            schema = _mapper.toSchema(_connection);
            schema = _repo.UpdateStrength(schema);
            _connection = _mapper.toDomain(schema);
            return _mapper.toDto(_connection);

        }

        public ConnectionDto UpdateConnection(ConnectionDto dto)
        {
            _connection = _mapper.toDomain(dto);

            ConnectionSchema schema = _mapper.toSchema(_connection);
            schema = _repo.UpdateConnection(schema);
            _connection = _mapper.toDomain(schema);
            return _mapper.toDto(_connection);
        }


        //internal List<ConnectionDto> getConnectionByStatus(int id, String status)
        //{
        //    int playerLogado = 3; //temporario, aqui abtinha-se o cod de jogador logado

        //    List<ConnectionSchema> schemaList = _repo.RetrieveAllConnectionsByStatus(status, playerLogado);
        //    List<ConnectionDto> connectionList = new List<ConnectionDto>();

        //    schemaList.ForEach(
        //        connectioSchema =>
        //        {
        //            Connection connection = _mapper.toDomain(connectioSchema);
        //            ConnectionDto connectionDto = _mapper.toDto(connection);
        //            connectionList.Add(connectionDto);
        //        });
        //    return connectionList;
        //}

        internal List<ConnectionDto> getActiveConnections(int id)
        {

            List<ConnectionSchema> schemaList = _repo.RetrieveActiveConnections(id);
            List<ConnectionDto> connectionList = new List<ConnectionDto>();

            schemaList.ForEach(
                connectioSchema =>
                {
                    Connection connection = _mapper.toDomain(connectioSchema);
                    ConnectionDto connectionDto = _mapper.toDto(connection);
                    connectionList.Add(connectionDto);
                });
            return connectionList;
        }

        internal List<ConnectionDto> getPendingConnections(int id)
        {

            List<ConnectionSchema> schemaList = _repo.RetrievePendingConnections(id);
            List<ConnectionDto> connectionList = new List<ConnectionDto>();

            schemaList.ForEach(
                connectioSchema =>
                {
                    Connection connection = _mapper.toDomain(connectioSchema);
                    ConnectionDto connectionDto = _mapper.toDto(connection);
                    connectionList.Add(connectionDto);
                });
            return connectionList;
        }

        public ConnectionDto createRequestedConnection(Introduction intro)
        {
            Connection connection = new Connection(intro.playerId, intro.targetPlayerId, 0, "REQUESTED");
            ConnectionSchema connectionSchema= _repo.CreateConnection(_mapper.toSchema(connection));
            connection = _mapper.toDomain(connectionSchema);
            ConnectionDto connectionDto = _mapper.toDto(connection);
            return connectionDto;
        }

        internal ConnectionDto takeActionConnection(ConnectionDto dto)
        {
            _connection = _mapper.toDomain(dto);
            ConnectionSchema connectionSchema = _mapper.toSchema(_connection);
            ConnectionDto connectionDto;
            if(dto.status == "APPROVED")
            {
                _repo.UpdateConnection(connectionSchema);

                Connection newConnection = new Connection(_connection.userB, _connection.userA, _connection.strength.strength, "APPROVED");
                connectionDto = _mapper.toDto(_mapper.toDomain(_repo.CreateConnection(_mapper.toSchema(newConnection)))); // connection is not A <-> B, so A->B and B<-A must be created
            }
            else
            {
                connectionSchema = _repo.VerifyConnection(dto.userA, dto.userB);
                connectionSchema.status = "DISAPPROVED";
                connectionDto = _mapper.toDto(_mapper.toDomain(_repo.UpdateConnection(connectionSchema)));
            }
            return connectionDto;
        }

        internal NetworkDto getNetworkFromPlayerPrespective(int playerId)
        {
            List<ConnectionSchema> connectionsFromSchema = _repo.RetrieveConnectionsByPlayer(playerId);
            NetworkDto dto = new NetworkDto();

            foreach(ConnectionSchema schema in connectionsFromSchema) // connections
            {
                List<int> connectionsOfPlayer = new List<int>();

                foreach (ConnectionSchema schemaOfConnection in _repo.RetrieveConnectionsByPlayer(schema.userB)) // connections os connection
                {
                    connectionsOfPlayer.Add(schemaOfConnection.userB);
                }
                dto.Network.Add(new PlayerConnectionsDto(schema.userB, connectionsOfPlayer));
            }

            return dto;
        }
    }
}
