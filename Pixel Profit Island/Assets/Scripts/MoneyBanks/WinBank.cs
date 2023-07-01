using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class WinBank : MonoBehaviour
{
    [SerializeField] float currentValue = 0.00f;
    public float GetCurrentValue() { return currentValue; }
    float printedValue = 0.00f;
    public float GetPrintedValue() { return printedValue; }


    [Header("References that this script is dependant on")]
    [SerializeField] CalculationMaster calcMaster;
    [SerializeField] PlayingState playingState;

    public event Action onShiftingValue;

    const float shiftTime = .1f;

    //Money from payout queue is added to the Win Bank
    private async void AddToCurrentValue(float valueToAdd, float discard) //discard is there to match event values
    {
        currentValue += valueToAdd;
        await ValueShifting(shiftTime);
    }

    //Slowly increases/decreases the printedValue for a gaining money / losing money effect
    async Task ValueShifting(float _shiftTime)
    {
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

    //Resets Win Bank value to 0
    private async void ResetMoney()
    {
        currentValue = 0;
        await ValueShifting(shiftTime);
    }



    void OnEnable()
    {
        calcMaster.onMoneyAquiredFromChestPress += AddToCurrentValue;
        playingState.onPlayBeginning += ResetMoney;
    }

    void OnDisable()
    {
        calcMaster.onMoneyAquiredFromChestPress -= AddToCurrentValue;
        playingState.onPlayBeginning -= ResetMoney;
    }
}
