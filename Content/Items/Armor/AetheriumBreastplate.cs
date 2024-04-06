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
    [AutoloadEquip(EquipType.Body)]
    class AetheriumBreastplate : ModItem
    {
        public override void SetStaticDefaults()
        {
            //CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;

            //ArmorIDs.Head.Sets.DrawHead[Item.headSlot] = true;
            //ArmorIDs.Head.Sets.DrawHatHair[Item.headSlot] = true; //???
            //ArmorIDs.Head.Sets.DrawFullHair[Item.headSlot] = false;
        }
        public override void SetDefaults()
        {
            Item.width = 18;
            Item.height = 18;


            Item.value = Item.buyPrice(gold: 2, silver: 40);
            Item.rare = ItemRarityID.LightRed;

            Item.defense = 15; 
        }

        public override void UpdateEquip(Player player)
        {
            // Give Buffs Here
        }

        public override void AddRecipes()
        {
            Recipe recipe = Recipe.Create(ModContent.ItemType<AetheriumBreastplate>(), 1);

            recipe.AddIngredient<AetheriumBar>(26);

            recipe.AddTile(TileID.MythrilAnvil);

            recipe.Register();
        }
    }
}
