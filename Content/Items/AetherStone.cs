using Terraria.ModLoader;
using Terraria;

namespace Heavens_Above.Content.Items
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
