using MelonLoader;
using BTD_Mod_Helper;
using TwitchChatBattlesMod;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;
using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using Random = System.Random;
using Il2CppAssets.Scripts.Unity.UI_New.Popups;
using BTD_Mod_Helper.Extensions;
using static Il2CppFacepunch.Steamworks.Inventory.Item;
using Il2CppAssets.Scripts.Models.Bloons;
using JetBrains.Annotations;
using Il2CppAssets.Scripts.Simulation.Bloons;
using Il2CppAssets.Scripts.Simulation.Towers.Behaviors.Attack;
using Il2CppAssets.Scripts.Simulation.Objects;
using Il2CppAssets.Scripts.Models;
using Harmony;
using HarmonyLib;
using Il2CppAssets.Scripts.Simulation.Towers.Projectiles;
using Il2CppAssets.Scripts.Simulation.Towers;

[assembly: MelonInfo(typeof(TwitchChatBattlesMod.TwitchChatBattlesMod), ModHelperData.Name, ModHelperData.Version, ModHelperData.RepoOwner)]
[assembly: MelonGame("Ninja Kiwi", "BloonsTD6")]

namespace TwitchChatBattlesMod;

public class TwitchChatBattlesMod : BloonsTD6Mod {

    string chatFile = System.Environment.CurrentDirectory + @"\twitchchat.txt";
    int chatIndex = 0;
    int timer = 0;
    int timerCheck = 60;
    int cycle = 0;

    int randomIgnoreChance = 0;
    float moneySubtractionMultiplier = 50;
    int minRoundModifier = 0;
    int maxAmountModifier = 0;
    
    public override void OnApplicationStart() {
        base.OnApplicationStart();
        ModHelper.Msg<TwitchChatBattlesMod>("TwitchChatBattlesMod loaded!");
        string[] chat = System.IO.File.ReadAllLines(chatFile);
        chatIndex = chat.Length;
    }

