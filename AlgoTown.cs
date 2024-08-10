using AlgoTown.Core;
using AlgoTown.Core.Config;
using AlgoTown.Utils;
using System;

namespace AlgoTown
{
    public class AlgoTown
    {
        private TownManager townManager;

        AlgoTown()
        {
            // Set the console size
            Console.SetWindowSize(GameConfig.ConsoleWidth, GameConfig.ConsoleHeight);

            // Initiliaze the town manager
            townManager = new TownManager();

            // Initialize the towns
            townManager.InitTown1(new RandomTown());
            townManager.InitTown2(new RandomTown());
        }

        public void Run()
        {
            townManager.PrintTurnResults();

            // Main game loop
            for (int day = 1; day <= GameConfig.Days; day++)
            {
                townManager.PrepareTurnInfos(day);

                townManager.InvokeTowns();

                townManager.ProcessTurn();

                townManager.PrintTurnResults();
            }

            LogTools.EdgeProgram();
        }

        static void Main(string[] args)
        {
            AlgoTown battle = new AlgoTown();
            battle.Run();
        }
    }
}
