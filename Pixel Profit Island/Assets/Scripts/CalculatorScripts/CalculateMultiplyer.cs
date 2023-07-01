using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalculateMultiplyer : MonoBehaviour
{
    const int failPercent = 50;
    const int lowerMultiplyersPercent = 30;
    [SerializeField] int[] possibleLowerMultiplyerValues;

    const int middleMultiplyerPercent = 15;
    [SerializeField] int[] possibleMiddleMultiplyerValues;
    const int higherMultiplyerPercent = 5;
    [SerializeField] int[] possibleHigherMultiplyerValues;

    //Generates a multiplyer value with randomness based on the data above
    //50 percent chance will return 0
    //30 percent chance will return random possibleLowerMultiplyerValues (check serialized field values)
    //15 percent chance will return random possibleMiddleMultiplyerValues (check serialized field values)
    //5 percent chance will return random possibleHigherMultiplyerValues (check serialized field values)
    public int Calculate()
    {
        int generatedNumber = Random.Range(0, 100);

        //Fail State 0-49 inclusive
        if (generatedNumber < failPercent)
        {
            return 0;
        }
        //Lower Multiplyer 50-79 inclusive
        else if (generatedNumber < failPercent + lowerMultiplyersPercent)
        {
            return possibleLowerMultiplyerValues[Random.Range(0, possibleLowerMultiplyerValues.Length)];
        }
        //Middle Multiplyer 80-94 inclusive
        else if (generatedNumber < failPercent + lowerMultiplyersPercent + middleMultiplyerPercent)
        {
            return possibleMiddleMultiplyerValues[Random.Range(0, possibleMiddleMultiplyerValues.Length)];
        }
        //Higher Multiplyer 95-99 inclusive
        else
        {
            return possibleHigherMultiplyerValues[Random.Range(0, possibleHigherMultiplyerValues.Length)];
        }

    }

    /*
    * Can make more efficient, but don't think there are enough calculations to warrant that
    *
    * 0 = 0
    * 1 = lowerMultiplyersPercent
    * 2 = middleMultiplyerPercent
    * 3 = higherMultiplyerPercent
    */

    /*
    public int WhichMultiplyerCategory(int multiplyer)
    {
        if (multiplyer == 0) { return 0; }

        foreach (int val in possibleLowerMultiplyerValues)
        {
            if (val == multiplyer) { return 1; }
        }

        foreach (int val in possibleMiddleMultiplyerValues)
        {
            if (val == multiplyer) { return 2; }
        }

        foreach (int val in possibleHigherMultiplyerValues)
        {
            if (val == multiplyer) { return 3; }
        }

        //shouldn't reach
        Debug.LogError("Shouldn't Reach here.");
        return -1;
    }*/
}
