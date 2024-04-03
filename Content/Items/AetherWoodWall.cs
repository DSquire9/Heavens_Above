using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria;
using Terraria.ModLoader;

namespace HeavensAbove.Content.Items
{
    public class AetherWoodWall : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 400;
        }
        public override void SetDefaults()
        {
            Item.DefaultToPlaceableTile(ModContent.TileType<Tiles.AetherWoodWall>());
        }

        public override void AddRecipes()
        {
            Recipe recipe = Recipe.Create(ModContent.ItemType<Items.AetherWoodWall>(), 4);

            recipe.AddIngredient<Items.AetherWood>();

            recipe.AddTile(TileID.WorkBenches);

            recipe.Register();
        }
    }
}
