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
                    islandTiles = StructureData.cubeIsland;
                    islandWidth = islandTiles.GetLength(1);
                    islandHeight = islandTiles.GetLength(0);
                    break;
                case 1:
                    break;
                case 2:
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
                offsetX += WorldGen.genRand.Next(0, Main.maxTilesX / 4);
                if (WorldGen.genRand.NextBool())
                {
                    offsetX = Main.maxTilesX - offsetX;
                }

                offsetY = (int)Main.maxTilesY / 2 + WorldGen.genRand.Next(0, Main.maxTilesY / 4);
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
