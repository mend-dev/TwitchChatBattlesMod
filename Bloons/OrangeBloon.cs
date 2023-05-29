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
using Il2CppAssets.Scripts.Simulation.Bloons;
using Il2CppAssets.Scripts.Unity.Achievements.List;

namespace TwitchChatBattlesMod;

class OrangeBloon : ModBloon {
    public override string Name => "Orange";
    public override string DisplayName => "Orange";
    public override string BaseBloon => BloonType.Black;
    public override string Icon => "Orange";
    public override bool UseIconAsDisplay => true;
    public override void ModifyBaseBloonModel(BloonModel bloon) {
        bloon.AddTag("Orange");
    }
}

class OrangeBloonDisplay : ModBloonDisplay<OrangeBloon> {
    public override string BaseDisplay => GetBloonDisplay("Black");
    public override void ModifyDisplayNode(UnityDisplayNode node) {
        Set2DTexture(node, "Orange");
    }
}

class OrangeRegrow : ModBloon<OrangeBloon> {
    public override bool Regrow => true;

    public override void ModifyBaseBloonModel(BloonModel bloonModel) {
        bloonModel.MakeChildrenRegrow();
    }
}

class OrangeRegrowDisplay : ModBloonDisplay<OrangeRegrow> {
    public override string BaseDisplay => GetBloonDisplay("BlackRegrow");
    public override void ModifyDisplayNode(UnityDisplayNode node) {
        Set2DTexture(node, "RegrowOrange");
    }
}

class OrangeCamo : ModBloon<OrangeBloon> {
    public override bool Camo => true;

    public override void ModifyBaseBloonModel(BloonModel bloonModel) {
        bloonModel.MakeChildrenCamo();
    }
}

class OrangeCamoDisplay : ModBloonDisplay<OrangeCamo> {
    public override string BaseDisplay => GetBloonDisplay("BlackCamo");
    public override void ModifyDisplayNode(UnityDisplayNode node) {
        Set2DTexture(node, "CamoOrange");
    }
}

class OrangeRegrowCamo : ModBloon<OrangeBloon> {
    public override bool Regrow => true;
    public override bool Camo => true;

    public override void ModifyBaseBloonModel(BloonModel bloonModel) {
        bloonModel.MakeChildrenRegrow();
        bloonModel.MakeChildrenCamo();
    }
}

class OrangeRegrowCamoDisplay : ModBloonDisplay<OrangeRegrowCamo> {
    public override string BaseDisplay => GetBloonDisplay("BlackRegrowCamo");
    public override void ModifyDisplayNode(UnityDisplayNode node) {
        Set2DTexture(node, "RegrowCamoOrange");
    }
}