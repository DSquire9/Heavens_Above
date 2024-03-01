using Terraria;
using Terraria.ModLoader;

namespace HeavensAbove.Content.Tiles
{
    public class AetherWoodWall : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileHammer[Type] = true;
        }
    }
}
