using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChestSpawner : MonoBehaviour
{
    private Chest[] chests;

    private void ResetChests()
    {
        foreach (Chest chestRef in chests)
        {
            chestRef.ResetChest();
        }
    }

    private void DisableChests()
    {
        foreach (Chest chestRef in chests)
        {
            chestRef.DisableChest();
        }
    }


    void Start()
    {
        chests = GetComponentsInChildren<Chest>();
    }

    void OnEnable()
    {
        AllGameStates.instance.playingState.onPlayBeginning += ResetChests;
        AllGameStates.instance.winState.onWin += DisableChests;
    }

    void OnDisable()
    {
        AllGameStates.instance.playingState.onPlayBeginning -= ResetChests;
        AllGameStates.instance.winState.onWin -= DisableChests;
    }
}
