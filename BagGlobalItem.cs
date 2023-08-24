using System;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;

namespace BossBagNoRng;

public class BagGlobalItem : GlobalItem
{
    public override void ModifyItemLoot(Item item, ItemLoot itemLoot) {
        var loots = itemLoot.Get();
        // 特殊掉落修改
        switch (item.type) {
            case ItemID.KingSlimeBossBag: {
                TweakCommonDropChance(loots, ItemID.SlimySaddle, 1);
                var ninjaRule = (FewFromOptionsNotScaledWithLuckDropRule)loots.FirstOrDefault(i =>
                    i is FewFromOptionsNotScaledWithLuckDropRule rule &&
                    rule.dropIds.Contains(ItemID.NinjaHood));
                if (ninjaRule != null)
                    ninjaRule.amount = ninjaRule.dropIds.Length;
                break;
            }
            case ItemID.EyeOfCthulhuBossBag: {
                foreach (var rule in loots.Where(i => i is ItemDropWithConditionRule { itemId: ItemID.CrimtaneOre or ItemID.DemoniteOre })) {
                    if (rule is ItemDropWithConditionRule conditionRule)
                        conditionRule.amountDroppedMinimum = conditionRule.amountDroppedMaximum;
                }
                break;
            }
            case ItemID.DeerclopsBossBag: {
                var eyeboneRule = (OneFromOptionsNotScaledWithLuckDropRule)loots.FirstOrDefault(i =>
                    i is OneFromOptionsNotScaledWithLuckDropRule rule &&
                    rule.dropIds.Contains(ItemID.Eyebrella));
                if (eyeboneRule is not null) {
                    foreach (var dropId in eyeboneRule.dropIds) {
                        itemLoot.Add(ItemDropRule.Common(dropId));
                    }

                    // removed for cross-mod compatibility
                    // itemLoot.Remove(eyeboneRule);
                }
                break;
            }
            case ItemID.WallOfFleshBossBag: {
                var emblemRule = (OneFromOptionsNotScaledWithLuckDropRule)loots.FirstOrDefault(i =>
                    i is OneFromOptionsNotScaledWithLuckDropRule rule &&
                    rule.dropIds.Contains(ItemID.WarriorEmblem));
                if (emblemRule is not null) {
                    foreach (var dropId in emblemRule.dropIds) {
                        itemLoot.Add(ItemDropRule.Common(dropId));
                    }

                    // removed for cross-mod compatibility
                    // itemLoot.Remove(emblemRule);
                }
                break;
            }
            case ItemID.QueenSlimeBossBag: {
                var crystalNinjaRule = (FewFromOptionsNotScaledWithLuckDropRule)loots.FirstOrDefault(i =>
                    i is FewFromOptionsNotScaledWithLuckDropRule rule &&
                    rule.dropIds.Contains(ItemID.CrystalNinjaHelmet));
                if (crystalNinjaRule != null)
                    crystalNinjaRule.amount = crystalNinjaRule.dropIds.Length;
                TweakCommonDropChance(loots, ItemID.QueenSlimeMountSaddle, 1);
                TweakCommonDropChance(loots, ItemID.QueenSlimeHook, 1);
                break;
            }
            case ItemID.TwinsBossBag:
            case ItemID.SkeletronPrimeBossBag:
            case ItemID.DestroyerBossBag: {
                var hallowedBarRule = GetCommon(loots, ItemID.HallowedBar);
                if (hallowedBarRule != null)
                    hallowedBarRule.amountDroppedMinimum = hallowedBarRule.amountDroppedMaximum;

                SetCommonDropMost(loots, item.type switch {
                    ItemID.SkeletronPrimeBossBag => ItemID.SoulofFright,
                    ItemID.DestroyerBossBag => ItemID.SoulofMight,
                    _ => ItemID.SoulofSight
                });
                break;
            }
            case ItemID.PlanteraBossBag: {
                TweakCommonDropChance(loots, ItemID.ThornHook, 1);
                break;
            }
            case ItemID.GolemBossBag: {
                TweakCommonDropChance(loots, ItemID.Picksaw, 1);
                SetCommonDropMost(loots, ItemID.BeetleHusk);
                break;
            }
            case ItemID.FishronBossBag: {
                TweakCommonDropChance(loots, ItemID.FishronWings, 1);
                break;
            }
            case ItemID.FairyQueenBossBag: {
                TweakCommonDropChance(loots, ItemID.RainbowWings, 1);
                break;
            }
            case ItemID.BossBagBetsy: {
                TweakCommonDropChance(loots, ItemID.BetsyWings, 1);
                SetCommonDropMost(loots, ItemID.DefenderMedal);
                break;
            }
        }
    }

    public static CommonDrop GetCommon(List<IItemDropRule> loots, int itemId) =>
        (CommonDrop)loots.FirstOrDefault(i => i is CommonDrop rule && rule.itemId == itemId);

    public static CommonDropNotScalingWithLuck GetCommonNoLuck(List<IItemDropRule> loots, int itemId) =>
        (CommonDropNotScalingWithLuck)loots.FirstOrDefault(i => i is CommonDropNotScalingWithLuck rule && rule.itemId == itemId);

    public static void TweakCommonDropChance(List<IItemDropRule> loots, int itemId, int chanceDenominator) {
        var rule = loots.FirstOrDefault(i => i is CommonDropNotScalingWithLuck rule && rule.itemId == itemId);
        if (rule is CommonDropNotScalingWithLuck luckRule)
            luckRule.chanceDenominator = chanceDenominator;
    }

    public static void SetCommonDropMost(List<IItemDropRule> loots, int itemId) {
        var rule = GetCommon(loots, itemId);
        if (rule is not null)
            rule.amountDroppedMinimum = rule.amountDroppedMaximum;
    }
}