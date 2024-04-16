using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria;

namespace HeavensAbove.Content.Items.Armor
{
    [AutoloadEquip(EquipType.Legs)]
    class AetheriumGreaves : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }
        public override void SetDefaults()
        {
            Item.width = 18;
            Item.height = 18;


            Item.value = Item.buyPrice(gold: 1, silver: 80); // Change
            Item.rare = ItemRarityID.LightRed; // Change

            Item.defense = 11; // Change
        }

        public override void UpdateEquip(Player player)
        {
            // Give Buffs Here
            player.moveSpeed += .06f; // Should be 6%
            player.GetCritChance(DamageClass.Generic) += 3; // Adds 3% crit chance
            player.GetDamage(DamageClass.Generic) += .03f;
        }

        public override void AddRecipes()
        {
            Recipe recipe = Recipe.Create(ModContent.ItemType<AetheriumGreaves>(), 1);

            recipe.AddIngredient<AetheriumBar>(20);

            recipe.AddTile(TileID.MythrilAnvil);

            recipe.Register();
        }
    }
}
