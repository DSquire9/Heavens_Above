using Terraria;
using System.IO;
using Terraria.ModLoader;

namespace HeavensAbove.Structures
{
    public class Island
    {
        int islandWidth;
        int islandHeight;
        // Offsets from WorldSpawn
        int offsetX;
        int offsetY;
        private int[,] islandTiles;
        public Island(int islandType = -1,int x = 0, int y = 0)
        {
            offsetX = x;
            offsetY = y;

            PopulateTiles(islandType);
        }

        // This is a method to generate the island's tileMaps using predefined structure data
        private void PopulateTiles(int islandType)
        {
            switch(islandType)
            {
                case 0:
                    islandTiles = StructureData.largeIsland;
                    islandWidth = islandTiles.GetLength(1);
                    islandHeight = islandTiles.GetLength(0);
                    break;
                case 1:
                    islandTiles = StructureData.smallIsland;
                    islandWidth = islandTiles.GetLength(1);
                    islandHeight = islandTiles.GetLength(0);
                    break;
                case 2:
                    islandTiles = StructureData.mediumIsland;
                    islandWidth = islandTiles.GetLength(1);
                    islandHeight = islandTiles.GetLength(0);
                    break;
                default:
                    System.Console.WriteLine("Invalid Island Type! Generating default");
                    islandTiles = StructureData.testIsland;
                    islandWidth = islandTiles.GetLength(1);
                    islandHeight = islandTiles.GetLength(0);
                    break;
            }
        }

        public void Generate(bool isRand)
        {
            if(isRand)
            {
                // Picks a point on the first half of the map
                offsetX += WorldGen.genRand.Next(0, Main.maxTilesX /2);
                // Decides if it should be on the right side of the map
                if (WorldGen.genRand.NextBool())
                {
                    offsetX = Main.maxTilesX - offsetX;
                    // Ensures the island will be on the map in full since it starts on top left corner
                    offsetX -= islandWidth;
                }

                // Picks a point in the middle half of the world
                offsetY =  WorldGen.genRand.Next(Main.maxTilesY / 4, Main.maxTilesY * 3 / 4);
                // If the island will generate outside of the Y bounds, put it back on the map
                if(offsetY + islandHeight > Main.maxTilesY)
                {
                    offsetY = Main.maxTilesY - islandHeight;
                }
                System.Console.WriteLine("Placing an Island at: " + offsetX + " " + offsetY);
            }
            else
            {
                // By Default, it will generate the island in the middle of the map
                offsetX += Main.maxTilesX/2 - islandWidth / 2;
                offsetY += (int)Main.maxTilesY /2;
            }
            for (int i = 0; i < islandTiles.GetLength(1); i++)
            {
                for (int j = 0; j < islandTiles.GetLength(0); j++)
                {
                    int wX = i + offsetX;
                    int wY = j + offsetY;
                    if(islandTiles[j, i] != -1)
                    {
                        WorldGen.PlaceTile(wX, wY, islandTiles[j, i]);
                        //System.Console.WriteLine("Placing an Island Block at: " + wX + " " + wY);
                    }
                }
            }
        }
    }
}
