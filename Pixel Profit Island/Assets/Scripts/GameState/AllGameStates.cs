using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllGameStates : MonoBehaviour
{
    public static AllGameStates instance = null;

    private void Awake()
    {
        if (instance == null) { instance = this; }
    }

    public NotPlayingState notPlayingState;
    public PlayingState playingState;
    public WinState winState;
}
