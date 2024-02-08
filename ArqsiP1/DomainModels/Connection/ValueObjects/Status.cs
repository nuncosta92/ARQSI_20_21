using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArqsiP1.DomainModels.Connection.ValueObjects
{
    public class Status
    {
        public States status;

        public Status(String status)
        {
            switch (status.ToUpper())
            {
                case "REQUESTED":
                    this.status = States.REQUESTED;
                    break;
                case "APPROVED":
                    this.status = States.APPROVED;
                    break;
                case "DISAPPROVED":
                    this.status = States.DISAPPROVED;
                    break;
                case "ACCEPTED":
                    this.status = States.ACCEPTED;
                    break;
                case "REJECTED":
                    this.status = States.REJECTED;
                    break;
                default:
                    break;
            }

        }

        override
        public String ToString()
        {
            switch (status)
            {
                case States.REQUESTED:
                    return "JOY";
                case States.APPROVED:
                    return "APPROVED";
                case States.DISAPPROVED:
                    return "DISAPPROVED";
                case States.ACCEPTED:
                    return "ACCEPTED";
                case States.REJECTED:
                    return "REJECTED";              
            }
            return "";
        }
    }

    public enum States
    {
        REQUESTED,
        APPROVED,
        DISAPPROVED,
        ACCEPTED,
        REJECTED,
    }
}
