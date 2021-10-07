using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyManager : MonoBehaviour
{
    private int currentPlayerMoney;

    public Text moneyText;

    public int starterMoney;

    public void Start()
    {
        currentPlayerMoney = starterMoney;
    }

    public int GetCurrentMoney()
    {
        return currentPlayerMoney;
    }

    public void AddMoney(int amount)
    {
        currentPlayerMoney += amount;
    }

    public void RemoveMoney(int amount)
    {
        currentPlayerMoney -= amount;
        Debug.Log("Removed " + amount + " from player!");
    }

    public void Update()
    {
        moneyText.text = "$" + currentPlayerMoney;
    }
}
