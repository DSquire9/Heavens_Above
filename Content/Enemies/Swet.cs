using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ID;
using Terraria;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.ItemDropRules;
using Terraria.ModLoader;
using Terraria.ModLoader.Utilities;
using HeavensAbove.Content.Items;
using HeavensAbove.Content.Items.Weapons;

namespace HeavensAbove.Content.Enemies
{
    public class Swet : ModNPC
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Swet");
            Main.npcFrameCount[NPC.type] = 4;
        }

        public override void SetDefaults()
        {
            // Change stats
            NPC.width = 18;
            NPC.height = 20;
            NPC.damage = 14;
            NPC.defense = 6;
            NPC.lifeMax = 200;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath2;
            NPC.value = 60f;
            NPC.knockBackResist = 0.5f;
            NPC.aiStyle = NPCID.BlueSlime;
            AIType = NPCID.BlueSlime;
            AnimationType = NPCID.BlueSlime;
            Banner = Item.NPCtoBanner(NPCID.BlueSlime);
            BannerItem = Item.BannerToItem(Banner);

            SpawnModBiomes = new int[1] { ModContent.GetInstance<HeavenBiome>().Type };
        }

        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            var slimeDropRules = Main.ItemDropsDB.GetRulesForNPCID(NPCID.BlueSlime, false); // false is important here
            foreach (var slimeDropRule in slimeDropRules)
            {
                npcLoot.Add(slimeDropRule);
            }

            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<AetheriumOre>(), 5, 2, 6)); // 20% (1 in 5) chance to drop 2-6 Aetherium ore
        }

        //public override float SpawnChance(NPCSpawnInfo spawnInfo)
        //{
        //    return SpawnCondition.OverworldNightMonster.Chance * 0.2f; // Spawn with 1/5th the chance of a regular zombie.
        //}

        //    public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        //    {
        //        // We can use AddRange instead of calling Add multiple times in order to add multiple items at once
        //        bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[] {
        //// Sets the spawning conditions of this NPC that is listed in the bestiary.
        //BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Times.NightTime,

        //// Sets the description of this NPC that is listed in the bestiary.
        //new FlavorTextBestiaryInfoElement("This type of zombie for some reason really likes to spread confetti around. Otherwise, it behaves just like a normal zombie."),

        //// By default the last added IBestiaryBackgroundImagePathAndColorProvider will be used to show the background image.
        //// The ExampleSurfaceBiome ModBiomeBestiaryInfoElement is automatically populated into bestiaryEntry.Info prior to this method being called
        //// so we use this line to tell the game to prioritize a specific InfoElement for sourcing the background image.
        //new BestiaryPortraitBackgroundProviderPreferenceInfoElement(ModContent.GetInstance<ExampleSurfaceBiome>().ModBiomeBestiaryInfoElement),
        //        });
        //    }

        //public override void HitEffect(NPC.HitInfo hit)
        //{
        //    // Spawn confetti when this zombie is hit.

        //    for (int i = 0; i < 10; i++)
        //    {
        //        int dustType = Main.rand.Next(139, 143);
        //        var dust = Dust.NewDustDirect(NPC.position, NPC.width, NPC.height, dustType);

        //        dust.velocity.X += Main.rand.NextFloat(-0.05f, 0.05f);
        //        dust.velocity.Y += Main.rand.NextFloat(-0.05f, 0.05f);

        //        dust.scale *= 1f + Main.rand.NextFloat(-0.03f, 0.03f);
        //    }
        //}

        public override void OnHitPlayer(Player target, Player.HurtInfo hurtInfo)
        {
            int buffType =  BuffID.Slow;

            int timeToAdd = 3 * 60; //This makes it 3 seconds, one second is 60 ticks
            target.AddBuff(buffType, timeToAdd);
        }

        //public override void ModifyIncomingHit(ref NPC.HitModifiers modifiers)
        //{
        //    if (modifiers.DamageType.CountsAsClass(DamageClass.Magic))
        //    {
        //        // This example shows how PartyZombie reduces magic damage by 75%. We use FinalDamage here rather than SourceDamage since we are affecting how the npc reacts to the damage.
        //        // Conceptually, the source dealing the damage isn't interpreted as weaker, but rather this NPC has a resistance to this damage source.
        //        modifiers.FinalDamage *= 0.25f;
        //    }
        //}
    }
}

