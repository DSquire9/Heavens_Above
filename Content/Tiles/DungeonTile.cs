using Microsoft.Xna.Framework;
using Terraria.ModLoader;
using Terraria;

namespace HeavensAbove.Content.Tiles
{
    public class DungeonTile : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileMergeDirt[Type] = true;
            Main.tileBlockLight[Type] = true;

            AddMapEntry(new Color(200, 200, 200));

            // TODO: Add dungeon tile item so players can have the block
            //RegisterItemDrop(ModContent.ItemType<Items.DungeonTile>(), null);
        }

        public override void NumDust(int i, int j, bool fail, ref int num)
        {
            num = fail ? 1 : 3;
        }
    }
}
