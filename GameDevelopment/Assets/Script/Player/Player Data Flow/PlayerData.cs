using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData : MonoBehaviour
{
    public static PlayerData instance;
    public string playerName = null;
    public int playerMoney = 0;
    public int playerLevel = 1;
    public float playerCurrentExp = 0;
    public float playerLevelCapacity = 10;
    public bool[] UnlockedStages = {true, false, false, false, false};
    public bool[] UnlockCharacter = {true, false, false, true, false, false, true, false, false};
    public int UsedCharacter = 1;

    private void Start()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
}
