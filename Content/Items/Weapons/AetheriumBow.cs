using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using HeavensAbove.Content.Items.Armor;

namespace HeavensAbove.Content.Items.Weapons
{
    class AetheriumBow : ModItem
    {
        public override void SetStaticDefaults() { }

        //https://terraria.fandom.com/wiki/Titanium_Repeater
        public override void SetDefaults() { }

        public override void AddRecipes()
        {
            Recipe recipe = Recipe.Create(ModContent.ItemType<AetheriumBow>(), 1);

            recipe.AddIngredient<AetheriumBar>(13);

            recipe.AddTile(TileID.MythrilAnvil);

            recipe.Register();
        }

        public override Vector2? HoldoutOffset()
        {
            // TODO: Change for nonplaceholder Art
            return new Vector2(-3.5f, 0);
        }
    }
}
