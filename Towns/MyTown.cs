using AlgoTown.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class MyTown : AbstractTown
{
    public override TownActions PerformAction(TurnInfo info)
    {
        return TownActions.Scout;

    }
}

