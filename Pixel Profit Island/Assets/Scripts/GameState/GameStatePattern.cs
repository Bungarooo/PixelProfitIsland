using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStatePattern : MonoBehaviour, GameContext
{

    [SerializeField] StateBase currentState;

    public void Win() => currentState.Win(this);

    public void FinishGame() => currentState.FinishGame(this);

    public void BeginGame() => currentState.BeginGame(this);

    void GameContext.SetState(StateBase newState)
    {
        currentState = newState;
        currentState.OnEnterState(this);
    }
}
