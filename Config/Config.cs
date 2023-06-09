﻿using System.Collections.Generic;

namespace TwitchChatBattlesMod;

public static class ModConfig {

    // General
    public static int HardBloonCap = 100;

    // Bloons
    public static readonly string[] ValidBloons = new string[] {
        "cyan",
        "magic",
        "military",
        "orange",
        "primary",
        "support",
        "red",
        "blue",
        "green",
        "yellow",
        "pink",
        "black",
        "white",
        "purple",
        "zebra",
        "lead",
        "rainbow",
        "ceramic",
        "moab",
        "bfb",
        "zomg",
        "ddt",
        "bad",
        "testbloon",
        "bloonarius",
        "dreadbloon",
        "lych",
        "vortex"
    };

    public static readonly string[] BloonIds = new string[] {
        "TwitchChatBattlesMod-Cyan",
        "TwitchChatBattlesMod-CyanRegrow",
        "TwitchChatBattlesMod-CyanRegrowCamo",
        "TwitchChatBattlesMod-CyanCamo",
        "TwitchChatBattlesMod-Magic",
        "TwitchChatBattlesMod-MagicRegrow",
        "TwitchChatBattlesMod-MagicRegrowCamo",
        "TwitchChatBattlesMod-MagicCamo",
        "TwitchChatBattlesMod-Military",
        "TwitchChatBattlesMod-MilitaryRegrow",
        "TwitchChatBattlesMod-MilitaryRegrowCamo",
        "TwitchChatBattlesMod-MilitaryCamo",
        "TwitchChatBattlesMod-Orange",
        "TwitchChatBattlesMod-OrangeRegrow",
        "TwitchChatBattlesMod-OrangeRegrowCamo",
        "TwitchChatBattlesMod-OrangeCamo",
        "TwitchChatBattlesMod-Primary",
        "TwitchChatBattlesMod-PrimaryRegrow",
        "TwitchChatBattlesMod-PrimaryRegrowCamo",
        "TwitchChatBattlesMod-PrimaryCamo",
        "TwitchChatBattlesMod-Support",
        "TwitchChatBattlesMod-SupportRegrow",
        "TwitchChatBattlesMod-SupportRegrowCamo",
        "TwitchChatBattlesMod-SupportCamo",
        "Red",
        "RedRegrow",
        "RedRegrowCamo",
        "RedCamo",
        "Blue",
        "BlueRegrow",
        "BlueRegrowCamo",
        "BlueCamo",
        "Green",
        "GreenRegrow",
        "GreenRegrowCamo",
        "GreenCamo",
        "Yellow",
        "YellowRegrow",
        "YellowRegrowCamo",
        "YellowCamo",
        "Pink",
        "PinkRegrow",
        "PinkRegrowCamo",
        "PinkCamo",
        "Black",
        "BlackRegrow",
        "BlackRegrowCamo",
        "BlackCamo",
        "White",
        "WhiteRegrow",
        "WhiteRegrowCamo",
        "WhiteCamo",
        "Purple",
        "PurpleRegrow",
        "PurpleRegrowCamo",
        "PurpleCamo",
        "Zebra",
        "ZebraRegrow",
        "ZebraRegrowCamo",
        "ZebraCamo",
        "Lead",
        "LeadRegrow",
        "LeadRegrowFortified",
        "LeadRegrowFortifiedCamo",
        "LeadRegrowCamo",
        "LeadFortified",
        "LeadFortifiedCamo",
        "LeadCamo",
        "Rainbow",
        "RainbowRegrow",
        "RainbowRegrowCamo",
        "RainbowCamo",
        "Ceramic",
        "CeramicRegrow",
        "CeramicRegrowFortified",
        "CeramicRegrowFortifiedCamo",
        "CeramicRegrowCamo",
        "CeramicFortified",
        "CeramicFortifiedCamo",
        "CeramicCamo",
        "Moab",
        "MoabFortified",
        "Bfb",
        "BfbFortified",
        "Zomg",
        "ZomgFortified",
        "Ddt",
        "DdtFortified",
        "DdtFortifiedCamo",
        "DdtCamo",
        "Bad",
        "BadFortified",
        "TestBloon",
        "Bloonarius1",
        "Bloonarius2",
        "Bloonarius3",
        "Bloonarius4",
        "Bloonarius5",
        "Dreadbloon1",
        "Dreadbloon2",
        "Dreadbloon3",
        "Dreadbloon4",
        "Dreadbloon5",
        "Lych1",
        "Lych2",
        "Lych3",
        "Lych4",
        "Lych5",
        "Vortex1",
        "Vortex2",
        "Vortex3",
        "Vortex4",
        "Vortex5"
    };

    public static readonly Dictionary<string, int> MinBloonRounds = new Dictionary<string, int>() {
        ["cyan"] = 31,
        ["magic"] = 22,
        ["military"] = 21,
        ["orange"] = 16,
        ["primary"] = 20,
        ["support"] = 23,
        ["red"] = 2,
        ["blue"] = 4,
        ["green"] = 6,
        ["yellow"] = 10,
        ["pink"] = 12,
        ["black"] = 18,
        ["white"] = 18,
        ["purple"] = 21,
        ["zebra"] = 22,
        ["lead"] = 24,
        ["rainbow"] = 30,
        ["ceramic"] = 32,
        ["moab"] = 35,
        ["bfb"] = 55,
        ["zomg"] = 75,
        ["ddt"] = 85,
        ["bad"] = 95,
        ["testbloon"] = 69,
        ["bloonarius"] = 40,
        ["dreadbloon"] = 40,
        ["lych"] = 40,
        ["vortex"] = 40,
    };

