using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayButtonAdditionalDisables : MonoBehaviour
{

    [SerializeField] BetAmount betAmount;

    private void ButtonEnable()
    {
        this.GetComponent<Button>().interactable = true;
    }
    private void ButtonDisable()
    {
        this.GetComponent<Button>().interactable = false;
    }

    void OnEnable()
    {
        betAmount.onBetNotLessThanBalance += ButtonEnable;
        betAmount.onBetLessThanBalance += ButtonDisable;
    }

    void OnDisable()
    {
        betAmount.onBetNotLessThanBalance -= ButtonEnable;
        betAmount.onBetLessThanBalance -= ButtonDisable;
    }
}
