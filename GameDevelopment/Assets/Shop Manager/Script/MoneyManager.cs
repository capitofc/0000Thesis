using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            PlayerData.instance.playerMoney += 100;
        }


        else if (Input.GetKeyDown(KeyCode.F))
        {
            PlayerData.instance.playerMoney -= 100;
        }

    }
}
