using HeavensAbove;
using Microsoft.Xna.Framework;
using SubworldLibrary;
using System;
using Terraria;
using Terraria.Graphics.Capture;
using Terraria.ID;
using Terraria.ModLoader;

namespace HeavensAbove
{
    public class HeavenBiome : ModBiome
    {
        public override ModSurfaceBackgroundStyle SurfaceBackgroundStyle => ModContent.GetInstance<HeavensSurfaceBackgroundStyle>();
        public override CaptureBiome.TileColorStyle TileColorStyle => CaptureBiome.TileColorStyle.Normal;


        // Populate the Bestiary Filter
        public override string BestiaryIcon => base.BestiaryIcon;
        public override string BackgroundPath => base.BackgroundPath;
        public override Color? BackgroundColor => base.BackgroundColor;
        public override string MapBackground => BackgroundPath; // Re-uses Bestiary Background for Map Background

        // Calculate when the biome is active.
        public override bool IsBiomeActive(Player player)
        {
            if(SubworldSystem.Current != null)
            {
                // We return if the player is in the subdimension
                return SubworldSystem.Current.GetType() == typeof(HeavensAboveDimension);
            }
            return false;
        }

        // Declare biome priority. Since this is our main biome, make the priority high
        public override SceneEffectPriority Priority => SceneEffectPriority.BiomeHigh;
    }

    public class HeavenBiomeTileCount : ModSystem
    {
        public int biomeBlockCount;

        public override void TileCountsAvailable(ReadOnlySpan<int> tileCounts)
        {
            //biomeBlockCount = tileCounts[ModContent.TileType<ModdedBlockTile>()];

            biomeBlockCount = tileCounts[TileID.Cloud];
        }
    }
}