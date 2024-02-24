using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace HeavensAbove.Content.Tiles
{
    public class AetherStone : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileMergeDirt[Type] = true;
            Main.tileBlockLight[Type] = true;
            Main.tileStone[Type] = true;

            //DustType = ModContent.DustType<Sparkle>();

            AddMapEntry(new Color(200, 200, 200));
            RegisterItemDrop(ModContent.ItemType<Items.AetherStone>(), null);
        }

        public override void NumDust(int i, int j, bool fail, ref int num)
        {
            num = fail ? 1 : 3;
        }
    }
}
