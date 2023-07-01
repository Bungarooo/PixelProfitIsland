using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Threading.Tasks;

public class Balance : MonoBehaviour
{
    const float purchaseValue = 10f; //Add 10 dollars to pool

    [SerializeField] float currentValue = 10.00f; //start with $10
    public float GetCurrentValue() { return currentValue; }
    float printedValue = 10.00f;
    public float GetPrintedValue() { return printedValue; }


    [Header("References that this script is dependant on")]
    [SerializeField] WinState winState;
    [SerializeField] WinBank winBank;

    [SerializeField] PurchaseScript purchaseScript;

    public event Action onShiftingValue;

    const float shiftTime = .1f;

    private async void SetToNewValue()
    {
        currentValue += winBank.GetCurrentValue();
        await ValueShifting(shiftTime);
    }

    async Task ValueShifting(float _shiftTime)
    {
        if (currentValue > printedValue)
        {
            AudioManager.instance.Play("Money Collect");
        }
        float tempValue = printedValue;
        float timer = 0f;

        while (timer < _shiftTime)
        {
            await Task.Delay((int)((_shiftTime / 10) * 1000));
            timer += _shiftTime / 10;
            printedValue = Mathf.Lerp(tempValue, currentValue, timer / _shiftTime);
            onShiftingValue.Invoke();
        }

        printedValue = currentValue;
        onShiftingValue.Invoke();
    }

    private async void SubtractBetAmount()
    {
        currentValue -= this.GetComponent<BetAmount>().GetCurrentValue();
        await ValueShifting(shiftTime);
    }

    private async void AddPurchaseMoney()
    {
        currentValue += purchaseValue;
        this.GetComponent<BetAmount>().CompareBetToBalance();
        await ValueShifting(shiftTime);
    }


    void OnEnable()
    {
        winState.onWin += SetToNewValue;
        AllGameStates.instance.playingState.onPlayBeginning += SubtractBetAmount;
        purchaseScript.onPurchase += AddPurchaseMoney;
    }

    void OnDisable()
    {
        winState.onWin -= SetToNewValue;
        AllGameStates.instance.playingState.onPlayBeginning -= SubtractBetAmount;
        purchaseScript.onPurchase -= AddPurchaseMoney;
    }
}
