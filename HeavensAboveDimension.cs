using System.Collections.Generic;
using SubworldLibrary;
using Terraria.DataStructures;
using Terraria.IO;
using Terraria.ModLoader;
using Terraria;
using Terraria.WorldBuilding;
using HeavensAbove.Structures;

namespace Heavens_Above
{
    public class HeavensAboveDimension : Subworld
    {
        // World Width
        public override int Width => 2000;
        // World Height
        public override int Height => 2000;

        public static int maxIslands = 20;

        // World Save Toggle
        public override bool ShouldSave => true;

        // Prevent Player saving toggle
        public override bool NoPlayerSaving => false;

        public static List<Island> islands = new List<Island>();

        public override List<GenPass> Tasks => new List<GenPass>()
    {
        new WorldGenPass(),
        new IslandGenPass(),
        new TreePass()
    };
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
            isl.Generate(false);

            for (int i = 0; i < HeavensAboveDimension.maxIslands; i++)
            {
                HeavensAboveDimension.islands.Add(new Island(WorldGen.genRand.Next(0, 3)));
                HeavensAboveDimension.islands[i].Generate(true);
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
