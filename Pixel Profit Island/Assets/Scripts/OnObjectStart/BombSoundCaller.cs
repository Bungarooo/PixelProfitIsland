using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombSoundCaller : MonoBehaviour
{
    void Start()
    {
        AudioManager.instance.Play("Bomb Sound");
    }
}
