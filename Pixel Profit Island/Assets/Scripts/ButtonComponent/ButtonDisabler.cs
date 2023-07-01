using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonDisabler : MonoBehaviour
{


    private void ButtonEnable()
    {
        this.GetComponent<Button>().interactable = true;
    }
    private void ButtonDisable()
    {
        this.GetComponent<Button>().interactable = false;
    }


    void OnEnable()
    {
        AllGameStates.instance.notPlayingState.onBoardReset += ButtonEnable;
        AllGameStates.instance.playingState.onPlayBeginning += ButtonDisable;
    }

    void OnDisable()
    {
        AllGameStates.instance.notPlayingState.onBoardReset -= ButtonEnable;
        AllGameStates.instance.playingState.onPlayBeginning -= ButtonDisable;
    }
}
