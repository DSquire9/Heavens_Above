using Terraria.ModLoader;
using Terraria;

namespace HeavensAbove.Content.Items
{
    internal class AetherStone : ModItem
    {
        public override void SetDefaults()
        {
            Item.DefaultToPlaceableTile(ModContent.TileType<Tiles.AetherStone>());
            Item.width = 12;
            Item.height = 12;
        }
    }
}
