using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArqsiP1.Dto
{
    public class PlayerConnectionsDto
    {
        public int connectedPlayer;
        public List<int> connecteds; 

        public PlayerConnectionsDto(int player, List<int> list)
        {
            this.connectedPlayer = player;
            this.connecteds = list;
        }
    }
}
