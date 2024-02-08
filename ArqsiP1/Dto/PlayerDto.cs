using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArqsiP1.Dto
{
    public class PlayerDto
    {
        public int? playerId { get; set; }
        public String nome { get; set; }
        public String country { get; set; }
        public String city { get; set; }
        public String password { get; set; }
        public String email { get; set; }
        public String phone { get; set; }
        public String birthdate { get; set; }
        public String avatar { get; set; }
        public String linkedIn { get; set; }
        public String facebook { get; set; }
        public String description { get; set; }
        public String emotionalState { get; set; }

        public PlayerDto()
        {

        }
        public PlayerDto(String nome,  String country, String city, String password, String email, String phone, String birthdate, String avatar, String linkedIn, String facebook, String description, String emotionalState)
        {
            this.nome = nome;
            this.country = country;
            this.city = city;
            this.password = password;
            this.email = email;
            this.phone = phone;
            this.birthdate = birthdate;
            this.avatar = avatar;
            this.linkedIn = linkedIn;
            this.facebook = facebook;
            this.description = description;
            this.emotionalState = emotionalState;
        }

        public PlayerDto(int? playerId, String nome, String country, String city, String password, String email, String phone, String birthdate, String avatar, String linkedIn, String facebook, String description, String emotionalState)
        {
            this.playerId = playerId;
            this.nome = nome;
            this.country = country;
            this.city = city;
            this.password = password;
            this.email = email;
            this.phone = phone;
            this.birthdate = birthdate;
            this.avatar = avatar;
            this.linkedIn = linkedIn;
            this.facebook = facebook;
            this.description = description;
            this.emotionalState = emotionalState;
        }
    }
}
