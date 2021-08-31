using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public Text moneyLabel;
    public Text countdownLabel;

    public float MONEY = 100f;
    public float ROUND_TIME = 15f;
    public float SHOP_TIME = 30f;
    public float SPAWN_DELAY = 2f;
    public bool CAN_SPAWN_ENEMIES = false;

    private float _remainingShopTime;

    private void Start()
    {
        _remainingShopTime = SHOP_TIME;
    }

    private void Update()
    {
        if (_remainingShopTime > 0)
        {
            _remainingShopTime -= Time.deltaTime;
        }
        UpdateMoneyLabel();
        UpdateRoundTimerLabel();
    }

    private void UpdateMoneyLabel()
    {
        moneyLabel.text = "$ " + MONEY;
    }

    private void UpdateRoundTimerLabel()
    {
        countdownLabel.text = "Its shop time! you have "+ Mathf.RoundToInt(_remainingShopTime) + "s left.";
    }

    public void AddMoney(float amount)
    {
        MONEY += amount;
    }

    public void RemoveMoney(float amount)
    {
        MONEY -= amount;
    }

    public int EnemiesByRound(int round)
    {
        switch (round)
        {
            case 1:
                return 3;
            case 2:
                return 6;
            case 3:
                return 9;
            default:
                return 3;
        }
    }
}
