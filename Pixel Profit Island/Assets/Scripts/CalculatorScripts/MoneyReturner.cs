using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

public class MoneyReturner : MonoBehaviour
{

    //A queue of all the chest payouts that will happen
    private Queue<float> payoutChunks;

    public float GetNextPayout()
    {
        if (payoutChunks.Count <= 0) { return 0f; }

        return payoutChunks.Dequeue();
    }

    public void GenerateMoneyReturn(float wager, int multiplyer)
    {
        payoutChunks = GenerateMoneyReturnQueueCalculations(wager, multiplyer);
    }

    //takes the wager and multiplyer and generates the payoutChunks queue
    //If multiplyer is 0 returns empty queue, otherwise returns a queue size 1-8 with 
    //acceptable money values
    public Queue<float> GenerateMoneyReturnQueueCalculations(float wager, int multiplyer)
    {
        Queue<float> returnQueue = new Queue<float>();

        if (multiplyer == 0) { return returnQueue; }


        float returnValue = wager * (float)multiplyer;

        int intendedSplits = UnityEngine.Random.Range(1, 9); //1 to 8 splits

        float moneyAccountedFor = 0;

        float tempVal = -1;
        for (int i = 0; i < intendedSplits - 1; i++)
        {
            tempVal = UnityEngine.Random.Range(0.05f, returnValue - moneyAccountedFor);

            tempVal = (float)Math.Round(tempVal * 100f) / 100f; //Should Round to nearest cent

            tempVal = tempVal - (tempVal % .05f); //Round down to the nearest 5 cents

            moneyAccountedFor += tempVal;
            returnQueue.Enqueue(tempVal);

            if (moneyAccountedFor >= returnValue) { return returnQueue; } //shouldn't be greater, could be equal. Just good coding pracitce
        }

        tempVal = (float)Math.Round((returnValue - moneyAccountedFor) * 100f) / 100f;
        returnQueue.Enqueue(tempVal);


        return returnQueue;
    }
}
