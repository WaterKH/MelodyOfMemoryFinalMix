using Game.Rhythm;
using Game.Scene.MusicStage;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MelonLoader;

namespace PerformerDamageMod
{
    public class PerformerDamageMod : MelonMod
    {
    }

    [HarmonyPatch(typeof(PerformerTriggerController), nameof(PerformerTriggerController.PlayJudgeMotion))]
    class PerformerTriggerControllerPatch
    {
        static void Prefix(TriggerJudge judgeState)
        {
            // this method uses the name "Prefix", no annotation necessary

            // Update
            if (judgeState == TriggerJudge.Miss)
            {
                MusicStagePlayData.SetTriggerDamage(0, 2.5f);
            }
        }
    }
}
