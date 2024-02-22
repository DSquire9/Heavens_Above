using Terraria;
using Terraria.WorldBuilding;
using Microsoft.Xna.Framework;
using ReLogic.Utilities;
using Terraria.GameContent.Generation;
using Terraria.ID;
using Terraria.GameContent.Biomes;

namespace HeavensAbove.Structures
{
    public class Island
    {
        int islandWidth;
        int islandHeight;
        // Offsets from WorldSpawn
        int offsetX;
        int offsetY;
        int islandType;
        public Island(int islandType = -1,int x = 0, int y = 0)
        {
            offsetX = x;
            offsetY = y;
            this.islandType = islandType;

            switch (islandType)
            {
                case 0:
                    islandWidth = 50;
                    islandHeight = 30;
                    break;
                case 1:
                    islandWidth = 100;
                    islandHeight = 80;
                    break;
                case 2:
                default:
                    islandWidth = 160;
                    islandHeight = 100;
                    break;
            }
        }

        public int GetMiddleX()
        {
            return offsetX;
        }
        public int GetMiddleY()
        {
            return offsetY;
        }

        // Currently generates a dirt island based on the island size type
        public void Generate(bool isRand)
        {
            if (isRand)
            {
                // Picks a point on the first half of the map
                offsetX += WorldGen.genRand.Next(Main.maxTilesX/5, Main.maxTilesX * 5/12);
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
                offsetX += Main.maxTilesX / 2;
                offsetY += (int)Main.maxTilesY /2;
            }

            switch (islandType)
            {
                // Small island
                case 0:

                    ShapeData shapeData = new ShapeData();
                    ShapeData shapeData2 = new ShapeData();

                    Point point = new Point(offsetX, offsetY + WorldGen.genRand.Next(10, 20));
                    Point point2 = new Point(offsetX + WorldGen.genRand.Next(10, islandWidth / 2), offsetY + WorldGen.genRand.Next(islandHeight+4, islandHeight+15));
                    Point point3 = new Point(offsetX - WorldGen.genRand.Next(10, islandWidth / 2), offsetY + WorldGen.genRand.Next(islandHeight + 4, islandHeight + 15));
                    Point point4 = new Point(offsetX + WorldGen.genRand.Next(0, 10), offsetY + WorldGen.genRand.Next(islandHeight + 4, islandHeight + 15));
                    Point point5 = new Point(offsetX - islandWidth / 2, point.Y);
                    Point point6 = new Point(offsetX - WorldGen.genRand.Next(10, islandWidth/2), offsetY + WorldGen.genRand.Next(islandHeight + 4, islandHeight + 15));
                    int islandScale = 5;
                    int islandRadius = (islandWidth / 2) / islandScale;

                    WorldUtils.Gen(point, new Shapes.Slime(islandRadius, islandScale, WorldGen.genRand.Next(1, 3) * 0.6), Actions.Chain(new Modifiers.Blotches(WorldGen.genRand.Next(2, 6), 0.6), new Actions.SetTile(0), new Actions.SetFrames(frameNeighbors: true).Output(shapeData)));
                    WorldUtils.Gen(point, new ModShapes.OuterOutline(shapeData), Actions.Chain(new Actions.SetTile(2), new Actions.SetFrames(frameNeighbors: true)));
                    WorldUtils.Gen(point, new ModShapes.All(shapeData), Actions.Chain(new Modifiers.Offset(0, -1), new Modifiers.OnlyTiles(2), new Modifiers.Offset(0, -1), new ActionGrass()));

                    WorldUtils.Gen(point5, new Shapes.Rectangle(islandWidth, WorldGen.genRand.Next(15, islandHeight)), Actions.Chain(new Modifiers.Blotches(WorldGen.genRand.Next(2, 6), 0.6), new Actions.SetTile(TileID.Cloud), new Actions.SetFrames(frameNeighbors: true).Output(shapeData)));
                    WorldUtils.Gen(point2, new Shapes.Mound(WorldGen.genRand.Next(4, 9), WorldGen.genRand.Next(10, 25)), Actions.Chain(new Modifiers.Blotches(WorldGen.genRand.Next(2, 6), 0.6), new Actions.ClearTile(), new Actions.SetFrames(frameNeighbors: true).Output(shapeData2)));
                    WorldUtils.Gen(point3, new Shapes.Mound(WorldGen.genRand.Next(8, 15), WorldGen.genRand.Next(20, 35)), Actions.Chain(new Modifiers.Blotches(WorldGen.genRand.Next(2, 6), 0.6), new Actions.ClearTile(), new Actions.SetFrames(frameNeighbors: true).Output(shapeData2)));
                    WorldUtils.Gen(point4, new Shapes.Mound(WorldGen.genRand.Next(5, 10), WorldGen.genRand.Next(8, 15)), Actions.Chain(new Modifiers.Blotches(WorldGen.genRand.Next(2, 6), 0.6), new Actions.ClearTile(), new Actions.SetFrames(frameNeighbors: true).Output(shapeData2)));
                    WorldUtils.Gen(point6, new Shapes.Mound(WorldGen.genRand.Next(3, 10), WorldGen.genRand.Next(10, 25)), Actions.Chain(new Modifiers.Blotches(WorldGen.genRand.Next(4, 8), 0.8), new Actions.ClearTile(), new Actions.SetFrames(frameNeighbors: true).Output(shapeData2)));
                    break;
                // Medium Island
                case 1:

                    shapeData = new ShapeData();
                    shapeData2 = new ShapeData();

                    point = new Point(offsetX, offsetY + WorldGen.genRand.Next(10, 20));
                    point2 = new Point(offsetX + WorldGen.genRand.Next(15, islandWidth / 2), offsetY + WorldGen.genRand.Next(islandHeight + 4, islandHeight + 8));
                    point3 = new Point(offsetX - WorldGen.genRand.Next(15, islandWidth / 2), offsetY + WorldGen.genRand.Next(islandHeight + 4, islandHeight + 8));
                    point4 = new Point(offsetX + WorldGen.genRand.Next(-10, 15), offsetY + WorldGen.genRand.Next(islandHeight + 4, islandHeight + 8));
                    point5 = new Point(offsetX - islandWidth / 2, point.Y);
                    point6 = new Point(offsetX - WorldGen.genRand.Next(15, islandWidth / 2), offsetY + WorldGen.genRand.Next(islandHeight + 4, islandHeight + 8));
                    islandScale = 5;
                    islandRadius = (islandWidth / 2) / islandScale;

                    WorldUtils.Gen(point, new Shapes.Slime(islandRadius, islandScale, WorldGen.genRand.Next(1, 3) * 0.6), Actions.Chain(new Modifiers.Blotches(WorldGen.genRand.Next(2, 6), 0.6), new Actions.SetTile(0), new Actions.SetFrames(frameNeighbors: true).Output(shapeData)));
                    WorldUtils.Gen(point, new ModShapes.OuterOutline(shapeData), Actions.Chain(new Actions.SetTile(2), new Actions.SetFrames(frameNeighbors: true)));
                    WorldUtils.Gen(point, new ModShapes.All(shapeData), Actions.Chain(new Modifiers.Offset(0, -1), new Modifiers.OnlyTiles(2), new Modifiers.Offset(0, -1), new ActionGrass()));

                    WorldUtils.Gen(point5, new Shapes.Rectangle(islandWidth, WorldGen.genRand.Next(45, islandHeight)), Actions.Chain(new Modifiers.Blotches(WorldGen.genRand.Next(2, 6), 0.6), new Actions.SetTile(0), new Actions.SetFrames(frameNeighbors: true).Output(shapeData)));
                    WorldUtils.Gen(point2, new Shapes.Mound(WorldGen.genRand.Next(15, 25), WorldGen.genRand.Next(30, 45)), Actions.Chain(new Modifiers.Blotches(WorldGen.genRand.Next(2, 6), 0.6), new Actions.ClearTile(), new Actions.SetFrames(frameNeighbors: true).Output(shapeData2)));
                    WorldUtils.Gen(point3, new Shapes.Mound(WorldGen.genRand.Next(12, 25), WorldGen.genRand.Next(40, 55)), Actions.Chain(new Modifiers.Blotches(WorldGen.genRand.Next(2, 6), 0.6), new Actions.ClearTile(), new Actions.SetFrames(frameNeighbors: true).Output(shapeData2)));
                    WorldUtils.Gen(point4, new Shapes.Mound(WorldGen.genRand.Next(8, 20), WorldGen.genRand.Next(20, 35)), Actions.Chain(new Modifiers.Blotches(WorldGen.genRand.Next(2, 6), 0.6), new Actions.ClearTile(), new Actions.SetFrames(frameNeighbors: true).Output(shapeData2)));
                    WorldUtils.Gen(point6, new Shapes.Mound(WorldGen.genRand.Next(9, 15), WorldGen.genRand.Next(30, 45)), Actions.Chain(new Modifiers.Blotches(WorldGen.genRand.Next(4, 8), 0.8), new Actions.ClearTile(), new Actions.SetFrames(frameNeighbors: true).Output(shapeData2)));
                    break;
                // Large island
                case 2:
                default:

                    shapeData = new ShapeData();
                    shapeData2 = new ShapeData();

                    point = new Point(offsetX, offsetY + WorldGen.genRand.Next(10, 20));
                    point2 = new Point(offsetX + WorldGen.genRand.Next(40, 70), offsetY + WorldGen.genRand.Next(80, 90));
                    point3 = new Point(offsetX - WorldGen.genRand.Next(60, 80), offsetY + WorldGen.genRand.Next(80, 90));
                    point4 = new Point(offsetX + WorldGen.genRand.Next(0, 10), offsetY + WorldGen.genRand.Next(80, 90));
                    point5 = new Point(offsetX-islandWidth/2, point.Y);
                    point6 = new Point(offsetX - WorldGen.genRand.Next(20, 30), offsetY + WorldGen.genRand.Next(80, 90));
                    islandScale = 5;
                    islandRadius = (islandWidth / 2) / islandScale;

                    WorldUtils.Gen(point, new Shapes.Slime(islandRadius, islandScale, WorldGen.genRand.Next(1,3)*0.6), Actions.Chain(new Modifiers.Blotches(WorldGen.genRand.Next(2, 6), 0.6), new Actions.SetTile(0), new Actions.SetFrames(frameNeighbors: true).Output(shapeData)));
                    WorldUtils.Gen(point, new ModShapes.OuterOutline(shapeData), Actions.Chain(new Actions.SetTile(2), new Actions.SetFrames(frameNeighbors: true)));
                    WorldUtils.Gen(point, new ModShapes.All(shapeData), Actions.Chain(new Modifiers.Offset(0, -1), new Modifiers.OnlyTiles(2), new Modifiers.Offset(0, -1), new ActionGrass()));

                    WorldUtils.Gen(point5, new Shapes.Rectangle(islandWidth, WorldGen.genRand.Next(40, 70)), Actions.Chain(new Modifiers.Blotches(WorldGen.genRand.Next(2, 6), 0.6), new Actions.SetTile(0), new Actions.SetFrames(frameNeighbors: true).Output(shapeData)));
                    WorldUtils.Gen(point2, new Shapes.Mound(WorldGen.genRand.Next(18, 28), WorldGen.genRand.Next(40, 55)), Actions.Chain(new Modifiers.Blotches(WorldGen.genRand.Next(2, 6), 0.6), new Actions.ClearTile(), new Actions.SetFrames(frameNeighbors: true).Output(shapeData2)));
                    WorldUtils.Gen(point3, new Shapes.Mound(WorldGen.genRand.Next(40, 55), WorldGen.genRand.Next(50, 65)), Actions.Chain(new Modifiers.Blotches(WorldGen.genRand.Next(2, 6), 0.6), new Actions.ClearTile(), new Actions.SetFrames(frameNeighbors: true).Output(shapeData2)));
                    WorldUtils.Gen(point4, new Shapes.Mound(WorldGen.genRand.Next(20, 25), WorldGen.genRand.Next(20, 35)), Actions.Chain(new Modifiers.Blotches(WorldGen.genRand.Next(2, 6), 0.6), new Actions.ClearTile(), new Actions.SetFrames(frameNeighbors: true).Output(shapeData2)));
                    WorldUtils.Gen(point6, new Shapes.Mound(WorldGen.genRand.Next(16, 20), WorldGen.genRand.Next(30, 45)), Actions.Chain(new Modifiers.Blotches(WorldGen.genRand.Next(4, 8), 0.8), new Actions.ClearTile(), new Actions.SetFrames(frameNeighbors: true).Output(shapeData2)));
                    break;
            }
        }
    }
}
