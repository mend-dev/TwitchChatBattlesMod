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

class MilitaryBloon : ModBloon {
    public override string Name => "Military";
    public override string DisplayName => "Military";
    public override string BaseBloon => BloonType.Purple;
    public override string Icon => "Military";
    public override bool UseIconAsDisplay => true;
    public override void ModifyBaseBloonModel(BloonModel bloon) {
        bloon.AddTag("Military");
    }
}

class MilitaryBloonDisplay : ModBloonDisplay<MilitaryBloon> {
    public override string BaseDisplay => GetBloonDisplay("Purple");
    public override void ModifyDisplayNode(UnityDisplayNode node) {
        Set2DTexture(node, "Military");
    }
}

class MilitaryRegrow : ModBloon<MilitaryBloon> {
    public override bool Regrow => true;

    public override void ModifyBaseBloonModel(BloonModel bloonModel) {
        bloonModel.MakeChildrenRegrow();
    }
}

class MilitaryRegrowDisplay : ModBloonDisplay<MilitaryRegrow> {
    public override string BaseDisplay => GetBloonDisplay("PurpleRegrow");
    public override void ModifyDisplayNode(UnityDisplayNode node) {
        Set2DTexture(node, "RegrowMilitary");
    }
}

class MilitaryCamo : ModBloon<MilitaryBloon> {
    public override bool Camo => true;

    public override void ModifyBaseBloonModel(BloonModel bloonModel) {
        bloonModel.MakeChildrenCamo();
    }
}

class MilitaryCamoDisplay : ModBloonDisplay<MilitaryCamo> {
    public override string BaseDisplay => GetBloonDisplay("PurpleCamo");
    public override void ModifyDisplayNode(UnityDisplayNode node) {
        Set2DTexture(node, "CamoMilitary");
    }
}

class MilitaryRegrowCamo : ModBloon<MilitaryBloon> {
    public override bool Regrow => true;
    public override bool Camo => true;

    public override void ModifyBaseBloonModel(BloonModel bloonModel) {
        bloonModel.MakeChildrenRegrow();
        bloonModel.MakeChildrenCamo();
    }
}

class MilitaryRegrowCamoDisplay : ModBloonDisplay<MilitaryRegrowCamo> {
    public override string BaseDisplay => GetBloonDisplay("PurpleRegrowCamo");
    public override void ModifyDisplayNode(UnityDisplayNode node) {
        Set2DTexture(node, "RegrowCamoMilitary");
    }
}