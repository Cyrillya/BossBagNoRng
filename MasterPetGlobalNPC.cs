using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;

namespace BossBagNoRng
{
    public class MasterPetGlobalNPC : GlobalNPC
    {
        public static readonly Dictionary<short, short> NPCToPet = new()
        {
            { NPCID.KingSlime, ItemID.KingSlimePetItem },
            { NPCID.EyeofCthulhu, ItemID.EyeOfCthulhuPetItem },
            { NPCID.EaterofWorldsHead, ItemID.EaterOfWorldsPetItem },
            { NPCID.EaterofWorldsBody, ItemID.EaterOfWorldsPetItem },
            { NPCID.EaterofWorldsTail, ItemID.EaterOfWorldsPetItem },
            { NPCID.BrainofCthulhu, ItemID.BrainOfCthulhuPetItem },
            { NPCID.QueenBee, ItemID.QueenBeePetItem },
            { NPCID.SkeletronHead, ItemID.SkeletronPetItem },
            { NPCID.Deerclops, ItemID.DeerclopsPetItem },
            { NPCID.WallofFlesh, ItemID.WallOfFleshGoatMountItem },
            { NPCID.QueenSlimeBoss, ItemID.QueenSlimePetItem },
            { NPCID.Spazmatism, ItemID.TwinsPetItem },
            { NPCID.Retinazer, ItemID.TwinsPetItem },
            { NPCID.TheDestroyer, ItemID.DestroyerPetItem },
            { NPCID.SkeletronPrime, ItemID.SkeletronPrimePetItem },
            { NPCID.Plantera, ItemID.PlanteraPetItem },
            { NPCID.HallowBoss, ItemID.FairyQueenPetItem },
            { NPCID.Golem, ItemID.GolemPetItem },
            { NPCID.DukeFishron, ItemID.DukeFishronPetItem },
            { NPCID.CultistBoss, ItemID.LunaticCultistPetItem },
            { NPCID.MoonLordCore, ItemID.MoonLordPetItem },
            { NPCID.Pumpking, ItemID.PumpkingPetItem },
            { NPCID.MourningWood, ItemID.SpookyWoodMountItem },
            { NPCID.Everscream, ItemID.EverscreamPetItem },
            { NPCID.SantaNK1, ItemID.SantankMountItem },
            { NPCID.IceQueen, ItemID.IceQueenPetItem },
            { NPCID.DD2DarkMageT1, ItemID.DarkMageBookMountItem },
            { NPCID.DD2DarkMageT3, ItemID.DarkMageBookMountItem },
            { NPCID.DD2OgreT3, ItemID.DD2OgrePetItem },
            { NPCID.DD2Betsy, ItemID.DD2BetsyPetItem },
            { NPCID.PirateShip, ItemID.PirateShipMountItem },
            { NPCID.MartianSaucerCore, ItemID.MartianPetItem }
        };

        public override bool AppliesToEntity(NPC entity, bool lateInstantiation) =>
            NPCToPet.ContainsKey((short)entity.type);


        public override void ModifyNPCLoot(NPC npc, NPCLoot npcLoot) {
            if (!NPCToPet.TryGetValue((short)npc.type, out var itemId)) {
                return;
            }

            var loots = npcLoot.Get();
            var rule = loots.FirstOrDefault(i => i is DropBasedOnMasterMode { ruleForMasterMode: DropPerPlayerOnThePlayer dropRule } && dropRule.itemId == itemId);
            if (rule is DropBasedOnMasterMode { ruleForMasterMode: DropPerPlayerOnThePlayer perPlayerRule })
                perPlayerRule.chanceDenominator = 1;
        }
    }
}
