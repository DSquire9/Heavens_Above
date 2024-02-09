using System.Collections.Generic;
using SubworldLibrary;
using Terraria.DataStructures;
using Terraria.ID;
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
        public override int Width => 1000;
        // World Height
        public override int Height => 1000;

        // World Save Toggle
        public override bool ShouldSave => true;

        // Prevent Player saving toggle
        public override bool NoPlayerSaving => false;

        public override List<GenPass> Tasks => new List<GenPass>()
    {
        new WorldGenPass(),
        new IslandGenPass()
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

/*            for (int i = 0; i < Main.maxTilesX; i++)
            {
                for (int j = Main.maxTilesY / 2+2; j < Main.maxTilesY; j++)
                {
                    progress.Set((j + i * Main.maxTilesY) / (float)(Main.maxTilesX * Main.maxTilesY)); // Controls the progress bar, should only be set between 0f and 1f
                    Tile tile = Main.tile[i, j];
                    tile.HasTile = true;
                    tile.TileType = TileID.Dirt;
                }
            }*/

        }
    }

    public class IslandGenPass : GenPass
    {
        public IslandGenPass() : base("Islands", 1) { }

        protected override void ApplyPass(GenerationProgress progress, GameConfiguration configuration)
        {
            progress.Message = "Generating Islands";
            Island isl = new Island();
            isl.Generate(false);
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
