using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTown.Core
{
    public struct TurnInfo
    {
        public int MaxDays;
        public int Day;

        public TownActions? SelfAction;
        public TownActions? OpponentAction;

        public int Population;
        public int Resources;

        public int? MaxGlobalResources;
        public int? GlobalResources;
    }
}
