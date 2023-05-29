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

class PrimaryBloon : ModBloon {
    public override string Name => "Primary";
    public override string DisplayName => "Primary";
    public override string BaseBloon => BloonType.Purple;
    public override string Icon => "Primary";
    public override bool UseIconAsDisplay => true;
    public override void ModifyBaseBloonModel(BloonModel bloon) {
        bloon.AddTag("Primary");
    }
}

class PrimaryBloonDisplay : ModBloonDisplay<PrimaryBloon> {
    public override string BaseDisplay => GetBloonDisplay("Purple");
    public override void ModifyDisplayNode(UnityDisplayNode node) {
        Set2DTexture(node, "Primary");
    }
}

class PrimaryRegrow : ModBloon<PrimaryBloon> {
    public override bool Regrow => true;

    public override void ModifyBaseBloonModel(BloonModel bloonModel) {
        bloonModel.MakeChildrenRegrow();
    }
}

class PrimaryRegrowDisplay : ModBloonDisplay<PrimaryRegrow> {
    public override string BaseDisplay => GetBloonDisplay("PurpleRegrow");
    public override void ModifyDisplayNode(UnityDisplayNode node) {
        Set2DTexture(node, "RegrowPrimary");
    }
}

class PrimaryCamo : ModBloon<PrimaryBloon> {
    public override bool Camo => true;

    public override void ModifyBaseBloonModel(BloonModel bloonModel) {
        bloonModel.MakeChildrenCamo();
    }
}

class PrimaryCamoDisplay : ModBloonDisplay<PrimaryCamo> {
    public override string BaseDisplay => GetBloonDisplay("PurpleCamo");
    public override void ModifyDisplayNode(UnityDisplayNode node) {
        Set2DTexture(node, "CamoPrimary");
    }
}

class PrimaryRegrowCamo : ModBloon<PrimaryBloon> {
    public override bool Regrow => true;
    public override bool Camo => true;

    public override void ModifyBaseBloonModel(BloonModel bloonModel) {
        bloonModel.MakeChildrenRegrow();
        bloonModel.MakeChildrenCamo();
    }
}

class PrimaryRegrowCamoDisplay : ModBloonDisplay<PrimaryRegrowCamo> {
    public override string BaseDisplay => GetBloonDisplay("PurpleRegrowCamo");
    public override void ModifyDisplayNode(UnityDisplayNode node) {
        Set2DTexture(node, "RegrowCamoPrimary");
    }
}