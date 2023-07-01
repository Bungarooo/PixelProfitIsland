using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotPlayingState : StateBase
{
    public event Action onBoardReset;

    public override void BeginGame(GameContext context)
    {
        context.SetState(AllGameStates.instance.playingState);
    }

    public override void FinishGame(GameContext context)
    {
    }

    public override void Win(GameContext context)
    {
    }

    public override void OnEnterState(GameContext context)
    {
        if (onBoardReset != null) { onBoardReset.Invoke(); }
    }

}
