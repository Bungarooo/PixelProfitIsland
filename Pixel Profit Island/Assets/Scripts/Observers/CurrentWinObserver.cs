using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class CurrentWinObserver : MonoBehaviour
{
    [SerializeField] WinBank winAmount;

    void Start()
    {
        SynchronizeWinBankUI();
    }

    private void SynchronizeWinBankUI()
    {
        this.GetComponent<TMP_Text>().text = winAmount.GetPrintedValue().ToString("C2");
    }

    void OnEnable()
    {
        winAmount.onShiftingValue += SynchronizeWinBankUI;
    }

    void OnDisable()
    {
        winAmount.onShiftingValue -= SynchronizeWinBankUI;
    }
}
