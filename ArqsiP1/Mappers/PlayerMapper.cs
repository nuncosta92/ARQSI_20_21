using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArqsiP1.DataModels;
using ArqsiP1.DomainModels.Player;
using ArqsiP1.Dto;

namespace ArqsiP1.Mappers
{
    public class PlayerMapper
    {
        public Player toDomain(PlayerDto dto)
        {
            if(dto.playerId==null) 
                return new Player(dto.nome, dto.country, dto.city, dto.password, dto.email, dto.phone, dto.birthdate, dto.avatar, dto.linkedIn, dto.facebook, dto.description, dto.emotionalState);
            
            else
                return new Player(dto.playerId, dto.nome, dto.country, dto.city, dto.password, dto.email, dto.phone, dto.birthdate, dto.avatar, dto.linkedIn, dto.facebook, dto.description, dto.emotionalState);

        }

        public PlayerDto toDto(Player player)
        {
            if (player.playerId == null)
                return new PlayerDto(player.nome.nome , player.country.country, player.city.city, player.password.password, player.email.email, player.phone.phone, player.birthdate.birthdate, player.avatar.avatar, player.linkedIn.linkedIn, player.facebook.facebook, player.description.description, player.emotionalState.state.ToString());
            else
                return new PlayerDto(player.playerId, player.nome.nome, player.country.country, player.city.city, player.password.password, player.email.email, player.phone.phone, player.birthdate.birthdate, player.avatar.avatar, player.linkedIn.linkedIn, player.facebook.facebook, player.description.description, player.emotionalState.state.ToString());
        }

        public Player toDomain(PlayerSchema schema)
        {
            if (schema.playerId == null)
                return new Player(schema.nome, schema.country, schema.city, schema.password, schema.email, schema.phone, schema.birthdate, schema.avatar, schema.linkedIn, schema.facebook, schema.description, schema.emotionalState);
            else
                return new Player(schema.playerId, schema.nome, schema.country, schema.city, schema.password, schema.email, schema.phone, schema.birthdate, schema.avatar, schema.linkedIn, schema.facebook, schema.description, schema.emotionalState);

        }

        public PlayerSchema toSchema(Player player)
        {
            if (player.playerId == null)
                return new PlayerSchema(player.nome.nome, player.country.country, player.city.city, player.password.password, player.email.email, player.phone.phone, player.birthdate.birthdate, player.avatar.avatar, player.linkedIn.linkedIn, player.facebook.facebook, player.description.description, player.emotionalState.state.ToString());
            else
                return new PlayerSchema(player.playerId, player.nome.nome, player.country.country, player.city.city, player.password.password, player.email.email, player.phone.phone, player.birthdate.birthdate, player.avatar.avatar, player.linkedIn.linkedIn, player.facebook.facebook, player.description.description, player.emotionalState.state.ToString());

        }

    }
}
