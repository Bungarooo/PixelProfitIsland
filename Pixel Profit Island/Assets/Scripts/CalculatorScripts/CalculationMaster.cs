using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalculationMaster : MonoBehaviour
{
    CalculateMultiplyer calculateMultiplyer;
    MoneyReturner moneyReturner;

    private float wager;
    public float GetWager() => wager;

    private int multiplyer;
    public int GetMultiplyer() => multiplyer;

    [SerializeField] GameObject moneyBanks;

    public event Action<float, float> onMoneyAquiredFromChestPress;

    void Start()
    {
        calculateMultiplyer = this.GetComponent<CalculateMultiplyer>();
        moneyReturner = this.GetComponent<MoneyReturner>();
    }

    //Calculates wager and multiplyer, then calls moneyReturner to generate the money queue in moneyReturner.cs
    public void GameMathCalculations()
    {
        wager = moneyBanks.GetComponent<BetAmount>().GetCurrentValue();
        multiplyer = calculateMultiplyer.Calculate();
        moneyReturner.GenerateMoneyReturn(wager, multiplyer);
    }

    //When chest is pressed Dequeues from the payoutChunks queue, then invokes next stage of events
    public void OnChestPressed()
    {
        float money = moneyReturner.GetNextPayout();
        onMoneyAquiredFromChestPress.Invoke(money, wager);

    }

    void OnEnable()
    {
        AllGameStates.instance.playingState.onPlayBeginning += GameMathCalculations;
    }

    void OnDisable()
    {
        AllGameStates.instance.playingState.onPlayBeginning -= GameMathCalculations;
    }
}
