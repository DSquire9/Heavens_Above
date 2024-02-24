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

namespace HeavensAbove.Content.Items.Weapons
{
    class AetheriumBow : ModItem
    {
        public override void SetStaticDefaults() { }

        public override void SetDefaults() { }

        public override void AddRecipes()
        {
            // TODO: Add Recipe
        }

        public override Vector2? HoldoutOffset()
        {
            // TODO: Change for nonplaceholder Art
            return new Vector2(-3.5f, 0);
        }
    }
}