    public override void OnUpdate() {
        base.OnUpdate();
        if (InGame.instance == null) { return; }
        if (InGame.instance.bridge == null) { return; }

        if (Input.GetKeyDown(KeyCode.F1)) {
            InGame.instance.bridge.SpawnBloons(Util.GetBloonEmissionArray("TwitchChatBattlesMod-Cyan", 5, 15), 1, 0);
        } else if (Input.GetKeyDown(KeyCode.F2)) {
            InGame.instance.bridge.SpawnBloons(Util.GetBloonEmissionArray("TwitchChatBattlesMod-CyanRegrow", 5, 15), 1, 0);
        } else if (Input.GetKeyDown(KeyCode.F3)) {
            InGame.instance.bridge.SpawnBloons(Util.GetBloonEmissionArray("TwitchChatBattlesMod-CyanCamo", 5, 15), 1, 0);
        } else if (Input.GetKeyDown(KeyCode.F4)) {
            InGame.instance.bridge.SpawnBloons(Util.GetBloonEmissionArray("TwitchChatBattlesMod-CyanRegrowCamo", 5, 15), 1, 0);
        }

        if (Input.GetKeyDown(KeyCode.F6)) {
            PopupScreen.instance.ShowSetValuePopup("Random Ignore Chance", "Random chance to ignore a send",
                new Action<int>(i => {
                    if (i < 0) { i = 0; }
                    if (i > 100) { i = 100; }
                    randomIgnoreChance = i;
                }), 25);
        } else if (Input.GetKeyDown(KeyCode.F7)) {
            PopupScreen.instance.ShowSetValuePopup("Money Subtracter", "Amount to divide the equivlent value of bloon sends to minus by (REMEMBER THIS IS DIVISION, NO 0). HIGHER = LESS SUBTRACTED. 1 = ALL SUBTRACTED.",
                new Action<int>(i => {
                    if (i < 0) { i = 0; }
                    if (i > 100) { i = 100; }
                    moneySubtractionMultiplier = i;
                }), 50);
        } else if (Input.GetKeyDown(KeyCode.F8)) {
            PopupScreen.instance.ShowSetValuePopup("Minimum Round Modifier", "Add/Subtract minimum round to all bloons",
                new Action<int>(i => {
                    if (i < -100) { i = -100; }
                    if (i > 100) { i = 100; }
                    minRoundModifier = i;
                }), 0);
        } else if (Input.GetKeyDown(KeyCode.F9)) {
            PopupScreen.instance.ShowSetValuePopup("Max Bloon Amount Modifier", "Add/Subtract max amount to all bloons",
                new Action<int>(i => {
                    if (i < -100) { i = -100; }
                    if (i > 100) { i = 100; }
                    maxAmountModifier = i;
                }), 0);
        }

        InGame instance = InGame.instance;

        timer++;

        if (timer > timerCheck) {
            cycle++;
            timer = 0;
            int round = instance.bridge.GetCurrentRound();

            string[] chat = System.IO.File.ReadAllLines(chatFile);

            for (int i = chatIndex; i < chat.Length; i++) {
                string[] splitWords = chat[i].Split(' ');

                string bloon = "";
                string regrow = "";
                string fortified = "";
                string camo = "";
                int amount = 1;

                // Get bloon from message
                for (int j = 0; j < splitWords.Length; j++) {
                    string word = splitWords[j].ToLower();
                    if (bloon == "" && ModConfig.ValidBloons.Contains(word)) {
                        if (round + 1 < (ModConfig.MinBloonRounds[word] + minRoundModifier)) { continue; }
                        bloon = char.ToUpper(word[0]) + word[1..];
                    }
                }

                // Get modifiers & amount (seperately because order might be messed up)
                for (int j = 0; j < splitWords.Length; j++) {
                    string word = splitWords[j].ToLower();
                    if (bloon == "") { continue; }
                    if (word == "regrow" && ModConfig.BloonsWithRegrow.Contains(bloon.ToLower()) && round >= ModConfig.MinRegrowRound) { regrow = "Regrow"; }
                    if (word == "fortified" && ModConfig.BloonsWithFortified.Contains(bloon.ToLower()) && round >= ModConfig.MinFortifiedRound) { fortified = "Fortified"; }
                    if (word == "camo" && ModConfig.BloonsWithCamo.Contains(bloon.ToLower()) && round >= ModConfig.MinCamoRound) { camo = "Camo"; }
                    if (int.TryParse(word, out _)) {
                        amount = int.Parse(word);
                        int maxAmount = ModConfig.BaseMaxBloonAmounts[bloon.ToLower()] + ((int)(round * ModConfig.MaxAmountRoundMultiplier[bloon.ToLower()]));
                        // Big funny, have to check for negative amounts, thanks minecool
                        if (amount < 1) { amount = 1; }
                        if (amount > (maxAmount + maxAmountModifier)) { amount = (maxAmount + maxAmountModifier); }
                    }
                }

                string bloonId = bloon + regrow + fortified + camo;


                if (bloon == "Bloonarius" || bloon == "Dreadbloon" || bloon == "Lych" || bloon == "Vortex") {
                    bloonId = bloon + Util.GetBossLevel(round) + regrow + fortified + camo;
                }

                if (bloon == "Cyan" || bloon == "Magic" || bloon == "Military" || bloon == "Orange" || bloon == "Primary" || bloon == "Support") {
                    bloonId = "TwitchChatBattlesMod-" + bloon + regrow + fortified + camo;
                }

                if (ModConfig.BloonIds.Contains(bloonId)) {
                    if (new Random().Next(100) + 1 <= randomIgnoreChance) { chatIndex++; continue; }
                    int bloonCooldown = bloonCooldowns[bloon.ToLower()] + ModConfig.BloonCooldowns[bloon.ToLower()];
                    if (bloonCooldown > cycle) { chatIndex++; continue; }
                    ModHelper.Msg<TwitchChatBattlesMod>(bloonId + " " + amount);

                    double bloonValue = Util.GetBloonValue(bloon.ToLower(), amount, round) - (Util.GetBloonValue(bloon.ToLower(), amount, round) * (moneySubtractionMultiplier * 0.01d));

                    InGame.instance.bridge.SetCash(InGame.instance.bridge.GetCash() - bloonValue);
                    InGame.instance.bridge.SpawnBloons(Util.GetBloonEmissionArray(bloonId, amount, 15), round, 0);

                    bloonCooldowns[bloon.ToLower()] = cycle;
                }

                chatIndex++;
            }
        }
    }
 

