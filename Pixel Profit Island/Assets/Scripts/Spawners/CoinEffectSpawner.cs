using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CoinEffectSpawner : MonoBehaviour
{
    RectTransform rootTransform;

    [Header("These should exist in the scene, be a child of this GameObject, and be disabled")]
    [SerializeField] RectTransform BombCoin;
    [SerializeField] RectTransform BronzeCoin;
    [SerializeField] RectTransform SilverCoin;
    [SerializeField] RectTransform GoldCoin;

    [Header("References this script relies on")]
    [SerializeField] CalculationMaster calcMaster;

    void Start()
    {
        rootTransform = this.transform.root.GetComponent<RectTransform>();
    }

    //If money == 0, does bomb effect. Otherwise coin effect. Determines coin based on the money value compared to the wager
    public void DisplayCoinEffect(float money, float wager)
    {
        RectTransform targetTransform;
        if (money <= 0)
        {
            targetTransform = BombCoin;
            InstantiateCoinEffect(targetTransform, "BOMB");
            return;
        }
        else if (money <= wager)
        {
            targetTransform = BronzeCoin;
        }
        else if (money <= wager * 3)
        {
            targetTransform = SilverCoin;
        }
        else
        {
            targetTransform = GoldCoin;
        }

        InstantiateCoinEffect(targetTransform, "+" + money.ToString("C2"));
    }

    //This Method assumes the GameObject being duplicated has an Image with an animator as the first child GameObject,
    //and a TextMeshPro component as the 2nd child GameObject
    public void InstantiateCoinEffect(RectTransform coin, string valueAsString)
    {
        RectTransform newCoin = Instantiate(coin);
        newCoin.SetParent(this.transform);
        newCoin.anchoredPosition = GetPositionRelativeToMouse();
        newCoin.localScale = Vector3.one;
        newCoin.transform.GetChild(1).GetComponent<TMP_Text>().text = valueAsString;
        newCoin.gameObject.SetActive(true);

    }


    private Vector2 anchorPos = new Vector2(0, 0);
    //Gets the mouse position on the RectTransform of the canvas and gives the value to anchorPos
    private Vector2 GetPositionRelativeToMouse()
    {
        RectTransformUtility.ScreenPointToLocalPointInRectangle(rootTransform, Input.mousePosition, Camera.main, out anchorPos);
        if (anchorPos.y > 168)
        {
            return new Vector2(anchorPos.x, anchorPos.y - 10);
        }
        else
        {
            return new Vector2(anchorPos.x, anchorPos.y + 35);
        }
    }

    void OnEnable()
    {
        calcMaster.onMoneyAquiredFromChestPress += DisplayCoinEffect;
    }
    void OnDisable()
    {
        calcMaster.onMoneyAquiredFromChestPress -= DisplayCoinEffect;
    }
}
