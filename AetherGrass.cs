using Microsoft.Xna.Framework;
using Terraria.ModLoader;
using Terraria;

namespace Heavens_Above
{
    public class AetherGrass : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileMergeDirt[Type] = true;
            Main.tileBlockLight[Type] = true;

            //DustType = ModContent.DustType<Sparkle>();

            AddMapEntry(new Color(200, 200, 200));
        }

        public override void NumDust(int i, int j, bool fail, ref int num)
        {
            num = fail ? 1 : 3;
        }
    }
}
