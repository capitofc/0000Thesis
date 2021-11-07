using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class CreatePlayerData
{
    private static string path = Application.persistentDataPath + "/GameData.Thesis";

    public static void CreatePlayer(string playerName)
    {
        bool isExist = false;
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            List<PlayerData> PlayerDataList = formatter.Deserialize(stream) as List<PlayerData>;
            foreach (PlayerData PlayerDataItem in PlayerDataList)
            {
                if (PlayerDataItem.playerName.Equals(playerName))
                {
                    isExist = true;
                    break;
                }
            }
            stream.Close();
        }
        else
        {
            PlayerData.instance.playerName = playerName;
            SaveData.SaveDataProgress(PlayerData.instance);
        }

        if (isExist)
        {
            //Show Panel that it exist
        }
        else
        {
            //Show panel that it is added successfully  
        }
    }
}
