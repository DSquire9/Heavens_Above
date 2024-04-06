using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria;
using Terraria.ModLoader;
using Terraria.ModLoader.Utilities;
using Terraria.GameContent.ItemDropRules;
using HeavensAbove.Content.Items;
using HeavensAbove.Content.Items.Accessories;
using Terraria.Audio;
using Terraria.Graphics.CameraModifiers;

namespace HeavensAbove.Content.Bosses
{
    [AutoloadBossHead]
    public class SunSpirit : ModNPC
    {
        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[Type] = 8;

            // Add this in for bosses that have a summon item, requires corresponding code in the item (See MinionBossSummonItem.cs)
            //NPCID.Sets.MPAllowedEnemies[Type] = true;

            // Automatically group with other bosses
            NPCID.Sets.BossBestiaryPriority.Add(Type);

            NPCID.Sets.SpecificDebuffImmunity[Type][BuffID.Poisoned] = true;
            NPCID.Sets.SpecificDebuffImmunity[Type][BuffID.Confused] = true;
            NPCID.Sets.SpecificDebuffImmunity[Type][BuffID.OnFire] = true;

            // Influences how the NPC looks in the Bestiary
            //NPCID.Sets.NPCBestiaryDrawModifiers drawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers()
            //{
            //    CustomTexturePath = "ExampleMod/Assets/Textures/Bestiary/MinionBoss_Preview",
            //    PortraitScale = 0.6f, // Portrait refers to the full picture when clicking on the icon in the bestiary
            //    PortraitPositionYOverride = 0f,
            //};
            //NPCID.Sets.NPCBestiaryDrawOffset.Add(Type, drawModifiers);
        }

        public override void SetDefaults()
        {
            NPC.width = 100;
            NPC.height = 100;
            NPC.damage = 12;
            NPC.defense = 10;
            NPC.lifeMax = 2000;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;
            NPC.knockBackResist = 0f;
            NPC.noGravity = true;
            NPC.noTileCollide = true;
            NPC.value = Item.buyPrice(gold: 5);
            NPC.SpawnWithHigherTime(30);
            NPC.boss = true;
            NPC.npcSlots = 10f; // Take up open spawn slots, preventing random NPCs from spawning during the fight


            NPC.aiStyle = NPCID.EyeofCthulhu;
            AnimationType = NPCID.EyeofCthulhu;

            // Custom boss bar
            //NPC.BossBar = ModContent.GetInstance<MinionBossBossBar>();

            // The following code assigns a music track to the boss in a simple way.
            if (!Main.dedServ)
            {
                Music = MusicID.Boss2;
            }
        }

        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            // Do NOT misuse the ModifyNPCLoot and OnKill hooks: the former is only used for registering drops, the latter for everything else

            // The order in which you add loot will appear as such in the Bestiary. To mirror vanilla boss order:
            // 1. Trophy
            // 2. Classic Mode ("not expert")
            // 3. Expert Mode (usually just the treasure bag)
            // 4. Master Mode (relic first, pet last, everything else inbetween)

            // Trophies are spawned with 1/10 chance
            //npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Placeable.Furniture.MinionBossTrophy>(), 10));

            // All the Classic Mode drops here are based on "not expert", meaning we use .OnSuccess() to add them into the rule, which then gets added
            LeadingConditionRule notExpertRule = new LeadingConditionRule(new Conditions.DownedAllMechBosses());

            // Notice we use notExpertRule.OnSuccess instead of npcLoot.Add so it only applies in normal mode
            // Boss masks are spawned with 1/7 chance
            //notExpertRule.OnSuccess(ItemDropRule.Common(ModContent.ItemType<MinionBossMask>(), 7));

            // This part is not required for a boss and is just showcasing some advanced stuff you can do with drop rules to control how items spawn
            // We make 12-15 ExampleItems spawn randomly in all directions, like the lunar pillar fragments. Hereby we need the DropOneByOne rule,
            // which requires these parameters to be defined
            int itemType = ModContent.ItemType<AetheriumBar>();
            var parameters = new DropOneByOne.Parameters()
            {
                ChanceNumerator = 1,
                ChanceDenominator = 1,
                MinimumStackPerChunkBase = 1,
                MaximumStackPerChunkBase = 1,
                MinimumItemDropsCount = 12,
                MaximumItemDropsCount = 15,
            };

