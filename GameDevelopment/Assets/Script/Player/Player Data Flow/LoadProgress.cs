using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class LoadProgress : MonoBehaviour
{
    public static LoadProgress instance;
    private string path = Application.persistentDataPath + "/GameData.Thesis";

    private void Start()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    public void InstantiatePlayerData(string PlayerName)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(path, FileMode.Open);
        List<PlayerData> PlayerDataList = formatter.Deserialize(stream) as List<PlayerData>;
        foreach(PlayerData PlayerDataItem in PlayerDataList)
        {
            if (PlayerDataItem.playerName.Equals(PlayerName))
            {
                PlayerData.instance.playerName = PlayerDataItem.playerName;
                PlayerData.instance.playerMoney = PlayerDataItem.playerMoney;
                PlayerData.instance.playerLevelCapacity = PlayerDataItem.playerLevelCapacity;
                PlayerData.instance.playerLevel = PlayerDataItem.playerLevel;
                PlayerData.instance.playerCurrentExp = PlayerDataItem.playerCurrentExp;
                PlayerData.instance.UsedCharacter = PlayerDataItem.UsedCharacter;
                PlayerData.instance.UnlockCharacter = PlayerDataItem.UnlockCharacter;
                PlayerData.instance.UnlockedStages = PlayerDataItem.UnlockedStages;
                break;
            }
        }
        stream.Close();
    }
}
