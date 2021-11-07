using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerExpCalculator : MonoBehaviour
{
    public static PlayerExpCalculator instance;
    private void Start()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    public void UpdatePlayerLevel()
    {
        if(PlayerData.instance.playerCurrentExp > PlayerData.instance.playerLevelCapacity)
        {
            float newCurrentExp = PlayerData.instance.playerCurrentExp - PlayerData.instance.playerLevelCapacity;
            float newPlayerLevelCapacity = PlayerData.instance.playerLevelCapacity + (PlayerData.instance.playerLevelCapacity * 0.5f);
            int newPlayerLevel = PlayerData.instance.playerLevel + 1;
            SaveProgress.instance.UpdatePlayerData(PlayerData.instance.playerName,
                                                    PlayerData.instance.playerMoney,
                                                    newPlayerLevel, newCurrentExp, newPlayerLevelCapacity,
                                                    PlayerData.instance.UnlockedStages, PlayerData.instance.UnlockCharacter, PlayerData.instance.UsedCharacter);
            PlayerData.instance.playerCurrentExp = newCurrentExp;
            PlayerData.instance.playerLevelCapacity = newPlayerLevelCapacity;
            PlayerData.instance.playerLevel = newPlayerLevel;
        }
    }
}
