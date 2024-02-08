using ArqsiP1.DomainModels.Player.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArqsiP1.DomainModels.Player
{
    public class Player
    {
        public int? playerId;
        public Nome nome;
        public Country country;
        public City city;
        public Password password;
        public Email email;
        public Phone phone;
        public Birthdate birthdate;
        public Avatar avatar;
        public LinkedIn linkedIn;
        public Facebook facebook;
        public Description description;
        public EmotionalState emotionalState;

      

        public Player(int? playerId, String nome, String country, String city, String password, String email, String phone, String birthdate, String avatar, String linkedIn, String facebook, String description, String emotionalState)
        {
            this.playerId = playerId;
            this.nome = new Nome(nome);
            this.country = new Country(country);
            this.city = new City(city);
            this.password = new Password(password);
            this.email = new Email(email);
            this.phone = new Phone(phone);
            this.birthdate = new Birthdate(birthdate);
            this.avatar = new Avatar(avatar);
            this.linkedIn = new LinkedIn(linkedIn);
            this.facebook = new Facebook(facebook);
            this.description = new Description(description);
            this.emotionalState = new EmotionalState(emotionalState);
        }

        public Player(String nome, String country, String city, String password, String email, String phone, String birthdate, String avatar, String linkedIn, String facebook, String description, String emotionalState)
        {
            this.nome = new Nome(nome);
            this.country = new Country(country);
            this.city = new City(city);
            this.password = new Password(password);
            this.email = new Email(email);
            this.phone = new Phone(phone);
            this.birthdate = new Birthdate(birthdate);
            this.avatar = new Avatar(avatar);
            this.linkedIn = new LinkedIn(linkedIn);
            this.facebook = new Facebook(facebook);
            this.description = new Description(description);
            this.emotionalState = new EmotionalState(emotionalState);
        }

    }
}
