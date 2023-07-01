using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BoomTextScript : MonoBehaviour
{
    RectTransform RTransform;

    const float duration = 0.45f;
    void Start()
    {
        RTransform = this.GetComponent<RectTransform>();

    }

    void OnEnable()
    {
        StartCoroutine(InvokeEffect());
    }

    //set active for duration time
    IEnumerator InvokeEffect()
    {
        RTransform.DOPunchScale(new Vector3(.5f, .5f, .5f), duration / 2);
        yield return new WaitForSeconds(duration);
        this.gameObject.SetActive(false);
    }
}
