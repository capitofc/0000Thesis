using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveData
{
    [SerializeField]
    private static List<PlayerData> PlayerDataList = new List<PlayerData>();
    private static string path = Application.persistentDataPath + "/GameData.Thesis";

    public static void SaveDataProgress(PlayerData player)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        if (File.Exists(path))
        {
            bool isPlayerExist = false;
            FileStream stream = new FileStream(path, FileMode.Open);
            PlayerDataList = formatter.Deserialize(stream) as List<PlayerData>;
            foreach(PlayerData PlayerStorage in PlayerDataList)
            {
                if (PlayerStorage.playerName.Equals(player.playerName))
                {
                    isPlayerExist = true;
                    PlayerStorage.playerName = player.playerName;
                    PlayerStorage.playerMoney = player.playerMoney;
                    PlayerStorage.playerLevelCapacity = player.playerLevelCapacity;
                    PlayerStorage.playerLevel = player.playerLevel;
                    PlayerStorage.playerCurrentExp = player.playerCurrentExp;
                    PlayerStorage.UnlockCharacter = player.UnlockCharacter;
                    PlayerStorage.UnlockedStages = player.UnlockedStages;
                    PlayerStorage.UsedCharacter = player.UsedCharacter;
                    break;
                }
            }
            if(isPlayerExist == false)
            {
                PlayerDataList.Add(player);
            }
            formatter.Serialize(stream, PlayerDataList);
            stream.Close();
        }
        else
        {
            FileStream stream = new FileStream(path, FileMode.Create);
            PlayerDataList.Add(player);
            formatter.Serialize(stream, PlayerDataList);
            stream.Close();
        }
    }
}
