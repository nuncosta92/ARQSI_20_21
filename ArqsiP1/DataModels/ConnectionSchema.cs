using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ArqsiP1.DataModels
{
    public class ConnectionSchema
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int connectionId { get; set; }
        public int strength { get; set; }
        public int userA { get; set; }
        public int userB { get; set; }
        public String status { get; set; }

        public ConnectionSchema()
        { }
        public ConnectionSchema(int userA, int userB, int strength, String status)
        {
            this.userA = userA;
            this.userB = userB;
            this.strength = strength;
            this.status = status;
        }

        public ConnectionSchema(int? connectionId, int userA, int userB, int strength, String status)
        {
            this.connectionId = connectionId.GetValueOrDefault();
            this.userA = userA;
            this.userB = userB;
            this.strength = strength;
            this.status = status;
        }
    }
}
