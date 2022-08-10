using Common.MSPlaySetting;
using Game;
using Game.PlayData;
using Game.Rhythm;
using Game.Scene.MusicSelect;
using Game.Scene.MusicStage;
using Gumi.Device;
using Gumi.Scene;
using HarmonyLib;
using Il2CppSystem.Collections.Generic;
using MelonLoader;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace PerformerEverywhereMod
{
    public class PerformerEverywhereMod : MelonMod
    {
    }

    // Didn't work
    //[HarmonyPatch(typeof(ContextInput), nameof(ContextInput.UpdateStandard))]
    //class ContextInputStandardPatch
    //{
    //    static void Prefix(bool simple, ref bool performer, InputAction action)
    //    {
    //        // this method uses the name "Prefix", no annotation necessary

    //        // Update
    //        performer = true;
    //    }
    //}

    //// Didn't work
    //[HarmonyPatch(typeof(ContextSetting), nameof(ContextSetting.Setup))]
    //class ContextSettingPatch
    //{
    //    static void Prefix(MusicID musicID, MusicType musicType, MusicLevel musicLevel, bool pairPlay, ref bool performer, bool simple, bool friend, ContextSetting __instance)
    //    {
    //        // this method uses the name "Prefix", no annotation necessary

    //        // Update
    //        performer = true;

    //        __instance.performer = true;
    //    }
    //}

    //// Didn't work
    //[HarmonyPatch(typeof(RuntimeContext), nameof(RuntimeContext.Setup))]
    //class RuntimeContextSetupPatch
    //{
    //    static void Prefix(MusicID musicID, MusicLevel level, bool simplePlay, bool pairPlay, bool enableFriend, ref bool performer, InputDevice[] inputDevices, float[] lanePositions, int[] laneParams, float seekTime)
    //    {
    //        // this method uses the name "Prefix", no annotation necessary

    //        // Update
    //        performer = true;
    //    }
    //}

    //// Didn't work
    //[HarmonyPatch(typeof(MusicStageGamePlay), nameof(MusicStageGamePlay.SetupTriggerData))]
    //class MusicStageGamePlayPatch
    //{
    //    static void Prefix(MusicID musicID, MusicLevel musicLevel, bool simplePlay, bool pairPlay, bool enableFriend, ref bool performerPlay, byte[] binary, float seekTime, MusicStageGamePlay __instance)
    //    {
    //        // this method uses the name "Prefix", no annotation necessary

    //        // Update
    //        performerPlay = true;

    //        __instance.enabled = true;
    //    }
    //}

    //// Performer notes can't be hit and wrong input display
    [HarmonyPatch(typeof(MusicStagePlaySetting), nameof(MusicStagePlaySetting.SetPlaySetting), new Type[] { typeof(MusicID), typeof(Define.MSDifficulty), typeof(bool), typeof(bool), typeof(bool), typeof(bool), typeof(MusicStagePlaySetting.PartyInfo), typeof(List<MSItemID>), typeof(InputManager.PlayingInputDeviceType) })]
    class MusicStagePlaySettingPatch
    {
        static void Prefix(MusicID musicID, Define.MSDifficulty msDifficulty, bool versusBattle, ref bool simplePlay, ref bool performerPlay, bool demoPlay, MusicStagePlaySetting.PartyInfo partyInfo, List<MSItemID> itemIds, ref InputManager.PlayingInputDeviceType msInputDeviceType, MusicStagePlaySetting __instance)
        {
            // this method uses the name "Prefix", no annotation necessary

            // Update
            FileLog.Log(new System.Diagnostics.StackTrace().ToString());
            simplePlay = false;
            performerPlay = true;

            __instance.performerPlay = true;
        }
    }

    [HarmonyPatch(typeof(MusicStagePlaySetting), nameof(MusicStagePlaySetting.SetPlaySetting), new Type[] { typeof(MusicID), typeof(Define.MSDifficulty), typeof(bool), typeof(bool), typeof(MusicStagePlaySetting.PartyInfo), typeof(List<MSItemID>), typeof(bool), typeof(InputManager.PlayingInputDeviceType) })]
    class MusicStagePlaySettingAltPatch
    {
        static void Prefix(MusicID musicID, Define.MSDifficulty msDifficulty, ref bool simplePlay, ref bool performerPlay, MusicStagePlaySetting.PartyInfo partyInfo, List<MSItemID> itemIds, bool demoPlay, InputManager.PlayingInputDeviceType msInputDeviceType, MusicStagePlaySetting __instance)
        {
            // this method uses the name "Prefix", no annotation necessary

            // Update
            simplePlay = false;
            performerPlay = true;

            __instance.performerPlay = true;
        }
    }

    [HarmonyPatch(typeof(MusicStageMain), nameof(MusicStageMain.CreateTriggerData))]
    class MusicStageMainPatch
    {
        static void Prefix(MusicID musicID, Define.MSDifficulty msDifficulty, bool simplePlay, bool pairPlay, bool enableFriend, ref bool performerPlay, TextAsset textAssetTrigger)
        {
            // this method uses the name "Prefix", no annotation necessary

            // Update
            performerPlay = true;
        }
    }

    //[HarmonyPatch(typeof(MusicStageEffectPool), nameof(MusicStageEffectPool.BeginCreatePool))]
    //class MusicStageEffectPoolPatch
    //{
    //    static void Prefix(MusicType musicType, bool trickUse, ref bool performerPlay, MusicStageEffectPool __instance)
    //    {
    //        // this method uses the name "Prefix", no annotation necessary

    //        // Update
    //        performerPlay = true;

    //        __instance.enabled = true;
    //    }
    //}

    //[HarmonyPatch(typeof(Game.Scene.MusicSelect.Main), nameof(Game.Scene.MusicSelect.Main.SetMSPlayMode))]
    //class MusicSelectMainPatch
    //{
    //    static void Prefix(ref Define.MSPlayMode msPlayMode)
    //    {
    //        // this method uses the name "Prefix", no annotation necessary

    //        // Update
    //        msPlayMode = Define.MSPlayMode.Performer;
    //    }
    //}

    //[HarmonyPatch(typeof(Game.Scene.MusicSelect.Main), nameof(Game.Scene.MusicSelect.Main.InitializeCreation))]
    //class MusicSelectInitializeCreationPatch
    //{
    //    static void Prefix(ref MainBaseSettingData settingData, Game.Scene.MusicSelect.Main __instance)
    //    {
    //        // this method uses the name "Prefix", no annotation necessary

    //        // Update
    //        __instance.SetMSPlayMode(Define.MSPlayMode.Performer);
    //        BeforePlayData.SetMSData(1, Define.MSDifficulty.Difficulty03, Define.MSPlayMode.Performer);
    //    }
    //}

    //[HarmonyPatch(typeof(MSPlaySettingMainBase), nameof(MSPlaySettingMainBase.SetPlayMode))]
    //class MSPlaySettingMainBasePatch
    //{
    //    static void Prefix(ref Define.MSPlayMode playMode)
    //    {
    //        // this method uses the name "Prefix", no annotation necessary

    //        // Update
    //        playMode = Define.MSPlayMode.Performer;
    //    }
    //}

    //[HarmonyPatch(typeof(BeforePlayData), nameof(BeforePlayData.SetMSData))]
    //class BeforePlayDataPatch
    //{
    //    static void Prefix(MusicID musicID, Define.MSDifficulty difficulty, ref Define.MSPlayMode playMode)
    //    {
    //        // this method uses the name "Prefix", no annotation necessary

    //        // Update
    //        playMode = Define.MSPlayMode.Performer;
    //    }
    //}

    //[HarmonyPatch(typeof(MusicRecordInfo), nameof(MusicRecordInfo.SetRecordInfo))]
    //class MusicRecordInfoPatch
    //{
    //    static void Prefix(MusicID musicID, Define.MSDifficulty difficulty, ref Define.MSPlayMode playMode, bool isPairPlay)
    //    {
    //        // this method uses the name "Prefix", no annotation necessary

    //        // Update
    //        playMode = Define.MSPlayMode.Performer;
    //    }
    //}

    //[HarmonyPatch(typeof(PerformerInfo), nameof(PerformerInfo.SetInfo))]
    //class PerformerInfoPatch
    //{
    //    static void Prefix(MusicID musicID, Define.MSDifficulty difficulty, ref Define.MSPlayMode playMode)
    //    {
    //        // this method uses the name "Prefix", no annotation necessary

    //        // Update
    //        playMode = Define.MSPlayMode.Performer;
    //    }
    //}

    //[HarmonyPatch(typeof(Picture), nameof(Picture.SetPlayMode))]
    //class PicturePatch
    //{
    //    static void Prefix(ref Define.MSPlayMode playMode)
    //    {
    //        // this method uses the name "Prefix", no annotation necessary

    //        // Update
    //        playMode = Define.MSPlayMode.Performer;
    //    }
    //}

    //[HarmonyPatch(typeof(StyleButton), nameof(StyleButton.SetPlayMode))]
    //class StyleButtonPatch
    //{
    //    static void Prefix(ref Define.MSPlayMode playMode)
    //    {
    //        // this method uses the name "Prefix", no annotation necessary

    //        // Update
    //        playMode = Define.MSPlayMode.Performer;
    //    }
    //}

    //[HarmonyPatch(typeof(StyleTypeListBody), nameof(StyleTypeListBody.SetFirstFocusMode))]
    //class StyleTypeListBodyPatch
    //{
    //    static void Prefix(ref Define.MSPlayMode playMode)
    //    {
    //        // this method uses the name "Prefix", no annotation necessary

    //        // Update
    //        playMode = Define.MSPlayMode.Performer;
    //    }
    //}
}
