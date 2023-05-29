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

class MagicBloon : ModBloon {
    public override string Name => "Magic";
    public override string DisplayName => "Magic";
    public override string BaseBloon => BloonType.Purple;
    public override string Icon => "Magic";
    public override bool UseIconAsDisplay => true;
    public override void ModifyBaseBloonModel(BloonModel bloon) {
        bloon.AddTag("Magic");
    }
}

class MagicBloonDisplay : ModBloonDisplay<MagicBloon> {
    public override string BaseDisplay => GetBloonDisplay("Purple");
    public override void ModifyDisplayNode(UnityDisplayNode node) {
        Set2DTexture(node, "Magic");
    }
}

class MagicRegrow : ModBloon<MagicBloon> {
    public override bool Regrow => true;

    public override void ModifyBaseBloonModel(BloonModel bloonModel) {
        bloonModel.MakeChildrenRegrow();
    }
}

class MagicRegrowDisplay : ModBloonDisplay<MagicRegrow> {
    public override string BaseDisplay => GetBloonDisplay("PurpleRegrow");
    public override void ModifyDisplayNode(UnityDisplayNode node) {
        Set2DTexture(node, "RegrowMagic");
    }
}

class MagicCamo : ModBloon<MagicBloon> {
    public override bool Camo => true;

    public override void ModifyBaseBloonModel(BloonModel bloonModel) {
        bloonModel.MakeChildrenCamo();
    }
}

class MagicCamoDisplay : ModBloonDisplay<MagicCamo> {
    public override string BaseDisplay => GetBloonDisplay("PurpleCamo");
    public override void ModifyDisplayNode(UnityDisplayNode node) {
        Set2DTexture(node, "CamoMagic");
    }
}

class MagicRegrowCamo : ModBloon<MagicBloon> {
    public override bool Regrow => true;
    public override bool Camo => true;

    public override void ModifyBaseBloonModel(BloonModel bloonModel) {
        bloonModel.MakeChildrenRegrow();
        bloonModel.MakeChildrenCamo();
    }
}

class MagicRegrowCamoDisplay : ModBloonDisplay<MagicRegrowCamo> {
    public override string BaseDisplay => GetBloonDisplay("PurpleRegrowCamo");
    public override void ModifyDisplayNode(UnityDisplayNode node) {
        Set2DTexture(node, "RegrowCamoMagic");
    }
}