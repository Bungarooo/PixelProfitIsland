using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class BalanceObserver : MonoBehaviour
{
    [SerializeField] Balance balanceAmount;

    void Start()
    {
        SynchronizeBalanceUI();
    }

    private void SynchronizeBalanceUI()
    {
        this.GetComponent<TMP_Text>().text = balanceAmount.GetPrintedValue().ToString("C2");
    }

    void OnEnable()
    {
        balanceAmount.onShiftingValue += SynchronizeBalanceUI;
    }

    void OnDisable()
    {
        balanceAmount.onShiftingValue -= SynchronizeBalanceUI;
    }
}
