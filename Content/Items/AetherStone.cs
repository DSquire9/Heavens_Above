﻿using Terraria.ModLoader;
using Terraria;

namespace HeavensAbove.Content.Items
{
    public class AetherStone : ModItem
    {
        public override void SetDefaults()
        {
            Item.DefaultToPlaceableTile(ModContent.TileType<Tiles.AetherStone>());
        }
    }
}
