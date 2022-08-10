using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Scene.MusicStage;
using HarmonyLib;
using MelonLoader;

namespace InstaKillMod
{
    public class InstaKillMod : MelonMod
    {
    }

    [HarmonyPatch(typeof(MusicStagePlayData), nameof(MusicStagePlayData.SetTriggerDamage))]
    class MusicStagePlayDataPatch
    {
        static void Prefix(int playerID, ref float value, float delayTimer)
        {
            // this method uses the name "Prefix", no annotation necessary

            // Update
            value = 9999f;

            for (int i = 0; i < MusicStagePlayData.instance._hpGauges.Count; ++i)
            {
                if (MusicStagePlayData.instance._hpGauges[i] > 0f)
                    MusicStagePlayData.instance._hpGauges[i] = 0f;
            }
        }
    }
}
