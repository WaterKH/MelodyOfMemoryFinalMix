using Game.Scene.MusicStage;
using HarmonyLib;
using MelonLoader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoveTimingGuidesMod
{
    public class RemoveTimingGuidesMod : MelonMod
    {
    }

    [HarmonyPatch(typeof(TimingGuidePool), nameof(TimingGuidePool.Activate), new Type[] { typeof(StandardTimingGuideType), typeof(int), typeof(bool), typeof(bool), typeof(StandardTriggerController) })]
    class MusicStageTriggerStandardPatch
    {
        static void Prefix(ref StandardTimingGuideType timingGuideType, int remainAttackCount, ref bool enableCursor, ref bool enableReactionMark, StandardTriggerController triggerController)
        {
            // this method uses the name "Prefix", no annotation necessary

            // Skip
            timingGuideType = StandardTimingGuideType.None;
            enableCursor = false;
            enableReactionMark = false;
        }
    }

    [HarmonyPatch(typeof(TimingGuidePool), nameof(TimingGuidePool.Activate), new Type[] { typeof(BossTimingGuideType), typeof(bool), typeof(BossTriggerController) })]
    class MusicStageTriggerBossPatch
    {
        static void Prefix(ref BossTimingGuideType timingGuideType, ref bool enableCursor, BossTriggerController triggerController)
        {
            // this method uses the name "Prefix", no annotation necessary

            // Skip
            timingGuideType = BossTimingGuideType.None;
            enableCursor = false;
        }
    }

    [HarmonyPatch(typeof(TimingGuidePool), nameof(TimingGuidePool.Activate), new Type[] { typeof(EventTimingGuideType), typeof(bool), typeof(EventTriggerController) })]
    class MusicStageTriggerBossEventPatch
    {
        static void Prefix(ref EventTimingGuideType timingGuideType, ref bool enableCursor, EventTriggerController triggerController)
        {
            // this method uses the name "Prefix", no annotation necessary

            // Skip
            timingGuideType = EventTimingGuideType.None;
            enableCursor = false;
        }
    }
}
