using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinState : StateBase
{
    public event Action onWin;

    public override void BeginGame(GameContext context)
    {
    }

    public override void FinishGame(GameContext context)
    {
        context.SetState(AllGameStates.instance.notPlayingState);
    }

    public override void Win(GameContext context)
    {
    }

    public override void OnEnterState(GameContext context)
    {
        if (onWin != null) { onWin.Invoke(); }
        StartCoroutine(DelayedOnEnterState(context));
    }

    private IEnumerator DelayedOnEnterState(GameContext context)
    {
        yield return new WaitForSeconds(.25f); //gives time for money to add to Total Win and final Win to add
        FinishGame(context);
    }
}
