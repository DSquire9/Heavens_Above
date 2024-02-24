using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace HeavensAbove.Content.Items
{
    public class AetherDirt : ModItem
    {
        public override void SetDefaults()
        {
            Item.DefaultToPlaceableTile(ModContent.TileType<Tiles.AetherDirt>());
            Item.width = 12;
            Item.height = 12;
        }
    }
}
