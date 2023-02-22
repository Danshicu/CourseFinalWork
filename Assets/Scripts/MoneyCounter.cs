using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyCounter : MonoBehaviour
{
    private int _currentMoney;
    private int _totalMoney;
    public Action<int> setMoney;

    private void Start()
    {
        _currentMoney = 0;
        _totalMoney = PlayerPrefs.GetInt("TotalMoney");
    }

    public void SaveMoney()
    {
        PlayerPrefs.SetInt("TotalMoney",_totalMoney+_currentMoney);
    }

    public void AddMoney(int value)
    {
        _currentMoney += value;
        setMoney?.Invoke(_currentMoney);
    }
}
