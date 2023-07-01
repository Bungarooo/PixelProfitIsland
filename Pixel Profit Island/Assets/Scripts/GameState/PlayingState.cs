using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayingState : StateBase
{
    public event Action onPlayBeginning;

    public override void BeginGame(GameContext context)
    {
    }

    public override void FinishGame(GameContext context)
    {
    }

    public override void Win(GameContext context)
    {
        context.SetState(AllGameStates.instance.winState);
    }

    public override void OnEnterState(GameContext context)
    {
        if (onPlayBeginning != null) { onPlayBeginning.Invoke(); }
    }
}
