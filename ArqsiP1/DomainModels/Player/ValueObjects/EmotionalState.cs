using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArqsiP1.DomainModels.Player.ValueObjects
{
    public class EmotionalState
    {
        public States state;

        public EmotionalState(String state)
        {
            switch(state.ToUpper())
            {
                case "JOY": 
                    this.state = States.JOY;
                    break;
                case "ANGER":
                    this.state = States.ANGER;
                    break;
                case "HOPE":
                    this.state = States.HOPE;
                    break;
                case "FEAR":
                    this.state = States.FEAR;
                    break;
                case "RELIEF":
                    this.state = States.RELIEF;
                    break;
                case "RAGE":
                    this.state = States.RAGE;
                    break;
                case "DECEPTION":
                    this.state = States.DECEPTION;
                    break;
                case "PROUD":
                    this.state = States.PROUD;
                    break;
                case "REMORSE":
                    this.state = States.REMORSE;
                    break;
                case "GRATITUDE":
                    this.state = States.GRATITUDE;
                    break;
                default:
                    break;
            }
                
        }

        override
        public String ToString()
        {
            switch (state)
            {
                case States.JOY:
                    return "JOY";
                case States.ANGER:
                    return "ANGER";
                case States.HOPE:
                    return "HOPE";
                case States.FEAR:
                    return "FEAR";
                case States.RELIEF:
                    return "RELIEF";
                case States.RAGE:
                    return "RAGE";
                case States.DECEPTION:
                    return "DECEPTION";
                case States.PROUD:
                    return "PROUD";
                case States.REMORSE:
                    return "REMORSE";
                case States.GRATITUDE:
                    return "GRATITUDE";
            }
            return "";
        }
    }

    public enum States
    {
        JOY,
        ANGER, 
        HOPE, 
        FEAR,
        RELIEF, 
        DECEPTION, 
        PROUD, 
        REMORSE, 
        GRATITUDE, 
        RAGE
    }
}
