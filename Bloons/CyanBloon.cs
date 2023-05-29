using MelonLoader;
using BTD_Mod_Helper;
using BTD_Mod_Helper.Api.Bloons;
using BTD_Mod_Helper.Api.Enums;
using Il2CppAssets.Scripts.Models.Rounds;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Unity;
using TwitchChatBattlesMod;
using Il2CppAssets.Scripts.Models.Bloons;
using BTD_Mod_Helper.Api.Display;
using Il2CppAssets.Scripts.Unity.Display;
using Il2CppAssets.Scripts.Models.Bloons.Behaviors.Actions;
using Il2CppAssets.Scripts.Models.Bloons.Behaviors;

namespace TwitchChatBattlesMod;

class CyanBloon : ModBloon {
    public override string Name => "Cyan";
    public override string DisplayName => "Cyan";
    public override string BaseBloon => BloonType.Rainbow;
    public override string Icon => "Cyan";
    public override bool UseIconAsDisplay => true;
    public override void ModifyBaseBloonModel(BloonModel bloon) {
        bloon.AddTag("Cyan");
    }
}

class CyanBloonDisplay : ModBloonDisplay<CyanBloon> {
    public override string BaseDisplay => GetBloonDisplay("Rainbow");
    public override void ModifyDisplayNode(UnityDisplayNode node) {
        Set2DTexture(node, "Cyan");
    }
}

class CyanRegrow : ModBloon<CyanBloon> {
    public override bool Regrow => true;

    public override void ModifyBaseBloonModel(BloonModel bloonModel) {
        bloonModel.MakeChildrenRegrow();
    }
}

class CyanRegrowDisplay : ModBloonDisplay<CyanRegrow> {
    public override string BaseDisplay => GetBloonDisplay("RainbowRegrow");
    public override void ModifyDisplayNode(UnityDisplayNode node) {
        Set2DTexture(node, "RegrowCyan");
    }
}

class CyanCamo : ModBloon<CyanBloon> {
    public override bool Camo => true;

    public override void ModifyBaseBloonModel(BloonModel bloonModel) {
        bloonModel.MakeChildrenCamo();
    }
}

class CyanCamoDisplay : ModBloonDisplay<CyanCamo> {
    public override string BaseDisplay => GetBloonDisplay("RainbowCamo");
    public override void ModifyDisplayNode(UnityDisplayNode node) {
        Set2DTexture(node, "CamoCyan");
    }
}

class CyanRegrowCamo : ModBloon<CyanBloon> {
    public override bool Regrow => true;
    public override bool Camo => true;

    public override void ModifyBaseBloonModel(BloonModel bloonModel) {
        bloonModel.MakeChildrenRegrow();
        bloonModel.MakeChildrenCamo();
    }
}

class CyanRegrowCamoDisplay : ModBloonDisplay<CyanRegrowCamo> {
    public override string BaseDisplay => GetBloonDisplay("RainbowRegrowCamo");
    public override void ModifyDisplayNode(UnityDisplayNode node) {
        Set2DTexture(node, "RegrowCamoCyan");
    }
}