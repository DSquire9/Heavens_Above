using Terraria.ModLoader;
using Terraria;
using Terraria.ID;

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

        public override void AddRecipes()
        {
            Recipe workbench = Recipe.Create(ItemID.WorkBench, 1);

            workbench.AddIngredient<Items.AetherWood>(10);

            workbench.Register();


            Recipe platforms = Recipe.Create(ItemID.WoodPlatform, 2);

            workbench.AddIngredient<Items.AetherWood>(1);

            workbench.Register();
        }
    }
}
