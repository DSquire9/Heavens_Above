using Terraria.ID;
using Terraria.ModLoader;

namespace HeavensAbove.Content.Items
{
    public class AetherBloomSeeds : ModItem
    {
        public override void SetStaticDefaults()
        {
            ItemID.Sets.DisableAutomaticPlaceableDrop[Type] = true; // This prevents this item from being automatically dropped from AetherBloom Tile
            Item.ResearchUnlockCount = 25;
        }

        public override void SetDefaults()
        {
            Item.DefaultToPlaceableTile(ModContent.TileType<Plants.AetherBloom>());
            Item.value = 80;
        }
    }
}
