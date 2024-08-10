using AlgoTown.Core.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTown.Core
{
    public struct TownInfo
    {
        public TownActions? LastAction;
        public int ConsecutiveCount;

        public int Population;
        public int Resources;
    }
}
