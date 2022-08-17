# Melody of Memory: Final Mix
A collection of simple mods using MelonLoader. The most notable of these mods is the [OnlineMod](https://github.com/WaterKH/MelodyOfMemoryMods/edit/main/README.md#onlinemod), which allows people to play with their friends regardless of rating and without accidentally matching with someone else.


## How to Install
You will first need to setup MelonLoader for Kingdom Hearts Melody of Memory. To do this, please follow their guide for [Getting Started with MelonLoader](https://melonwiki.xyz/#/README). Once this is complete, run the game once to generate the Mods folder in the root directory where your 'KINGDOM HEARTS Melody of Memory.exe' is located. Place any of the mods (dlls) contained within the [Latest Release](https://github.com/WaterKH/MelodyOfMemoryMods/releases) into your Mods folder. Close and re-launch the game and verify that a MelonLoader console window shows up - This window should also indicate whether any mods were not loaded correctly.


## How to Modify
If you want to customize your experience with these mods, you can download this repository. Verify that you have .NET Framework 4.7.2 installed as well as Visual Studio 2019. Make any change you want to the variables being reassigned in the Patch files. For instance, if you want to give more health to Sora per Glide Note, then modify line 28 of MelodyOfMemoryMods/GlideHealthMod/GlideHealthMod.cs:

```
MusicStagePlayData.SetRecovery(0, 0.35f);
```

Once you have made this change, Re-Build the project and locate the GlideHealthMod.dll in the following path: GlideHealthMod\obj\Release - Basically, whichever mod you modify, find the obj folder, and then the dll you are looking for will either be in Debug or Release. Drop this new mod into the Mods folder to start playing with your newly modified mod!


## How to Contribute
**If you would like to create mods for Melody of Memory using this template, you can fork from this branch to get started. If you have used this research compiled by myself or template, please submit a Pull Request back into main with an update to this README.md listing below an entry for your mod.**

It is recommended to disassemble the GameAssembly.dll into classes that describe their structure, like class name, method names, properties, etc. - I will not be reviewing how to do that here since there are many other tutorials you can find with Google, but I do recommend [Il2CppInspector](https://github.com/djkaty/Il2CppInspector/releases/tag/2021.1) as that's what I used for creating these mods. You can also use CheatEngine's Mono support for finding functinons and properties. You should also reference the documentation of both [Harmony](https://harmony.pardeike.net/articles/patching.html) and [MelonLoader](https://melonwiki.xyz/#/modders/quickstart) since this is what was used to make these mods. You will also need to import several libraries to ensure your mod loads correctly. Usually you can auto-import by hovering over the error, but here are some notable ones you will probably need to reference: 0Harmony, Assembly-CSharp, Il2Cppmscorlib, MelonLoader, Mono.CSharp, UnhollowerBaseLib, UnhollowerRuntimeLib, UnityEngine, UnityEngine.CoreModule.

Once you've completed your mod, it's very important that you attach this in your AssemblyInfo.cs file for that project; otherwise, the mod will not be loaded by MelonLoader.
```
using MelonLoader;

[assembly: MelonInfo(typeof(<Namespace>.<ClassName>), "{ Mod Name }", "{ Version Number }", "{ Author Name }")]
[assembly: MelonGame("SQUARE ENIX", "KINGDOM HEARTS Melody of Memory")]
```

All of this and more can be found using the MelonLoader documentation.


# Currently Supported Mods
Below will be a list of mods that are included in the latest Mod Pack. If any are not included, it means that they are either unstable or not working properly. If you contribute, please make sure to make an entry in this list!


## OnlineMod
This mod allows you to connect to friends regardless of rating and makes sure you connect with only them. The way this is done is by the UniqueId and the VersionId. These are both able to be changed in-game by pressing the 'P' key, which will toggle the mod menu. Then you can customize which values and verify that your friend has the same. The UniqueId will match within 500 plus or minus, so it is recommended to just use the VersionId.


## GlideHealthMod
This is a very simple mod that allows you to regain health when flying through Glide Notes on standard charts. This was made with myself, [waterkh](https://twitter.com/water_kh), in mind because everytime I look at these notes I think they should heal you. They only heal a very small amount of HP back to the player.


## InstaKillMod
This is a mod that instantly kills the player when missing a note in any gamemode. This was made with [Limen](https://twitter.com/Limen_nt) in mind.


## InvisibleTrickMod
This is a mod that constantly hides enemies with the two tricks implemented by the game. This was made with [angel](https://twitter.com/plnkblue) in mind. **NOTE: You may have issues playing on Solo mode, with barrels, crystals, glide notes, etc. being hidden.**


## PerformerDamageMod
This is a mod that will damage the player if they miss a Performer Note. This was made with [PreferredWhale6](https://twitter.com/PreferredWhale) in mind.


## RemoveTimingGuidesMod
This is a mod that removes all timing guides from the enemies and forces the player to rely on sound queues. This was made with [Lucien](https://twitter.com/RenegadeLucien) in mind.
