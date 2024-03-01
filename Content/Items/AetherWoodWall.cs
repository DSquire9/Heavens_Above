using Terraria.ModLoader;

namespace HeavensAbove.Content.Items
{
    public class AetherWoodWall : ModItem
    {
        public override void SetDefaults()
        {
            Item.DefaultToPlaceableTile(ModContent.TileType<Tiles.AetherWoodWall>());
        }
    }
}
