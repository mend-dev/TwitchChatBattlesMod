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

class MendBloon : ModBloon {
    public override string Name => "Mend";
    public override string DisplayName => "Mend";
    public override string BaseBloon => BloonType.Pink;
    public override string Icon => "Mend";
    public override bool UseIconAsDisplay => true;
    public override void ModifyBaseBloonModel(BloonModel bloon) {
        bloon.AddTag("Mend");
    }
}

class MendBloonDisplay : ModBloonDisplay<MendBloon> {
    public override string BaseDisplay => GetBloonDisplay("Pink");
    public override void ModifyDisplayNode(UnityDisplayNode node) {
        Set2DTexture(node, "Mend");
    }
}

class MendRegrow : ModBloon<MendBloon> {
    public override bool Regrow => true;

    public override void ModifyBaseBloonModel(BloonModel bloonModel) {
        bloonModel.MakeChildrenRegrow();
    }
}

class MendRegrowDisplay : ModBloonDisplay<MendRegrow> {
    public override string BaseDisplay => GetBloonDisplay("PinkRegrow");
    public override void ModifyDisplayNode(UnityDisplayNode node) {
        Set2DTexture(node, "RegrowMend");
    }
}

class MendCamo : ModBloon<MendBloon> {
    public override bool Camo => true;

    public override void ModifyBaseBloonModel(BloonModel bloonModel) {
        bloonModel.MakeChildrenCamo();
    }
}

class MendCamoDisplay : ModBloonDisplay<MendCamo> {
    public override string BaseDisplay => GetBloonDisplay("PinkCamo");
    public override void ModifyDisplayNode(UnityDisplayNode node) {
        Set2DTexture(node, "CamoMend");
    }
}

class MendRegrowCamo : ModBloon<MendBloon> {
    public override bool Regrow => true;
    public override bool Camo => true;

    public override void ModifyBaseBloonModel(BloonModel bloonModel) {
        bloonModel.MakeChildrenRegrow();
        bloonModel.MakeChildrenCamo();
    }
}

class MendRegrowCamoDisplay : ModBloonDisplay<MendRegrowCamo> {
    public override string BaseDisplay => GetBloonDisplay("PinkRegrowCamo");
    public override void ModifyDisplayNode(UnityDisplayNode node) {
        Set2DTexture(node, "RegrowCamoMend");
    }
}