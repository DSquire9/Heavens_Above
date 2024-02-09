using Terraria;
using Terraria.ID;

namespace HeavensAbove.Structures
{
    public class Island
    {
        int islandWidth;
        int islandHeight;
        // Offsets from WorldSpawn
        int offsetX = 0;
        int offsetY = 0;
        private int[,] islandTiles;
        public Island(int width = 17,int height = 17, int x = 0)
        {
            offsetX = x;
            islandWidth = width;
            islandHeight = height;

            islandTiles = new int[islandHeight, islandWidth];
            for(int i = 0; i < islandHeight; i++)
            {
                for(int j = 0; j < islandWidth; j++)
                {
                    islandTiles[i, j] = -1;
                }
            }
            PopulateTiles();
        }

        private void PopulateTiles()
        {
            int[,] tileData = new int[,]{{ -1,-1,-1,-1,0,0,0,0,0,0,-1,-1,-1,-1,-1,-1,-1},
            { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
            { 0,0,0,0,-1,-1,-1,0,0,0,0,0,0,0,-1,-1,-1 },
            { -1,-1,0,-1,-1,-1,-1,-1,-1,0,0,0,0,-1,-1,-1,-1 },
            { -1,-1,-1,-1,-1,-1,-1,-1,-1,-1,0,0 ,-1,-1,-1,-1,-1 } };
            for (int i = 0; i < tileData.GetLength(1); i++)
            {
                for (int j = 0; j < tileData.GetLength(0); j++)
                {
                    islandTiles[j, i] = tileData[j, i];
                }
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

                offsetY = (int)Main.maxTilesY / 2 - 10;
            }
            else
            {
                offsetX = Main.maxTilesX/2 - islandWidth / 2;
                offsetY = (int)Main.maxTilesY /2;
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
                        System.Console.WriteLine("Placing an Island Block at: " + wX + " " + wY);
                    }
                }
            }
        }
    }
}
