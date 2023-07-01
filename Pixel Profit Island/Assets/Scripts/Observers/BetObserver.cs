using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BetObserver : MonoBehaviour
{
    [SerializeField] BetAmount betAmount;

    void Start()
    {
        SynchronizeBetUI();
    }

    private void SynchronizeBetUI()
    {
        this.GetComponent<TMP_Text>().text = betAmount.GetCurrentValue().ToString("C2");
    }

    void OnEnable()
    {
        betAmount.onValueChange += SynchronizeBetUI;
    }

    void OnDisable()
    {
        betAmount.onValueChange -= SynchronizeBetUI;
    }
}
