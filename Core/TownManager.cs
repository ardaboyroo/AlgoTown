using AlgoTown.Core.Config;
using AlgoTown.Utils;

namespace AlgoTown.Core
{
    public class TownManager
    {
        private AbstractTown town1;
        private AbstractTown town2;

        private TownInfo town1Info;
        private TownInfo town2Info;

        private TurnInfo baseTurnInfo;
        private TurnInfo town1TurnInfo;
        private TurnInfo town2TurnInfo;

        private int GlobalResources;

        public TownManager()
        {
            // Start out with full supply
            GlobalResources = GameConfig.MaxGlobalResources;
        }

        public void InitTown1(AbstractTown t1)
        {
            town1 = t1;
            town1Info = new TownInfo();
            town1Info.Population = GameConfig.StartingPopulation;
            town1Info.Resources = GameConfig.StartingResources;
        }

        public void InitTown2(AbstractTown t2)
        {
            town2 = t2;
            town2Info = new TownInfo();
            town2Info.Population = GameConfig.StartingPopulation;
            town2Info.Resources = GameConfig.StartingResources;
        }

        public void PrepareTurnInfos(int day)
        {
            // Define a base turn info struct where information is the same for both towns
            baseTurnInfo = new TurnInfo();
            baseTurnInfo.MaxDays = GameConfig.Days;
            baseTurnInfo.Day = day;
            baseTurnInfo.MaxGlobalResources = GameConfig.MaxGlobalResources;
            baseTurnInfo.GlobalResources = GlobalResources;

            town1TurnInfo = baseTurnInfo;
            town1TurnInfo.SelfAction = town1Info.LastAction;
            town1TurnInfo.OpponentAction = town2Info.LastAction;
            town1TurnInfo.Population = town1Info.Population;
            town1TurnInfo.Resources = town1Info.Resources;

            town2TurnInfo = baseTurnInfo;
            town2TurnInfo.SelfAction = town2Info.LastAction;
            town2TurnInfo.OpponentAction = town1Info.LastAction;
            town2TurnInfo.Population = town2Info.Population;
            town2TurnInfo.Resources = town2Info.Resources;
        }

        public void InvokeTowns()
        {
            town1Info.LastAction = town1.PerformAction(town1TurnInfo);
            town2Info.LastAction = town2.PerformAction(town2TurnInfo);
        }

        public void ProcessTurn()
        {
            ProcessAction(ref town1Info, ref town1TurnInfo, ref town2Info);
            ProcessAction(ref town2Info, ref town2TurnInfo, ref town1Info);

            // Replenish global resources
            if (GlobalResources + 1 <= GameConfig.MaxGlobalResources)
                GlobalResources += 1;
            else
                GlobalResources = GameConfig.MaxGlobalResources;
        }

        private void ProcessAction(ref TownInfo t1, ref TurnInfo tu1, ref TownInfo t2)
        {
            if (t1.LastAction == tu1.SelfAction)
                t1.ConsecutiveCount++;
            else
                t1.ConsecutiveCount = 1;

            switch (t1.LastAction)
            {
                case TownActions.Hunt:
                    if (t1.ConsecutiveCount == 1)
                    {
                        t1.Resources += 1;
                        GlobalResources -= 1;
                    }
                    else if (t1.ConsecutiveCount == 2)
                    {
                        t1.Resources += 2;
                        GlobalResources -= 2;
                    }
                    else if (t1.ConsecutiveCount >= 3)
                    {
                        t1.Resources += 3;
                        GlobalResources -= 3;
                    }
                    break;

                case TownActions.Build:
                    if (t1.ConsecutiveCount == 1 && t1.Resources >= 1)
                    {
                        t1.Population += 1;
                        t1.Resources -= 1;
                    }
                    else if (t1.ConsecutiveCount == 2 && t1.Resources >= 2)
                    {
                        t1.Population += 2;
                        t1.Resources -= 2;
                    }
                    else if (t1.ConsecutiveCount >= 3 && t1.Resources >= 3)
                    {
                        t1.Population += 3;
                        t1.Resources -= 3;
                    }
                    break;

                case TownActions.Attack:
                    if (t1.ConsecutiveCount == 1 && t1.Resources >= 5)
                    {
                        t1.Resources -= 5;
                        if (t2.Population - 3 > 0)
                            t2.Population -= 3;
                        else
                            t2.Population = 0;
                    }
                    else if (t1.ConsecutiveCount == 2 && t1.Resources >= 5)
                    {
                        t1.Resources -= 5;
                        if (t2.Population - 2 > 0)
                            t2.Population -= 2;
                        else
                            t2.Population = 0;
                    }
                    else if (t1.ConsecutiveCount == 3 && t1.Resources >= 5)
                    {
                        t1.Resources -= 5;
                        if (t2.Population - 1 > 0)
                            t2.Population -= 1;
                        else
                            t2.Population = 0;
                    }
                    break;
            }
        }

