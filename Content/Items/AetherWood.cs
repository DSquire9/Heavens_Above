using Terraria.ModLoader;
using Terraria;

namespace HeavensAbove.Content.Items
{
    public class AetherWood : ModItem
    {
        public override void SetDefaults()
        {
            Item.DefaultToPlaceableTile(ModContent.TileType<Tiles.AetherWood>());
            Item.width = 12;
            Item.height = 12;
        }
    }
}
