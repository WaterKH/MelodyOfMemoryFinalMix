using Game.PlayData;
using HarmonyLib;
using MelonLoader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using Game;
using Gumi.Scene.GameScene;
using Gumi.Scene;
using AssetBundles;
using UnityEngine.Events;

namespace BattleRoyaleMod
{
    public class BattleRoyaleMod : MelonMod
    {
    }

    [HarmonyPatch(typeof(AssetBundleManager), nameof(AssetBundleManager.LoadAssetBundle), new Type[] { typeof(string) })]
    class AssetBundleManagerPatch
    {
        static void Prefix(string assetBundleName)
        {

            FileLog.Log(assetBundleName);
            //foreach (var info in __instance._buttonInfo)
            //{
            //    FileLog.Log($"nextGameSceneId: enabled = {info.enabled}; isActiveAndEnabled = {info.isActiveAndEnabled}; name = {info.name};");
            //}
        }
    }

    [HarmonyPatch(typeof(Game.Scene.BattleVs.TopButton), nameof(Game.Scene.BattleVs.TopButton.Update))]
    class TopButtonPatch
    {
        static void Prefix(ref Game.Scene.BattleVs.TopButton __instance)
        {
            __instance._battleRoyalButton.active = true;

            __instance._localButton.active = true;


            //FileLog.Log("ENDED");
        }
    }

    [HarmonyPatch(typeof(Game.Scene.BattleVs.TopButton), nameof(Game.Scene.BattleVs.TopButton.InitializeSetting))]
    class TopButtonInitPatch
    {
        static void Prefix(MainBaseSettingData settingData, ref Game.Scene.BattleVs.TopButton __instance)
        {
            __instance._battleRoyalButton.active = true;
            //__instance._battleRoyalButton.SetActive(true);
            //__instance._battleRoyalButton.SetActiveRecursively(true);
            GameSceneFlowManager.instance.OnSceneLoad(Game.Define.GameScene.BattleVsTop, Game.Define.GameScene.BattleRoyal);




            __instance._localButton.active = true;
            //__instance._localButton.SetActive(true);
            //__instance._localButton.SetActiveRecursively(true);

            BuildSettings._platform = Game.Define.Platform.Switch;

            //AssetBundleManager.LoadAssetBundle("");
            //AssetBundleManager.LoadAssetBundle("regioncommon/languagecommon/battleroyal");
            //AssetBundleManager.LoadAssetBundle("regioncommon/languagecommon/battleroyalmatchsetting");

            //AssetBundleManager.LoadAssetBundle("scenes/battleroyal_s");

            //FileLog.Log("TopButtonUpdate");
            //foreach (var info in __instance._buttonInfo)
            //{
            //    FileLog.Log($"nextGameSceneId: enabled = {info.enabled}; isActiveAndEnabled = {info.isActiveAndEnabled}; name = {info.name};");
            //}


            //FileLog.Log("ENDED");
        }
    }

    [HarmonyPatch(typeof(GameSceneFlowManager), nameof(GameSceneFlowManager.OnSceneLoad))]
    class GameSceneFlowManagerOnSceneLoadPatch
    {
        static void Prefix(GameSceneID prevGameSceneID, ref GameSceneID nextGameSceneID)
        {
            FileLog.Log("GameSceneFlowManager");
            FileLog.Log($"nextGameSceneId: Pointer = {nextGameSceneID.Pointer}; prefixNumber = {nextGameSceneID.prefixNumber}; prefixString = {nextGameSceneID.prefixString}; value = {nextGameSceneID.value}; " +
                $"valueNumber = {nextGameSceneID.valueNumber}; WasCollected = {nextGameSceneID.WasCollected}; _value = {nextGameSceneID._value};");

            //nextGameSceneID = Game.Define.GameScene._battleroyal;

            //FileLog.Log($"nextGameSceneId: Pointer = {nextGameSceneID.Pointer}; prefixNumber = {nextGameSceneID.prefixNumber}; prefixString = {nextGameSceneID.prefixString}; value = {nextGameSceneID.value}; " +
            //    $"valueNumber = {nextGameSceneID.valueNumber}; WasCollected = {nextGameSceneID.WasCollected}; _value = {nextGameSceneID._value};");
        }
    }

    [HarmonyPatch(typeof(GameSceneFlowManager), nameof(GameSceneFlowManager.GetGameSceneLoadData))]
    class GameSceneFlowManagerGetGameSceneLoadDataPatch
    {
        static void Prefix(GameSceneID gameSceneID)
        {
            FileLog.Log("GetGameSceneLoadData");
            FileLog.Log($"nextGameSceneId: Pointer = {gameSceneID.Pointer}; prefixNumber = {gameSceneID.prefixNumber}; prefixString = {gameSceneID.prefixString}; value = {gameSceneID.value}; " +
                $"valueNumber = {gameSceneID.valueNumber}; WasCollected = {gameSceneID.WasCollected}; _value = {gameSceneID._value};");

            //nextGameSceneID = Game.Define.GameScene._battleroyal;

            //FileLog.Log($"nextGameSceneId: Pointer = {nextGameSceneID.Pointer}; prefixNumber = {nextGameSceneID.prefixNumber}; prefixString = {nextGameSceneID.prefixString}; value = {nextGameSceneID.value}; " +
            //    $"valueNumber = {nextGameSceneID.valueNumber}; WasCollected = {nextGameSceneID.WasCollected}; _value = {nextGameSceneID._value};");
        }
    }

    [HarmonyPatch(typeof(GameSceneFlowManager), nameof(GameSceneFlowManager.GetNextGameSceneLoadData))]
    class GameSceneFlowManagerGetNextGameSceneLoadDataPatch
    {
        static void Prefix(GameSceneID beforeGameSceneID, Gumi.Scene.GameScene.GameSceneMain.ReactionData beforeGameSceneReactionData)
        {
            FileLog.Log("GetNextGameSceneLoad");
            FileLog.Log($"nextGameSceneId: Pointer = {beforeGameSceneID.Pointer}; prefixNumber = {beforeGameSceneID.prefixNumber}; prefixString = {beforeGameSceneID.prefixString}; value = {beforeGameSceneID.value}; " +
                $"valueNumber = {beforeGameSceneID.valueNumber}; WasCollected = {beforeGameSceneID.WasCollected}; _value = {beforeGameSceneID._value};");

            //nextGameSceneID = Game.Define.GameScene._battleroyal;

            //FileLog.Log($"nextGameSceneId: Pointer = {nextGameSceneID.Pointer}; prefixNumber = {nextGameSceneID.prefixNumber}; prefixString = {nextGameSceneID.prefixString}; value = {nextGameSceneID.value}; " +
            //    $"valueNumber = {nextGameSceneID.valueNumber}; WasCollected = {nextGameSceneID.WasCollected}; _value = {nextGameSceneID._value};");
        }
    }

    //[HarmonyPatch(typeof(Game.Scene.Application.Main), nameof(Game.Scene.Application.Main.Awake))]
    //class ApplicationPatch
    //{
    //    static void Postfix()
    //    {
    //        Game.Define.GameScene._theater = Game.Define.GameScene._battleroyal;
    //    }
    //}
}
