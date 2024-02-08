using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArqsiP1.Dto
{
    public class NetworkDto
    {
        public List<PlayerConnectionsDto> Network;

        public NetworkDto()
        {
            Network = new List<PlayerConnectionsDto>();
        }
    }
}
