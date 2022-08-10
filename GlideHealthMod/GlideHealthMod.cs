using Game.Rhythm;
using Game.Scene.MusicStage;
using HarmonyLib;
using MelonLoader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace GlideHealthMod
{
    public class GlideHealthMod : MelonMod
    {
    }

    [HarmonyPatch(typeof(TriggerJudgeChecker), nameof(TriggerJudgeChecker.PlayStandardTriggerJudgeEffect))]
    class TriggerJudgeCheckerPatch
    {
        static void Prefix(TriggerJudge judge, StandardTriggerController triggerController, Transform charaCameraTransform, bool pairPlay)
        {
            // this method uses the name "Prefix", no annotation necessary

            // Update
            if (judge != TriggerJudge.Miss && triggerController.trigger.type == StandardTriggerType.Prize)
            {
                MusicStagePlayData.SetRecovery(0, 0.35f);
            }
        }
    }
}
