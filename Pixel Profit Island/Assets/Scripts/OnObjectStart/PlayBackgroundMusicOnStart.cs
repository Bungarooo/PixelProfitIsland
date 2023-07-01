using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayBackgroundMusicOnStart : MonoBehaviour
{

    void Start()
    {
        AudioManager.instance.Play("Background Music");
    }

}
