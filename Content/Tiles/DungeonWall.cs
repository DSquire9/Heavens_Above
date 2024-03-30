using Terraria;
using Terraria.ModLoader;

namespace HeavensAbove.Content.Tiles
{
    public class DungeonWall : ModWall
    {
        public override void SetStaticDefaults()
        {
            Main.tileHammer[Type] = true;
        }
    }
}
