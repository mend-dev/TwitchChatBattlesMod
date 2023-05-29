using Il2CppAssets.Scripts.Models.Rounds;
using Il2CppInterop.Runtime.InteropTypes.Arrays;

namespace TwitchChatBattlesMod;

public static class Util {

    public static Il2CppReferenceArray<BloonEmissionModel> GetBloonEmissionArray(string bloon, int amount, int spawnTime) {
        Il2CppReferenceArray<BloonEmissionModel> bme = new Il2CppReferenceArray<BloonEmissionModel>(amount);
        for (int i = 0; i < bme.Length; i++) {
            bme[i] = new BloonEmissionModel(bloon, i * spawnTime, bloon);
        }
        return bme;
    }

    public static double GetBloonValue(string bloon, int amount, int round) {
        double bloonValue = ModConfig.BaseBloonValues[bloon.ToLower()];
        double adjustedBloonValue = (bloonValue * GetRoundModifier(round)) * amount;

        return adjustedBloonValue;
    }

    public static float GetRoundModifier(int round) {
        if (round >= 0 && round <= 50) {
            return 1f;
        } else if (round >= 51 && round <= 60) {
            return 0.5f;
        } else if (round >= 61 && round <= 85) {
            return 0.2f;
        } else if (round >= 86 && round <= 100) {
            return 0.1f;
        } else if (round >= 101 && round <= 120) {
            return 0.05f;
        } else if (round >= 121) {
            return 0.02f;
        }

        return 1f;
    }

    public static int GetBossLevel(int round) {
        if (round >= 0 && round <= 59) {
            return 1;
        } else if (round >= 60 && round <= 79) {
            return 2;
        } else if (round >= 80 && round <= 99) {
            return 3;
        } else if (round >= 100 && round <= 119) {
            return 4;
        } else if (round >= 120) {
            return 5;
        }
        return 1;
    }
}
