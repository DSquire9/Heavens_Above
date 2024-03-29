﻿using Microsoft.Xna.Framework;
using Terraria.ModLoader;
using Terraria;

namespace HeavensAbove.Content.Tiles
{
    public class AetherGrass : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileMerge[Type][ModContent.TileType<Tiles.AetherDirt>()] = true;
            Main.tileBlockLight[Type] = true;

            AddMapEntry(new Color(200, 200, 200));

            RegisterItemDrop(ModContent.ItemType<Items.AetherDirt>(), null);
        }

        public override void NumDust(int i, int j, bool fail, ref int num)
        {
            num = fail ? 1 : 3;
        }
    }
}