    public static readonly Dictionary<string, int> BaseMaxBloonAmounts = new Dictionary<string, int>() {
        ["cyan"] = 25,
        ["magic"] = 30,
        ["military"] = 30,
        ["orange"] = 35,
        ["primary"] = 30,
        ["support"] = 30,
        ["red"] = 75,
        ["blue"] = 60,
        ["green"] = 50,
        ["yellow"] = 40,
        ["pink"] = 40,
        ["black"] = 35,
        ["white"] = 35,
        ["purple"] = 30,
        ["zebra"] = 30,
        ["lead"] = 25,
        ["rainbow"] = 25,
        ["ceramic"] = 20,
        ["moab"] = 8,
        ["bfb"] = 6,
        ["zomg"] = 4,
        ["ddt"] = 10,
        ["bad"] = 1,
        ["testbloon"] = 1,
        ["bloonarius"] = 1,
        ["dreadbloon"] = 1,
        ["lych"] = 1,
        ["vortex"] = 1,
    };

    public static readonly Dictionary<string, float> MaxAmountRoundMultiplier = new Dictionary<string, float>() {
        ["cyan"] = 0.5f,
        ["magic"] = 1,
        ["military"] = 1,
        ["orange"] = 1,
        ["primary"] = 1,
        ["support"] = 1,
        ["red"] = 1,
        ["blue"] = 1,
        ["green"] = 1,
        ["yellow"] = 1,
        ["pink"] = 1,
        ["black"] = 1,
        ["white"] = 1,
        ["purple"] = 1,
        ["zebra"] = 1,
        ["lead"] = 1,
        ["rainbow"] = 0.5f,
        ["ceramic"] = 0.5f,
        ["moab"] = 0.25f,
        ["bfb"] = 0.25f,
        ["zomg"] = 0.125f,
        ["ddt"] = 0.25f,
        ["bad"] = 0.0625f,
        ["testbloon"] = 0,
        ["bloonarius"] = 0,
        ["dreadbloon"] = 0,
        ["lych"] = 0,
        ["vortex"] = 0,
    };

    public static readonly Dictionary<string, double> BaseBloonValues = new Dictionary<string, double>() {
        ["cyan"] = 47d,
        ["magic"] = 11d,
        ["military"] = 11d,
        ["orange"] = 11d,
        ["primary"] = 11d,
        ["support"] = 11d,
        ["red"] = 1d,
        ["blue"] = 2d,
        ["green"] = 3d,
        ["yellow"] = 4d,
        ["pink"] = 5d,
        ["black"] = 11d,
        ["white"] = 11d,
        ["purple"] = 11d,
        ["zebra"] = 23d,
        ["lead"] = 23d,
        ["rainbow"] = 47d,
        ["ceramic"] = 95d,
        ["moab"] = 381d,
        ["bfb"] = 1525d,
        ["zomg"] = 6101d,
        ["ddt"] = 381d,
        ["bad"] = 13346d,
        ["testbloon"] = 0d,
        ["bloonarius"] = 0d,
        ["dreadbloon"] = 0d,
        ["lych"] = 0d,
        ["vortex"] = 0d,
    };

    public static readonly Dictionary<string, int> BloonCooldowns = new Dictionary<string, int>() {
        ["cyan"] = 10,
        ["magic"] = 8,
        ["military"] = 8,
        ["orange"] = 7,
        ["primary"] = 8,
        ["support"] = 8,
        ["red"] = 2,
        ["blue"] = 3,
        ["green"] = 4,
        ["yellow"] = 5,
        ["pink"] = 6,
        ["black"] = 7,
        ["white"] = 7,
        ["purple"] = 8,
        ["zebra"] = 8,
        ["lead"] = 9,
        ["rainbow"] = 10,
        ["ceramic"] = 10,
        ["moab"] = 15,
        ["bfb"] = 20,
        ["zomg"] = 25,
        ["ddt"] = 30,
        ["bad"] = 30,
        ["testbloon"] = 69,
        ["bloonarius"] = 300,
        ["dreadbloon"] = 300,
        ["lych"] = 300,
        ["vortex"] = 300,
    };


    // Modifier Checks
    public static readonly string[] BloonsWithRegrow = new string[] {
        "cyan",
        "magic",
        "military",
        "orange",
        "primary",
        "support",
            "red",
            "blue",
            "green",
            "yellow",
            "pink",
            "black",
            "white",
            "purple",
            "zebra",
            "lead",
            "rainbow",
            "ceramic",
    };

    public static readonly string[] BloonsWithCamo = new string[] {
        "cyan",
        "magic",
        "military",
        "orange",
        "primary",
        "support",
            "red",
            "blue",
            "green",
            "yellow",
            "pink",
            "black",
            "white",
            "purple",
            "zebra",
            "lead",
            "rainbow",
            "ceramic",
            "ddt",
    };

    public static readonly string[] BloonsWithFortified = new string[] {
            "lead",
            "ceramic",
            "moab",
            "bfb",
            "zomg",
            "ddt",
            "bad"
    };

    // Bloon Modifiers
    public static readonly int MinRegrowRound = 10;
    public static readonly int MinCamoRound = 15;
    public static readonly int MinFortifiedRound = 20;
    public static readonly int RegrowMaxModifier = 10;
    public static readonly int CamoMaxModifier = 10;
    public static readonly int FortifiedMaxModifier = 10;
}