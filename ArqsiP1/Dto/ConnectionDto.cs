using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArqsiP1.Dto
{
    public class ConnectionDto
    {
        public int? connectionId { get; set; }
        public int strength { get; set; }
        public int userA { get; set; }
        public int userB { get; set; }
        public String status { get; set; }

        public ConnectionDto()
        {

        }

        public ConnectionDto(int userA, int userB, int strength, String status)
        {
            this.userA = userA;
            this.userB = userB;
            this.strength = strength;
            this.status = status;
        }

        public ConnectionDto(int? connectionId, int userA, int userB, int strength, String status)
        {
            this.connectionId = connectionId;
            this.userA = userA;
            this.userB = userB;
            this.strength = strength;
            this.status = status;
        }
    }
}
