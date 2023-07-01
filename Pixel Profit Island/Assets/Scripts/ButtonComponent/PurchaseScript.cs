using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PurchaseScript : MonoBehaviour
{
    public event Action onPurchase;

    public void PurchaseButtonPressed()
    {
        onPurchase.Invoke();
    }
}
