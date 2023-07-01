using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisappearIntro : MonoBehaviour
{
    float duration = .5f;

    [SerializeField] Vector2 targetAnchoredPos;

    RectTransform thisRectTransform;
    public void Disappear()
    {
        thisRectTransform = this.GetComponent<RectTransform>();
        StartCoroutine(Disappearing());

    }

    private IEnumerator Disappearing()
    {
        Vector2 currentPos = thisRectTransform.anchoredPosition;
        Vector2 startPos = currentPos;
        yield return new WaitForSeconds(.1f);

        for (int i = 0; i < 20; i++)
        {
            currentPos = Vector2.Lerp(startPos, targetAnchoredPos, ((float)i) / 20f);
            thisRectTransform.anchoredPosition = currentPos;
            yield return new WaitForSeconds(duration / 20);
        }

        currentPos = targetAnchoredPos;
        thisRectTransform.anchoredPosition = currentPos;
        this.gameObject.SetActive(false);

    }
}
