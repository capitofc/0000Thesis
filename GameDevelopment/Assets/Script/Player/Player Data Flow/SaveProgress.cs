using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveProgress : MonoBehaviour
{
    public static SaveProgress instance;

    private void Start()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    public void UpdatePlayerData(string playerName, int playerMoney, int playerLevel, float playerCurrentExp, float playerLevelCapacity, bool[] UnlockedStages, bool[] UnlockedCharacter, int UseCharacter)
    {
        PlayerData.instance.playerName = playerName;
        PlayerData.instance.playerMoney = playerMoney;
        PlayerData.instance.playerLevel = playerLevel;
        PlayerData.instance.playerCurrentExp = playerCurrentExp;
        PlayerData.instance.playerLevelCapacity = playerLevelCapacity;
        PlayerData.instance.UnlockedStages = UnlockedStages;
        PlayerData.instance.UnlockCharacter = UnlockedCharacter;
        PlayerData.instance.UsedCharacter = UseCharacter;

        SaveData.SaveDataProgress(PlayerData.instance);
    }
}
