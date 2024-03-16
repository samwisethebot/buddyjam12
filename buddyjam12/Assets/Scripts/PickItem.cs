using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;


public class PickItem : MonoBehaviour
{
    public GameObject[] itemsToPickFrom;
    string[] descriptions =  {"Chair 2 next left of the exorcism book", "Photo ID", "Office Chair (TEMP)"};
    [SerializeField] TMP_Text itemText; 
  
    //all items player can chose from need to be set to the itemsLayer

    // Start is called before the first frame update
    void Start()
    {
        Pick();
    }
   
    void Pick()
    {
        int randomIndex = Random.Range(0, itemsToPickFrom.Length);
        Debug.Log("Item to search: " + itemsToPickFrom[randomIndex]);
        itemText.text =  descriptions[randomIndex];
        itemsToPickFrom[randomIndex].layer = LayerMask.NameToLayer("validItemLayer");

    }

}
