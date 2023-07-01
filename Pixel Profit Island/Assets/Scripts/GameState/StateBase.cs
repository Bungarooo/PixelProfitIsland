using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StateBase : MonoBehaviour, GameState
{
    public abstract void BeginGame(GameContext context);
    public abstract void FinishGame(GameContext context);
    public abstract void Win(GameContext context);
    public abstract void OnEnterState(GameContext context);
}