        public void PrintTurnResults()
        {
            LogObject results = new LogObject(GameConfig.ConsoleHeight, GameConfig.ConsoleWidth);

            int leftCenter = (int)(GameConfig.ConsoleWidth * 0.25f);
            int rightCenter = (int)(GameConfig.ConsoleWidth * 0.75f);
            int textYOffset = 19;

            // Place the day string at the top
            results.PlaceString($"Day: {baseTurnInfo.Day}", GameConfig.ConsoleWidth / 2, 1, 3, 0);

            // Place the town names at the top
            results.PlaceString(town1.TownName, leftCenter, 3, town1.TownName.Length / 2, 0);
            results.PlaceString(town2.TownName, rightCenter, 3, town2.TownName.Length / 2, 0);

            // Place the ASCII art of the towns in the center of each side
            results.PlaceString(town1.GetASCIIArt(), leftCenter, 11, town1.ASCIIArtPivotX, town1.ASCIIArtPivotY);
            results.PlaceString(town2.GetASCIIArt(), rightCenter, 11, town2.ASCIIArtPivotX, town2.ASCIIArtPivotY);

            // Place the Population count string
            results.PlaceString($"Population: {town1Info.Population}", leftCenter - 10, textYOffset, 10, 0);
            results.PlaceString($"Population: {town2Info.Population}", rightCenter - 10, textYOffset, 10, 0);

            // Place the Resources count string
            results.PlaceString($"Resources: {town1Info.Resources}", leftCenter - 10, textYOffset + 1, 9, 0);
            results.PlaceString($"Resources: {town2Info.Resources}", rightCenter - 10, textYOffset + 1, 9, 0);

            // Place the Action string
            results.PlaceString($"Action: {town1Info.LastAction}", leftCenter + 15, textYOffset, 7, 0);
            results.PlaceString($"Action: {town2Info.LastAction}", rightCenter + 15, textYOffset, 7, 0);

            // Place the Previous Action string
            results.PlaceString($"Previous Action: {town1TurnInfo.SelfAction}", leftCenter + 15, textYOffset + 1, 16, 0);
            results.PlaceString($"Previous Action: {town2TurnInfo.SelfAction}", rightCenter + 15, textYOffset + 1, 16, 0);

            // Place the Consecutive Count string
            results.PlaceString($"Consecutive Count: {town1Info.ConsecutiveCount}", leftCenter + 15, textYOffset + 3, 17, 0);
            results.PlaceString($"Consecutive Count: {town2Info.ConsecutiveCount}", rightCenter + 15, textYOffset + 3, 17, 0);

            // Strokes to separate the names from the rest
            results.PlaceString(LogTools.GetStroke('-'), 1, 2);
            results.PlaceString(LogTools.GetStroke('-'), 1, 4);

            // Vertical Line in the middle
            for (int i = 2; i < GameConfig.ConsoleHeight + 1; i++)
            {
                results.PlaceString("|", GameConfig.ConsoleWidth / 2, i);
            }

            // Place the Global Resources string
            results.PlaceString($"Global Resources: {GlobalResources}", GameConfig.ConsoleWidth / 2, 25, 16, 0);

            results.Print();
        }
    }
}
