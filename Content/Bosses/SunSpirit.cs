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
using HeavensAbove.Conent.Bosses;
using Terraria.Audio;
using Terraria.Graphics.CameraModifiers;

namespace HeavensAbove.Content.Bosses
{
    [AutoloadBossHead]
    public class SunSpirit : ModNPC
    {
        private int[] fireEnemies = { 23, 59, 151, 277, 278, 279, 280, 418 };
        private int awake = 0;
        private int phaseOneTimer = 0;
        private Random random = new Random();
        public Vector2 FirstStageDestination
        {
            get => new Vector2(NPC.ai[1], NPC.ai[2]);
            set
            {
                NPC.ai[1] = value.X;
                NPC.ai[2] = value.Y;
            }
        }
        public Vector2 LastFirstStageDestination { get; set; } = Vector2.Zero;

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


            NPC.aiStyle = -1;
            //AnimationType = NPCID.EyeofCthulhu;

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

             public override void OnKill()
             {
                 // This sets downedMinionBoss to true, and if it was false before, it initiates a lantern night
                 NPC.SetEventFlagCleared(ref DownedBossSystem.downedSunSpirit, -1);

                 // Since this hook is only ran in singleplayer and serverside, we would have to sync it manually.
                 // Thankfully, vanilla sends the MessageID.WorldData packet if a BOSS was killed automatically, shortly after this hook is ran

                 // If your NPC is not a boss and you need to sync the world (which includes ModSystem, check DownedBossSystem), use this code:
                 /*
                  * if (Main.netMode == NetmodeID.Server) {
                  * NetMessage.SendData(MessageID.WorldData);
                  * }
                  * */
             }

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

        public override void AI()
        {
            // This should almost always be the first code in AI() as it is responsible for finding the proper player target
            if (NPC.target < 0 || NPC.target == 255 || Main.player[NPC.target].dead || !Main.player[NPC.target].active)
            {
                NPC.TargetClosest();
            }

            Player player = Main.player[NPC.target];

            if (player.dead)
            {
                // If the targeted player is dead, flee
                NPC.velocity.Y -= 0.04f;
                // This method makes it so when the boss is in "despawn range" (outside of the screen), it despawns in 10 ticks
                NPC.EncourageDespawn(10);
                return;
            }

            //SpawnMinions();

            if (NPC.life > NPC.lifeMax * .75)
            {
                PhaseOne(player);
            }
            else if (NPC.life > NPC.lifeMax * .3)
            {
                PhaseTwo(player);
            }
            else
            {
                PhaseThree(player);
            }
        }

        private void PhaseOne(Player player)
        {
            if (awake < 6)
            {
                SpawnNPCFromBoss(72);
                awake++;
            }

            // Spawn different enemies on a weighted chance
            if (phaseOneTimer == 60)
            {
                WeightedSpawn();
            }

            float distance = 200; // Distance in pixels behind the player

            if (phaseOneTimer == 60)
            {
                Vector2 fromPlayer = NPC.Center - player.Center;

                if (Main.netMode != NetmodeID.MultiplayerClient)
                {
                    // Important multiplayer consideration: drastic change in behavior (that is also decided by randomness) like this requires
                    // to be executed on the server (or singleplayer) to keep the boss in sync

                    float angle = fromPlayer.ToRotation();
                    float twelfth = MathHelper.Pi / 6;

                    angle += MathHelper.Pi + Main.rand.NextFloat(-twelfth, twelfth);
                    if (angle > MathHelper.TwoPi)
                    {
                        angle -= MathHelper.TwoPi;
                    }
                    else if (angle < 0)
                    {
                        angle += MathHelper.TwoPi;
                    }

                    Vector2 relativeDestination = angle.ToRotationVector2() * distance;

                    FirstStageDestination = player.Center + relativeDestination;
                    NPC.netUpdate = true;
                }

                // Move along the vector
                Vector2 toDestination = FirstStageDestination - NPC.Center;
                Vector2 toDestinationNormalized = toDestination.SafeNormalize(Vector2.UnitY);
                float speed = Math.Min(distance, toDestination.Length());
                NPC.velocity = toDestinationNormalized * speed / 30;

                if (FirstStageDestination != LastFirstStageDestination)
                {
                    // If destination changed
                    NPC.TargetClosest(); // Pick the closest player target again

                    // "Why is this not in the same code that sets FirstStageDestination?" Because in multiplayer it's ran by the server.
                    // The client has to know when the destination changes a different way. Keeping track of the previous ticks' destination is one way
                    if (Main.netMode != NetmodeID.Server)
                    {
                        // For visuals regarding NPC position, netOffset has to be concidered to make visuals align properly
                        NPC.position += NPC.netOffset;

                        // Draw a line between the NPC and its destination, represented as dusts every 20 pixels
                        Dust.QuickDustLine(NPC.Center + toDestinationNormalized * NPC.width, FirstStageDestination, toDestination.Length() / 20f, Color.OrangeRed);

                        NPC.position -= NPC.netOffset;
                    }
                }
                LastFirstStageDestination = FirstStageDestination;

                phaseOneTimer = 0;
            }

            phaseOneTimer++;
        }

        private void PhaseTwo(Player player)
        {
            // Chase player with some projectiles
        }

        private void PhaseThree(Player player)
        {
            // Circle Player and spew random bullshit
        }

        private void SpawnNPCFromBoss(int id)
        {
            var entitySource = NPC.GetSource_FromAI();

            NPC minionNPC = NPC.NewNPCDirect(entitySource, (int)NPC.Center.X, (int)NPC.Center.Y, id, NPC.whoAmI);

            if (Main.netMode == NetmodeID.Server)
            {
                NetMessage.SendData(MessageID.SyncNPC, number: minionNPC.whoAmI);
            }
        }

        private void WeightedSpawn()
        {
            int roll = random.Next(50);

            if (roll < 10)
            {
                SpawnNPCFromBoss(fireEnemies[0]);
            }
            else if (roll < 20)
            {
                SpawnNPCFromBoss(fireEnemies[1]);
            }
            else if (roll < 30)
            {
                SpawnNPCFromBoss(fireEnemies[2]);
            }
            else if (roll < 40)
            {
                SpawnNPCFromBoss(fireEnemies[3]);
            }
            else if (roll < 43)
            {
                SpawnNPCFromBoss(fireEnemies[4]);
            }
            else if (roll < 45)
            {
                SpawnNPCFromBoss(fireEnemies[5]);
            }
            else
            {
                SpawnNPCFromBoss(fireEnemies[6]);
            }

        }
    }
}
