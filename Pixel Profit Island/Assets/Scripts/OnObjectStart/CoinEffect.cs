using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class CoinEffect : MonoBehaviour
{
    [SerializeField] float duration = 0.6f;

    private RectTransform RTransform;

    private Animator anim;

    void Start()
    {
        RTransform = this.GetComponent<RectTransform>();
        InvokeEffect();
    }

    public void InvokeEffect()
    {
        RTransform.DOPunchScale(new Vector3(.5f, .5f, .5f), duration / 2);
        Destroy(this.gameObject, duration);
    }
}
