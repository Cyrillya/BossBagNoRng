using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;

namespace BossBagNoRng;

public class TrophySystem : ModSystem
{
    // 这里是SetupBestiary()结束之后唯一执行的，只有写在这才有用
    public override void PostSetupRecipes() {
        // 纪念章
        RegisterTrophy(ItemID.KingSlimeBossBag, ItemID.KingSlimeTrophy);
        RegisterTrophy(ItemID.EyeOfCthulhuBossBag, ItemID.EyeofCthulhuTrophy);
        RegisterTrophy(ItemID.EaterOfWorldsBossBag, ItemID.EaterofWorldsTrophy);
        RegisterTrophy(ItemID.BrainOfCthulhuBossBag, ItemID.BrainofCthulhuTrophy);
        RegisterTrophy(ItemID.QueenBeeBossBag, ItemID.QueenBeeTrophy);
        RegisterTrophy(ItemID.SkeletronBossBag, ItemID.SkeletronTrophy);
        RegisterTrophy(ItemID.DeerclopsBossBag, ItemID.DeerclopsTrophy);
        RegisterTrophy(ItemID.WallOfFleshBossBag, ItemID.WallofFleshTrophy);
        RegisterTrophy(ItemID.QueenSlimeBossBag, ItemID.QueenSlimeTrophy);
        RegisterTrophy(ItemID.TwinsBossBag, ItemID.RetinazerTrophy);
        RegisterTrophy(ItemID.TwinsBossBag, ItemID.SpazmatismTrophy);
        RegisterTrophy(ItemID.DestroyerBossBag, ItemID.DestroyerTrophy);
        RegisterTrophy(ItemID.SkeletronPrimeBossBag, ItemID.SkeletronPrimeTrophy);
        RegisterTrophy(ItemID.PlanteraBossBag, ItemID.PlanteraTrophy);
        RegisterTrophy(ItemID.GolemBossBag, ItemID.GolemTrophy);
        RegisterTrophy(ItemID.FairyQueenBossBag, ItemID.FairyQueenTrophy);
        RegisterTrophy(ItemID.FishronBossBag, ItemID.DukeFishronTrophy);
        RegisterTrophy(ItemID.MoonLordBossBag, ItemID.MoonLordTrophy);
        RegisterTrophy(ItemID.BossBagBetsy, ItemID.BossTrophyBetsy);
    }

    public static void RegisterTrophy(int bossBagId, int trophyId) =>
        Main.ItemDropsDB.RegisterToItemId(bossBagId, ItemDropRule.Common(trophyId));
}