using AlgoTown.Core;
using AlgoTown.Core.Utils;
using AlgoTown.Utils;
using System;
using System.Diagnostics;

public class RandomTown : AbstractTown
{
    public override string GetASCIIArt()
    {
        ASCIIArtPivotX = 10;
        ASCIIArtPivotY = 6;

        return
@"
    _________________
   /               /|
  /       *       / |
 /_______________/ *|
|               |   |
|   *       *   |*  |
|               |   |
|       *       |  *|
|               |* /
|   *       *   | / 
|_______________|/
";
    }

    public override TownActions PerformAction(TurnInfo i)
    {
        // Get a random number
        int r = Utils.Random(0, 3);

        // Use the random number to randomly select 1 of 4 town actions
        switch (r)
        {
            case 0:
                return TownActions.Hunt;
            case 1:
                return TownActions.Build;
            //case 2:
            //    return TownActions.Attack;
            default:
                return TownActions.Attack;
        }


    }
}
