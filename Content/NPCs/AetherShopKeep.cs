﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HeavensAbove.Content.Items;
using HeavensAbove.Content.Items.Potions;
using HeavensAbove.Content.Items.Weapons;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace HeavensAbove.Content.NPCs
{
    public class AetherShopKeep : ModNPC
    {
        public const string ShopName = "Shop";

        public override void SetStaticDefaults()
        {
            //DisplayName automatically assigned from .lang files, but the commented line below is the normal approach.
            //DisplayName.SetDefault("Aetherian");

        }

        public override void SetDefaults()
        {
            NPC.townNPC = true;
            NPC.friendly = true;
            NPC.width = 20;
            NPC.height = 20;
            NPC.aiStyle = 7;
            NPC.damage = 10;
            NPC.defense = 15;
            NPC.lifeMax = 10000; // This is unreasonably high, just want to ensure this NPC never dies
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;
            NPC.knockBackResist = 0.5f;
            Main.npcFrameCount[NPC.type] = 25;
            NPCID.Sets.ExtraFramesCount[NPC.type] = 9;
            NPCID.Sets.AttackFrameCount[NPC.type] = 4;
            NPCID.Sets.DangerDetectRange[NPC.type] = 700;
            NPCID.Sets.AttackType[NPC.type] = 0;
            NPCID.Sets.AttackTime[NPC.type] = 90;
            NPCID.Sets.AttackAverageChance[NPC.type] = 30;
            NPCID.Sets.HatOffsetY[NPC.type] = 4;
            AnimationType = NPCID.Guide;
        }

        public override void HitEffect(NPC.HitInfo hit)
        {
            //int num = NPC.life > 0 ? 1 : 5;
            //for (int k = 0; k < num; k++)
            //{
            //    Dust.NewDust(NPC.position, NPC.width, NPC.height, ModContent.DustType<Sparkle>());
            //}
        }

        public override bool CanTownNPCSpawn(int numTownNPCs)
        {
            for (int k = 0; k < 255; k++)
            {
                Player player = Main.player[k];
                if (!player.active)
                {
                    continue;
                }

                if (NPC.downedMechBoss1 && NPC.downedMechBoss2 && NPC.downedMechBoss3)
                {
                    return true;
                }
            }
            return false;
        }

        public override List<string> SetNPCNameList()
        {
            return new List<string>()
            {
                "Chad", "Edison"
            };
        }

        // Example Person needs a house built out of ExampleMod tiles. You can delete this whole method in your townNPC for the regular house conditions.
        //public override bool CheckConditions(int left, int right, int top, int bottom)
        //{
        //    int score = 0;
        //    for (int x = left; x <= right; x++)
        //    {
        //        for (int y = top; y <= bottom; y++)
        //        {
        //            int type = Main.tile[x, y].type;
        //            if (type == ModContent.TileType<ExampleBlock>() || type == ModContent.TileType<ExampleChair>() || type == ModContent.TileType<ExampleWorkbench>() || type == ModContent.TileType<ExampleBed>() || type == ModContent.TileType<ExampleDoorOpen>() || type == ModContent.TileType<ExampleDoorClosed>())
        //            {
        //                score++;
        //            }
        //            if (Main.tile[x, y].wall == ModContent.WallType<ExampleWall>())
        //            {
        //                score++;
        //            }
        //        }
        //    }
        //    return score >= (right - left) * (bottom - top) / 2;
        //}

        public override void FindFrame(int frameHeight)
        {
            //NPC.frame.Width = 40;
            //if (((int)Main.time / 10) % 2 == 0)
            //{
            //    NPC.frame.X = 40;
            //}
            //else
            //{
            //    NPC.frame.X = 0;
            //}
        }

        public override string GetChat()
        {
            /*int partyGirl = NPC.FindFirstNPC(NPCID.PartyGirl);
            if (partyGirl >= 0 && Main.rand.NextBool(4))
            {
                return "Can you please tell " + Main.npc[partyGirl].GivenName + " to stop decorating my house with colors?";
            }*/

            switch (Main.rand.Next(3))
            {
                case 0:
                    return "I don't have all day here. Buy something or carry on.";
                case 1:
                    return "You interested in buying something, or are you just going to stand there?";
                default:
                    return "Hurry up! I have other matters to attend to.";
            }

        }

        /* 
		// Consider using this alternate approach to choosing a random thing. Very useful for a variety of use cases.
		// The WeightedRandom class needs "using Terraria.Utilities;" to use
		public override string GetChat()
		{
			WeightedRandom<string> chat = new WeightedRandom<string>();

			int partyGirl = NPC.FindFirstNPC(NPCID.PartyGirl);
			if (partyGirl >= 0 && Main.rand.NextBool(4))
			{
				chat.Add("Can you please tell " + Main.npc[partyGirl].GivenName + " to stop decorating my house with colors?");
			}
			chat.Add("Sometimes I feel like I'm different from everyone else here.");
			chat.Add("What's your favorite color? My favorite colors are white and black.");
			chat.Add("What? I don't have any arms or legs? Oh, don't be ridiculous!");
			chat.Add("This message has a weight of 5, meaning it appears 5 times more often.", 5.0);
			chat.Add("This message has a weight of 0.1, meaning it appears 10 times as rare.", 0.1);
			return chat; // chat is implicitly cast to a string. You can also do "return chat.Get();" if that makes you feel better
		}
		*/

        public override void SetChatButtons(ref string button, ref string button2)
        {
            button = "Chat";
            button2 = "Shop";
        }

        public override void OnChatButtonClicked(bool firstButton, ref string shop)
        {
            if (firstButton)
            {
                switch (Main.rand.Next(4))
                {
                    case 0:
                        Main.npcChatText = "I'd recommend buying some weapons right about now.";
                        break;
                    case 1:
                        Main.npcChatText = "You better buy some more equipment or you're not going to last very long.";
                        break;
                    case 2:
                        Main.npcChatText = "My prices may be expensive, but death is the greatest cost of all.";
                        break;
                    default:
                        Main.npcChatText = "Shopping at night is fine, but I'd advise against mining at night.";
                        break;
                }
            }

            shop = ShopName;
        }


        //public override void NPCLoot()
        //{
        //    Item.NewItem(npc.getRect(), ModContent.ItemType<Items.Armor.ExampleCostume>());
        //}

        // Make this Town NPC teleport to the King and/or Queen statue when triggered.
        public override bool CanGoToStatue(bool toKingStatue)
        {
            return false;
        }

        public override void TownNPCAttackStrength(ref int damage, ref float knockback)
        {
            damage = 20;
            knockback = 4f;
        }

        public override void TownNPCAttackCooldown(ref int cooldown, ref int randExtraCooldown)
        {
            cooldown = 30;
            randExtraCooldown = 30;
        }

        public override void TownNPCAttackProj(ref int projType, ref int attackDelay)
        {
            projType = ProjectileID.WoodenArrowFriendly; // Change this once we have some custom projectiles
            attackDelay = 1;
        }

        public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset)
        {
            multiplier = 12f;
            randomOffset = 2f;
        }

        public override void OnKill()
        {
            Item.NewItem(NPC.GetSource_Death(), NPC.getRect(), ItemID.Acorn, 1, false, 0, false, false);
        }

        public override void AddShops()
        {
            var npcShop = new NPCShop(Type, ShopName)
                .Add(new Item(ModContent.ItemType<AetherDirt>()) { shopCustomPrice = Item.buyPrice(copper: 1) })
                .Add(new Item(ModContent.ItemType<AetherWood>()) { shopCustomPrice = Item.buyPrice(copper: 5) })
                .Add<AetherPotion>()
                .Add<AetheriumBlade>()
                .Add<AetheriumBow>()
                .Add<AetherBloom>()
                .Add<AetherBloomSeeds>();
            npcShop.Register(); // Name of this shop tab
        }

        public override void ModifyActiveShop(string shopName, Item[] items)
        {
            foreach (Item item in items)
            {
                // Skip 'air' items and null items.
                if (item == null || item.type == ItemID.None)
                {
                    continue;
                }

                // If NPC is shimmered then reduce all prices by 50%.
                if (NPC.IsShimmerVariant)
                {
                    int value = item.shopCustomPrice ?? item.value;
                    item.shopCustomPrice = value / 2;
                }
            }
        }
    }
}