    Dictionary<string, int> bloonCooldowns = new Dictionary<string, int>() {
        ["red"] = 0,
        ["blue"] = 0,
        ["green"] = 0,
        ["yellow"] = 0,
        ["pink"] = 0,
        ["black"] = 0,
        ["white"] = 0,
        ["purple"] = 0,
        ["zebra"] = 0,
        ["lead"] = 0,
        ["rainbow"] = 0,
        ["ceramic"] = 0,
        ["moab"] = 0,
        ["bfb"] = 0,
        ["zomg"] = 0,
        ["ddt"] = 0,
        ["bad"] = 0,
        ["testbloon"] = 0,
        ["bloonarius"] = 0,
        ["dreadbloon"] = 0,
        ["lych"] = 0,
        ["vortex"] = 0,
        ["magic"] = 0,
        ["support"] = 0,
        ["orange"] = 0,
        ["cyan"] = 0,
        ["primary"] = 0,
        ["military"] = 0,
    };
}

[HarmonyLib.HarmonyPatch(typeof(Il2CppAssets.Scripts.Simulation.Towers.Projectiles.Behaviors.Slow), "CollideBloon")]
class SlowPatch {

    [HarmonyLib.HarmonyPrefix]
    public static bool Prefix(Il2CppAssets.Scripts.Simulation.Towers.Projectiles.Behaviors.Slow __instance, Bloon bloon) {
        if (bloon.bloonModel.HasTag("Orange")) {
            return false;
        }
        return true;
    }
}

    [HarmonyLib.HarmonyPatch(typeof(Projectile), "CollideBloon")]
class TowerPatch {
    [HarmonyLib.HarmonyPrefix]
    public static bool Prefix(Projectile __instance, Bloon bloon) {
        if (bloon.bloonModel.HasTag("Orange")) {
            if (__instance.emittedBy != null) {
                string name = __instance.emittedBy.towerModel.GetBaseId();
                if (name == "GlueGunner") {
                    return false;
                }
            }
        }

        if (bloon.bloonModel.HasTag("Cyan")) {
            if (__instance.emittedBy != null) {
                string name = __instance.emittedBy.towerModel.GetBaseId();
                if (name == "MonkeySub" || name == "MonkeyBuccaneer") {
                    return false;
                }
            }
        }

        if (bloon.bloonModel.HasTag("Primary")) {
            if (__instance.emittedBy != null) {
                string name = __instance.emittedBy.towerModel.GetTowerSet();
                if (name == "Primary") {
                    return false;
                }
            }
        }

        if (bloon.bloonModel.HasTag("Military")) {
            if (__instance.emittedBy != null) {
                string name = __instance.emittedBy.towerModel.GetTowerSet();
                if (name == "Military") {
                    return false;
                }
            }
        }

        if (bloon.bloonModel.HasTag("Magic")) {
            if (__instance.emittedBy != null) {
                string name = __instance.emittedBy.towerModel.GetTowerSet();
                if (name == "Magic") {
                    return false;
                }
            }
        }

        if (bloon.bloonModel.HasTag("Support")) {
            if (__instance.emittedBy != null) {
                string name = __instance.emittedBy.towerModel.GetTowerSet();
                if (name == "Support") {
                    return false;
                }
            }
        }

        return true;
    }
}