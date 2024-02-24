using System.Collections.Generic;
using SubworldLibrary;
using Terraria.DataStructures;
using Terraria.IO;
using Terraria.ModLoader;
using Terraria;
using Terraria.WorldBuilding;
using HeavensAbove.Structures;
using Terraria.ID;

namespace HeavensAbove
{
    public class HeavensAboveDimension : Subworld
    {
        // World Width
        public override int Width => 2000;
        // World Height
        public override int Height => 2000;

        public static int maxIslands = 20;

        public static int numStructures = 3;

        // World Save Toggle
        public override bool ShouldSave => true;

        // Prevent Player saving toggle
        public override bool NoPlayerSaving => false;

        public override string Name => "HeavensAbove";

        public static List<Island> islands = new List<Island>();

        public static List<Structure> structures = new List<Structure>();

        public override List<GenPass> Tasks => new List<GenPass>()
    {
        new WorldGenPass(),
        new IslandGenPass(),
        new StructurePass(),
        new TreePass()
    };

        // Sets the time to the middle of the day whenever the subworld loads
        public override void OnLoad()
        {
            Main.dayTime = true;
            Main.time = 27000;
        }
    }

    // Currently generates half the world as dirt below the player
    // MaxTilesY is the bottom-most block placement in the world
    public class WorldGenPass : GenPass
    {
        public WorldGenPass() : base("Terrain", 1) { }

        protected override void ApplyPass(GenerationProgress progress, GameConfiguration configuration)
        {
            progress.Message = "Generating terrain"; // Sets the text displayed for this pass
            Main.worldSurface = Main.maxTilesY - 42; // Hides the underground layer just out of bounds
            Main.rockLayer = Main.maxTilesY + 100; // Hides the cavern layer way out of bounds
        }
    }

    public class IslandGenPass : GenPass
    {
        public IslandGenPass() : base("Terrain", 1) { }

        protected override void ApplyPass(GenerationProgress progress, GameConfiguration configuration)
        {
            progress.Message = "Generating Islands";
            // Guarantees the player spawns on a weird little island despite any random gen
            Island isl = new Island(0);
            HeavensAboveDimension.islands.Add(isl);
            isl.Generate(false);

            for (int i = 0; i < HeavensAboveDimension.maxIslands; i++)
            {
                HeavensAboveDimension.islands.Add(new Island(WorldGen.genRand.Next(0, 3)));
                HeavensAboveDimension.islands[i].Generate(true);
            }
        }
    }

    public class StructurePass : GenPass
    {
        public StructurePass() : base("Generating Structures", 1) { }

        protected override void ApplyPass(GenerationProgress progress, GameConfiguration configuration)
        {
            List<Island> islandsWithStrucutres = new List<Island>();
            for(int i = 0; i < HeavensAboveDimension.numStructures; i++)
            {
                // Gets a random island
                Island islPlace = null;
                do
                {
                    islPlace = HeavensAboveDimension.islands[WorldGen.genRand.Next(0, HeavensAboveDimension.maxIslands)];
                }
                while (islandsWithStrucutres.Contains(islPlace));

                islandsWithStrucutres.Add(islPlace);

                // Gets its centered placement
                int xPlacement = islPlace.GetMiddleX() - StructureData.testStructure.GetLength(1);
                int yPlacement = islPlace.GetMiddleY() + StructureData.testStructure.GetLength(0);

                System.Console.WriteLine("Placing a Structure at: " + xPlacement + " " + yPlacement);

                // Checks to see if it can be placed on top of the island
                Tile t = Main.tile[xPlacement, yPlacement];
                while (t.HasTile)
                {
                    //System.Console.WriteLine("Checking for empty tile!");
                    yPlacement--;
                    t = Main.tile[xPlacement, yPlacement];
                }

                HeavensAboveDimension.structures.Add(new Structure(xPlacement, yPlacement, 0));

                HeavensAboveDimension.structures[i].Generate();
            }
        }
    }

    // Creates trees on grass blocks
    public class TreePass : GenPass
    {
        public TreePass() : base("Planting Trees", 1) { }
        protected override void ApplyPass(GenerationProgress progress, GameConfiguration configuration)
        {
            progress.Message = "Planting Trees";
            WorldGen.AddTrees(false);
        }
    }

    public class UpdateSubworldSystem : ModSystem
    {
        public override void PreUpdateWorld()
        {
            if (SubworldSystem.IsActive<HeavensAboveDimension>())
            {
                // Update mechanisms
                Wiring.UpdateMech();

                // Update tile entities
                TileEntity.UpdateStart();
                foreach (TileEntity te in TileEntity.ByID.Values)
                {
                    te.Update();
                }
                TileEntity.UpdateEnd();

                // Update liquid
                if (++Liquid.skipCount > 1)
                {
                    Liquid.UpdateLiquid();
                    Liquid.skipCount = 0;
                }
            }
        }
    }
}
