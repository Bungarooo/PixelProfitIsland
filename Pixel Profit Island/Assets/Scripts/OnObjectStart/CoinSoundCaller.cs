using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSoundCaller : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        AudioManager.instance.Play("Coin Sound");
    }
}
