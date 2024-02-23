using Terraria;
using Terraria.GameContent;
using Terraria.WorldBuilding;

namespace HeavensAbove.Structures
{
    // TODO: Add structure tilemap for the structure generation later if needed
    public struct StructureData
    {
        public static int[,] testStructure = new int[,]
        {
            {45,45 },
            {45,45 }
        };
    }

    public class Structure
    {
        private int[,] structureData;

        private int posX;
        private int posY;

        public Structure(int x, int y, int type = 0)
        {
            posX = x;
            posY = y;

            switch(type)
            {
                case 0:
                case 1:
                case 2:
                default:
                    structureData = StructureData.testStructure;
                    break;
            }
        }

        public void Generate()
        {
            // Generates the strucutre
            for (int i = 0; i < structureData.GetLength(1); i++)
            {
                for (int j = 0; j < structureData.GetLength(0); j++)
                {
                    Tile tile = Main.tile[posX + i, posY + j];
                    tile.HasTile = true;
                    tile.TileType = (ushort)StructureData.testStructure[i, j];
                }
            }
        }
    }
}
