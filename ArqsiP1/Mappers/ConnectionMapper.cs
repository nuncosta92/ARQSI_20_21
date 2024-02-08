using ArqsiP1.DataModels;
using ArqsiP1.DomainModels.Connection;
using ArqsiP1.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArqsiP1.Mappers
{
    public class ConnectionMapper
    {

        public Connection toDomain(ConnectionDto dto)
        {
            if (dto.connectionId == null)
                return new Connection(dto.userA, dto.userB, dto.strength, dto.status);

            else
                return new Connection(dto.connectionId, dto.userA, dto.userB, dto.strength, dto.status);

        }

        public ConnectionDto toDto(Connection connection)
        {
            if (connection.connectionId == null)
                return new ConnectionDto(connection.userA, connection.userB, connection.strength.strength, connection.status.status.ToString());
            else
                return new ConnectionDto(connection.connectionId, connection.userA, connection.userB, connection.strength.strength, connection.status.status.ToString());
        }

        public Connection toDomain(ConnectionSchema schema)
        {
            if (schema.connectionId == null)
                return new Connection(schema.userA, schema.userB, schema.strength, schema.status);
            else
                return new Connection(schema.connectionId, schema.userA, schema.userB, schema.strength, schema.status);

        }

        public ConnectionSchema toSchema(Connection connection)
        {
            if (connection.connectionId == null)
                return new ConnectionSchema(connection.userA, connection.userB, connection.strength.strength, connection.status.status.ToString());
            else
                return new ConnectionSchema(connection.connectionId, connection.userA, connection.userB, connection.strength.strength, connection.status.status.ToString());

        }
    }
}
