using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTown.Core.Config
{
    public static class GameConfig
    {
        // Width of the console in characters
        public static int ConsoleWidth = 120;

        // Height of the console in characters
        public static int ConsoleHeight = 30;

        // Amount of actions the towns will make
        // with 1 action per day
        public static int Days = 200;

        // Max amount of global resources
        // When this depletes the towns won't be able to gather resources
        public static int MaxGlobalResources = 100;

        // Amount of population each town starts with
        public static int StartingPopulation = 5;

        // Amount of resources each town starts with
        public static int StartingResources = 5;

    }
}
