using MelonLoader;
using UnityEngine;
using HarmonyLib; // If you're using 0.4.0 and later
using Gumi.Network;
using UnhollowerBaseLib;
using System;
using Game.Scene.BattleMatching;

namespace OnlineMod
{
    public class OnlineMod : MelonMod
    {
        public static string UniqueID = "10000";
        public static string Version = "255";
        public static bool IsActive = false;

        //string uniqueID = "10000"; // 10,000 - 32,000
        //string version = "255"; // 10 - 250

        public override void OnUpdate()
        {
            if (Input.GetKeyDown(KeyCode.P))
            {
                IsActive = !IsActive;
            }
        }

        public override void OnGUI()
        {
            Cursor.visible = IsActive;

            // Watermark: waterkh
            GUI.Label(new Rect(Screen.width - 220, Screen.height - 20, 220, 80), "<b>Online Mod - Created by waterkh</b>");

            if (IsActive)
            {
                // Make a background box
                GUI.Box(new Rect(10, 10, 250, 150), "");
                GUI.Box(new Rect(10, 10, 250, 150), "");
                GUI.Box(new Rect(10, 10, 250, 150), "<b>Online Mod Menu</b>");

                // Unique ID
                GUI.Label(new Rect(15, 40, 200, 20), "<b>Unique ID: </b>");
                GUI.Label(new Rect(110, 60, 100, 20), $"<b>{UniqueID}</b>");

                if (GUI.Button(new Rect(10, 60, 45, 20), "- 1"))
                {
                    if (Convert.ToInt16(UniqueID) - 1 >= 0)
                        UniqueID = (Convert.ToInt16(UniqueID) - 1).ToString();
                }

                if (GUI.Button(new Rect(60, 60, 45, 20), "- 100"))
                {
                    if (Convert.ToInt16(UniqueID) - 100 >= 0)
                        UniqueID = (Convert.ToInt16(UniqueID) - 100).ToString();
                }

                if (GUI.Button(new Rect(150, 60, 45, 20), "+ 1"))
                {
                    if (Convert.ToInt16(UniqueID) + 1 <= 32000)
                        UniqueID = (Convert.ToInt16(UniqueID) + 1).ToString();
                }

                if (GUI.Button(new Rect(200, 60, 45, 20), "+ 100"))
                {
                    if (Convert.ToInt16(UniqueID) + 100 <= 32000)
                        UniqueID = (Convert.ToInt16(UniqueID) + 100).ToString();
                }

                // Version
                GUI.Label(new Rect(15, 90, 200, 20), "<b>Version ID: </b>");
                GUI.Label(new Rect(120, 110, 100, 20), $"<b>{Version}</b>");

                if (GUI.Button(new Rect(10, 110, 45, 20), "- 1"))
                {
                    if (Convert.ToByte(Version) - 1 >= 10)
                        Version = (Convert.ToByte(Version) - 1).ToString();
                }

                if (GUI.Button(new Rect(60, 110, 45, 20), "- 10"))
                {
                    if (Convert.ToByte(Version) - 10 >= 10)
                        Version = (Convert.ToByte(Version) - 10).ToString();
                }

                if (GUI.Button(new Rect(150, 110, 45, 20), "+ 1"))
                {
                    if (Convert.ToByte(Version) + 1 <= 255)
                        Version = (Convert.ToByte(Version) + 1).ToString();
                }

                if (GUI.Button(new Rect(200, 110, 45, 20), "+ 10"))
                {
                    if (Convert.ToByte(Version) + 10 <= 255)
                        Version = (Convert.ToByte(Version) + 10).ToString();
                }
            }
        }
    }

    [HarmonyPatch(typeof(NetworkManager), nameof(NetworkManager.JoinRandomOrCreateRoom))]
    class JoinCreatePatch
    {
        static void Prefix(ref NetworkManager.SearchParam searchParam, string createRoomName, ref NetworkManager.PlayerProfile userProfile, Il2CppStructArray<uint> musicArray)
        {
            // this method uses the name "Prefix", no annotation necessary

            // Update
            searchParam.matchingVersion = Convert.ToByte(OnlineMod.Version);
            searchParam.searchRate = Convert.ToInt16(OnlineMod.UniqueID);

            userProfile.rate = Convert.ToInt16(OnlineMod.UniqueID);

            

            // Logging
            //FileLog.Log("JoinRandomOrCreateRoom");
            //FileLog.Log($"searchParam: MatchingVersion = {searchParam.matchingVersion}; SearchRate = {searchParam.searchRate}");
            //FileLog.Log($"createRoomName = {createRoomName}");
            //FileLog.Log($"userProfile: Burst = {userProfile.burst}; Difficulty = {userProfile.difficulty}; Level = {userProfile.level}; PartyId = {userProfile.partyId}; PlayerName = {userProfile.playerName}; ColorId = {userProfile.proficaBaseColorId}; " +
            //    $"DesignId = {userProfile.proficaBaseDesignId}; GUID = {userProfile.proficaGuid}; IllustId = {userProfile.proficaIllustId}; Rate = {userProfile.rate}; Region = {userProfile.region}");
            //FileLog.Log("Music Array:");
            //for (int i = 0; i < musicArray.Length; ++i)
            //    FileLog.Log($"Id {i}: {musicArray[i]}");
        }
    }

    [HarmonyPatch(typeof(PlayerInfo), nameof(PlayerInfo.SetRate))]
    class SetRatePatch
    {
        static void Prefix(ref int rate)
        {
            // this method uses the name "Prefix", no annotation necessary

            // Update
            rate = 0;
        }
    }
}
