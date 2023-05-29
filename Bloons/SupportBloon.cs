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

class SupportBloon : ModBloon {
    public override string Name => "Support";
    public override string DisplayName => "Support";
    public override string BaseBloon => BloonType.Purple;
    public override string Icon => "Support";
    public override bool UseIconAsDisplay => true;
    public override void ModifyBaseBloonModel(BloonModel bloon) {
        bloon.AddTag("Support");
    }
}

class SupportBloonDisplay : ModBloonDisplay<SupportBloon> {
    public override string BaseDisplay => GetBloonDisplay("Purple");
    public override void ModifyDisplayNode(UnityDisplayNode node) {
        Set2DTexture(node, "Support");
    }
}

class SupportRegrow : ModBloon<SupportBloon> {
    public override bool Regrow => true;

    public override void ModifyBaseBloonModel(BloonModel bloonModel) {
        bloonModel.MakeChildrenRegrow();
    }
}

class SupportRegrowDisplay : ModBloonDisplay<SupportRegrow> {
    public override string BaseDisplay => GetBloonDisplay("PurpleRegrow");
    public override void ModifyDisplayNode(UnityDisplayNode node) {
        Set2DTexture(node, "RegrowSupport");
    }
}

class SupportCamo : ModBloon<SupportBloon> {
    public override bool Camo => true;

    public override void ModifyBaseBloonModel(BloonModel bloonModel) {
        bloonModel.MakeChildrenCamo();
    }
}

class SupportCamoDisplay : ModBloonDisplay<SupportCamo> {
    public override string BaseDisplay => GetBloonDisplay("PurpleCamo");
    public override void ModifyDisplayNode(UnityDisplayNode node) {
        Set2DTexture(node, "CamoSupport");
    }
}

class SupportRegrowCamo : ModBloon<SupportBloon> {
    public override bool Regrow => true;
    public override bool Camo => true;

    public override void ModifyBaseBloonModel(BloonModel bloonModel) {
        bloonModel.MakeChildrenRegrow();
        bloonModel.MakeChildrenCamo();
    }
}

class SupportRegrowCamoDisplay : ModBloonDisplay<SupportRegrowCamo> {
    public override string BaseDisplay => GetBloonDisplay("PurpleRegrowCamo");
    public override void ModifyDisplayNode(UnityDisplayNode node) {
        Set2DTexture(node, "RegrowCamoSupport");
    }
}