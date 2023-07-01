using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface GameState
{
    void Win(GameContext context);

    void FinishGame(GameContext context);

    void BeginGame(GameContext context);

    void OnEnterState(GameContext context);
}
