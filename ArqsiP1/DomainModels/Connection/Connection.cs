using ArqsiP1.DomainModels.Connection.ValueObjects;
using ArqsiP1.DomainModels.Player.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArqsiP1.DomainModels.Connection
{
    public class Connection
    {
        public int? connectionId;
        public Strength strength;
        public int userA;
        public int userB;
        public Status status;

        public Connection(int userA, int userB, int strength,  String status)
        {
            this.userA = userA;
            this.userB = userB;
            this.strength = new Strength(strength);
            this.status = new Status(status);
        }

        public Connection(int? connectionId, int userA, int userB, int strength, String status)
        {
            this.connectionId = connectionId;
            this.userA = userA;
            this.userB = userB;
            this.strength = new Strength(strength);
            this.status = new Status(status);
        }

    }
}
