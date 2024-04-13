using HeavensAbove.Content.Tiles;
using System.Drawing;
using Terraria;
using Terraria.GameContent;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.WorldBuilding;

namespace HeavensAbove.Structures
{

    public class Structure
    {
        private int width;
        private int height;

        private int posX;
        private int posY;

        public Structure(int _x, int _y, int type = 0)
        {
            posX = _x;
            posY = _y;

            switch (type)
            {
                case 0:
                case 1:
                case 2:
                default:
                    width = 150;
                    height = 75;
                    break;
            }
        }

        public void Generate()
        {
            // Generates the strucutre with walls assuming the wall structure and block structure are the same size
            WorldUtils.Gen(new Microsoft.Xna.Framework.Point(posX,posY), new Shapes.Rectangle(width, height), new Actions.SetTile((ushort)ModContent.TileType<DungeonTile>()));
            WorldUtils.Gen(new Microsoft.Xna.Framework.Point(posX+6, posY+3), new Shapes.Rectangle(width-(6*2), height-(3*2)), new Actions.ClearTile());
            WorldUtils.Gen(new Microsoft.Xna.Framework.Point(posX+1, posY+1), new Shapes.Rectangle(width-2, height-2), new Actions.PlaceWall((ushort)ModContent.WallType<DungeonWall>()));

            WorldUtils.Gen(new Microsoft.Xna.Framework.Point(posX +12, posY + height/2), new Shapes.Rectangle(width /3, 1), new Actions.SetTile(TileID.Platforms));
            WorldUtils.Gen(new Microsoft.Xna.Framework.Point(posX+(width*2/3) - 12, posY + height / 2), new Shapes.Rectangle(width / 3, 1), new Actions.SetTile(TileID.Platforms));

            WorldUtils.Gen(new Microsoft.Xna.Framework.Point(posX + 36, posY + (height *3/4)), new Shapes.Rectangle(width / 3, 1), new Actions.SetTile(TileID.Platforms));
            WorldUtils.Gen(new Microsoft.Xna.Framework.Point(posX + (width * 2 / 3) - 36, posY + (height * 3 / 4)), new Shapes.Rectangle(width / 3, 1), new Actions.SetTile(TileID.Platforms));

            WorldUtils.Gen(new Microsoft.Xna.Framework.Point(posX + 36, posY + height / 4), new Shapes.Rectangle(width / 3, 1), new Actions.SetTile(TileID.Platforms));
            WorldUtils.Gen(new Microsoft.Xna.Framework.Point(posX + (width * 2 / 3) - 36, posY + height / 4), new Shapes.Rectangle(width / 3, 1), new Actions.SetTile(TileID.Platforms));

            WorldUtils.Gen(new Microsoft.Xna.Framework.Point(posX + width / 2-1, posY + height/2+1), new Shapes.Rectangle(3, 1), new Actions.SetTile((ushort)ModContent.TileType<DungeonTile>()));
            WorldGen.Place3x2(posX + width/2, posY + height/2, (ushort)ModContent.TileType<SunSpiritAltar>());

            WorldUtils.Gen(new Microsoft.Xna.Framework.Point(posX + 36+width/6, posY + (height *3/4)-1), new Shapes.Rectangle(1, 1), new Actions.SetTile(TileID.Torches));
            WorldUtils.Gen(new Microsoft.Xna.Framework.Point(posX + (width * 5 / 6) - 36, posY + (height * 3 / 4)-1), new Shapes.Rectangle(1, 1), new Actions.SetTile(TileID.Torches));
            WorldUtils.Gen(new Microsoft.Xna.Framework.Point(posX + 36 + width / 6, posY + height / 4-1), new Shapes.Rectangle(1, 1), new Actions.SetTile(TileID.Torches));
            WorldUtils.Gen(new Microsoft.Xna.Framework.Point(posX + (width * 5 / 6) - 36, posY + height / 4-1), new Shapes.Rectangle(1, 1), new Actions.SetTile(TileID.Torches));

            WorldUtils.Gen(new Microsoft.Xna.Framework.Point(posX + 6, posY + 4), new Shapes.Rectangle(1, 1), new Actions.SetTile(TileID.Torches));
            WorldUtils.Gen(new Microsoft.Xna.Framework.Point(posX + width-7, posY + 4), new Shapes.Rectangle(1, 1), new Actions.SetTile(TileID.Torches));
            WorldUtils.Gen(new Microsoft.Xna.Framework.Point(posX + 6, posY + height - 4), new Shapes.Rectangle(1, 1), new Actions.SetTile(TileID.Torches));
            WorldUtils.Gen(new Microsoft.Xna.Framework.Point(posX + width - 7, posY + height - 4), new Shapes.Rectangle(1, 1), new Actions.SetTile(TileID.Torches));
        }
    }
}
