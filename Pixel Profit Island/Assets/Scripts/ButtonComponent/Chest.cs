using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Chest : MonoBehaviour
{
    //[SerializeField] GameObject chestPrefab;

    public void ResetChest()
    {
        this.GetComponent<Image>().enabled = true;
        this.GetComponent<Button>().interactable = true;
    }

    public void DisableChest(){
        this.GetComponent<Button>().interactable = false;
    }

    
}
