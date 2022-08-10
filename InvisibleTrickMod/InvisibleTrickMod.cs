using Game;
using Game.Rhythm;
using Game.Scene.MusicStage;
using Gumi.Device;
using HarmonyLib;
using Il2CppSystem.Collections.Generic;
using Il2CppSystem.Reflection;
using MelonLoader;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvisibleTrickMod
{
    public class InvisibleTrickMod : MelonMod
    {
    }

    [HarmonyPatch(typeof(MusicStageGamePlay), nameof(MusicStageGamePlay.UpdateStandard))]
    class MusicStageGamePlayPatch
    {
        static void Prefix(float deltaTime, MusicStageGamePlay __instance)
        {
            // this method uses the name "Prefix", no annotation necessary

            // Update
            if (!TrickController.IsActiveTrick(TrickType.StealthEnemy))
                TrickController.ActivateTrick(TrickType.StealthEnemy, true);

            if (!TrickController.IsActiveTrick(TrickType.PhantomEnemy))
                TrickController.ActivateTrick(TrickType.PhantomEnemy, true);

            // This seems to cause everything to become invisible in single player.... Barrels, Crystals, etc.
            if (!__instance._playSetting.trickUse)
            {
                __instance._playSetting.trickUse = true;

                TrickController.phantomEnemyLateInTime = 0.71f;
                TrickController.stealthStartTime = 0.91f;
            }
        }
    }

    [HarmonyPatch(typeof(MusicStageEffectPool), nameof(MusicStageEffectPool.BeginCreatePool))]
    class MusicStageEffectPoolPatch
    {
        static void Prefix(MusicType musicType, ref bool trickUse, bool performerPlay)
        {
            // this method uses the name "Prefix", no annotation necessary

            // Update
            trickUse = true;
        }
    }
}
