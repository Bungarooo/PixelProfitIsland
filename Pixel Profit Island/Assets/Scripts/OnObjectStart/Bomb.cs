using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField] GameStatePattern stateManager;
    [SerializeField] GameObject BombText;

    // Start is called before the first frame update
    void Start()
    {
        BombText.SetActive(true);
        stateManager.Win();
    }
}