            notExpertRule.OnSuccess(new DropOneByOne(itemType, parameters));

            // Finally add the leading rule
            npcLoot.Add(notExpertRule);

            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<IcarianWings>(), 1, 1, 1));

            // Add the treasure bag using ItemDropRule.BossBag (automatically checks for expert mode)
            //npcLoot.Add(ItemDropRule.BossBag(ModContent.ItemType<MinionBossBag>()));

            // ItemDropRule.MasterModeCommonDrop for the relic
            //npcLoot.Add(ItemDropRule.MasterModeCommonDrop(ModContent.ItemType<Items.Placeable.Furniture.MinionBossRelic>()));

            // ItemDropRule.MasterModeDropOnAllPlayers for the pet
            //npcLoot.Add(ItemDropRule.MasterModeDropOnAllPlayers(ModContent.ItemType<MinionBossPetItem>(), 4));
        }

        //     public override void OnKill()
        //     {
        //         // This sets downedMinionBoss to true, and if it was false before, it initiates a lantern night
        //         NPC.SetEventFlagCleared(ref DownedBossSystem.downedMinionBoss, -1);

        //         // Since this hook is only ran in singleplayer and serverside, we would have to sync it manually.
        //         // Thankfully, vanilla sends the MessageID.WorldData packet if a BOSS was killed automatically, shortly after this hook is ran

        //         // If your NPC is not a boss and you need to sync the world (which includes ModSystem, check DownedBossSystem), use this code:
        //         /*
        //if (Main.netMode == NetmodeID.Server) {
        //	NetMessage.SendData(MessageID.WorldData);
        //}
        //*/
        //     }

        public override void BossLoot(ref string name, ref int potionType)
        {
            potionType = ItemID.GreaterHealingPotion;
        }

        public override bool CanHitPlayer(Player target, ref int cooldownSlot)
        {
            cooldownSlot = ImmunityCooldownID.Bosses; // use the boss immunity cooldown counter, to prevent ignoring boss attacks by taking damage from other sources
            return true;
        }

        //public override void FindFrame(int frameHeight)
        //{
        //    // This NPC animates with a simple "go from start frame to final frame, and loop back to start frame" rule
        //    // In this case: First stage: 0-1-2-0-1-2, Second stage: 3-4-5-3-4-5, 5 being "total frame count - 1"
        //    int startFrame = 0;
        //    int finalFrame = 2;

        //    int frameSpeed = 5;
        //    NPC.frameCounter += 0.5f;
        //    NPC.frameCounter += NPC.velocity.Length() / 10f; // Make the counter go faster with more movement speed
        //    if (NPC.frameCounter > frameSpeed)
        //    {
        //        NPC.frameCounter = 0;
        //        NPC.frame.Y += frameHeight;

        //        if (NPC.frame.Y > finalFrame * frameHeight)
        //        {
        //            NPC.frame.Y = startFrame * frameHeight;
        //        }
        //    }
        //}

        public override void HitEffect(NPC.HitInfo hit)
        {
            // If the NPC dies, spawn gore and play a sound
            if (Main.netMode == NetmodeID.Server)
            {
                // We don't want Mod.Find<ModGore> to run on servers as it will crash because gores are not loaded on servers
                return;
            }

            if (NPC.life <= 0)
            {
                SoundEngine.PlaySound(SoundID.Roar, NPC.Center);

                // This adds a screen shake (screenshake) similar to Deerclops
                PunchCameraModifier modifier = new PunchCameraModifier(NPC.Center, (Main.rand.NextFloat() * ((float)Math.PI * 2f)).ToRotationVector2(), 20f, 6f, 20, 1000f, FullName);
                Main.instance.CameraModifiers.Add(modifier);
            }
        }
    }
}
