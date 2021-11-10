using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelection : MonoBehaviour
{
    [Header("Navigation Buttons")] //unused
    [SerializeField] private Button previousButton;
    [SerializeField] private Button nextButton;

    [Header("Play/Buy Buttons")]
    [SerializeField] private Button play;
    [SerializeField] private Button buy;
    [SerializeField] private Text price;
    [SerializeField] private Text penguinNameText;


    [Header("Skin Texts")]
    [SerializeField] private int[] penguinPrices;
    [SerializeField] private string[] penguinName;

    public bool[] unlockedPenguin = new bool[9] { true, false, false, true, false, false, true, false, false };
    [SerializeField] public GameObject[] characterPrefab; //characterPrefab[0] = unlockedPenguin[0]
    public bool[] equippedPenguin = new bool[9] { true, false, false, false, false, false, false, false, false };


    private int currentPenguin;

    private void Start()
    {
        //currentPenguin = PlayerData.currentPenguin;
        currentPenguin = 0;
        SelectPenguin(currentPenguin);
    }

    //penguin selection
    public void pickPenguin(int _index)
    {
        currentPenguin = _index;
        // SaveManager.instance.currentPenguin = currentPenguin;
        // SaveManager.instance.Save();
        SelectPenguin(currentPenguin);
    }

    private void SelectPenguin(int _index)
    {
        for (int i = 0; i < transform.childCount; i++)
            transform.GetChild(i).gameObject.SetActive(i == _index);
        updateUI();
    }

    private void updateUI()
    {
        if (PlayerData.instance.UnlockCharacter[currentPenguin])
        {
            play.gameObject.SetActive(true);
            buy.gameObject.SetActive(false);
        }

        else
        {
            play.gameObject.SetActive(false);
            buy.gameObject.SetActive(true);
            price.text = "₱" + penguinPrices[currentPenguin];
        }
    }

    private void Update()
    {
        penguinNameText.text = penguinName[currentPenguin];

        if (buy.gameObject.activeInHierarchy)
        {
            //checks if money is enough
            buy.interactable = (PlayerData.instance.playerMoney >= penguinPrices[currentPenguin]);
        }

        if (play.gameObject.activeInHierarchy)
            play.interactable = (!PlayerData.equippedPenguin[currentPenguin]); 

        if (Input.GetKeyDown(KeyCode.R)) //resets price
            resetPrice();
    }

    public void ChangePenguin(int _change) //unused `for prev and next buttons
    {
        currentPenguin += _change;

        if (currentPenguin > transform.childCount - 1)
            currentPenguin = 0;
        else if (currentPenguin < 0)
            currentPenguin = transform.childCount - 1;

        //SaveManager.instance.currentPenguin = currentPenguin;
        //SaveManager.instance.Save();
        SelectPenguin(currentPenguin);
    }

    public void buyPenguin()
    {
        PlayerData.money -= penguinPrices[currentPenguin];
        PlayerData.unlockedPenguin[currentPenguin] = true;
        //SaveManager.instance.Save();
        updateUI();
    }

    public void equipPenguin() // non-dymanic
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            unEquip(i);
        }
        PlayerData.instance[currentPenguin] = true;
        DataSystem.updatePlayerData();
    }

    private void unEquip(int index)
    {
        PlayerData.equippedPenguin[index] = false;
    }

    public void resetPrice()
    {
        PlayerData.unlockedPenguin[currentPenguin] = false;
        PlayerData.equippedPenguin[currentPenguin] = false;
        // SaveManager.instance.Save();
    }
}
