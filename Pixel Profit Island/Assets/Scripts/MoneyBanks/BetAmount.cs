using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BetAmount : MonoBehaviour
{
    [SerializeField] float currentValue = 0.25f;
    public float GetCurrentValue() { return currentValue; }
    int index = 0;

    [SerializeField] float[] possibleValues; // [0.25,0.5,1,5]

    public event Action onValueChange;

    public event Action onBetLessThanBalance;
    public event Action onBetNotLessThanBalance;

    //Iterates the toggles to the next lower value, plays sound if value changes
    public void IterateLeft()
    {
        if (index > 0) { index--; AudioManager.instance.Play("Toggle"); }

        currentValue = possibleValues[index];

        onValueChange.Invoke();

        CompareBetToBalance();
    }

    //Iterates the toggles to the next higher value, plays sound if value changes
    public void IterateRight()
    {
        if (index < possibleValues.Length - 1) { index++; AudioManager.instance.Play("Toggle"); }

        currentValue = possibleValues[index];

        onValueChange.Invoke();

        CompareBetToBalance();
    }

    //Checks if the bet is higher than balance. Will disable appropriate buttons if it is. Will enable appropriate if it isn't
    public void CompareBetToBalance()
    {
        if (currentValue <= this.GetComponent<Balance>().GetCurrentValue())
        {
            onBetNotLessThanBalance.Invoke();
        }
        else
        {
            onBetLessThanBalance.Invoke();
        }
    }

    void OnEnable()
    {
        AllGameStates.instance.notPlayingState.onBoardReset += CompareBetToBalance;
    }
    void OnDisable()
    {
        AllGameStates.instance.notPlayingState.onBoardReset -= CompareBetToBalance;
    }
}
