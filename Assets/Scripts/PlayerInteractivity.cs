using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class manages every interaction the player do 
/// within the world
/// </summary>
public class PlayerInteractivity : MonoBehaviour
{
     
    public float rotationSpeed = 1;
    public float throwPower = 5;


    [SerializeField] LayerMask garbageLayer;

    /// <summary>
    /// it has all of the items a player can throw
    /// </summary>
    public List<GarbageItem> itemToThrow;
    public Transform shotPoint;

    /// <summary>
    /// currently selected item in hand
    /// </summary>
    GarbageItem selectedItem;
    GameManager gameManager;

    private void Start()
    {
        gameManager = GameManager.mInstance;
    }

    // Update is called once per frame
    void Update()
    { 
        SpawnItem();
        PickItem();
    }

   


    /// <summary>
    /// called when player wants to spawn 
    /// item in hand using mouse click
    /// </summary>
    private void SpawnItem()
    {
        if (Input.GetMouseButtonDown(0) && selectedItem != null)
        {
            selectedItem.gameObject.SetActive(true);
            selectedItem.transform.position = shotPoint.transform.position;
            selectedItem.GetComponent<Rigidbody>().velocity = shotPoint.transform.forward * throwPower;
            selectedItem = null;
            itemToThrow.Clear();
        }
    }


    /// <summary>
    /// called whenever an item from the 
    /// ground it to be picked
    /// </summary>
    private void PickItem()
    {

        Collider[] hits =  Physics.OverlapSphere(transform.position, 2f, garbageLayer);

        if(hits.Length > 0)
        {
            if (itemToThrow.Count == 0)
                gameManager.SetGameInformation("Press P to pick the Item");
            
            if (Input.GetKeyDown(KeyCode.P))
            {
                if (itemToThrow.Count == 0)
                {
                    hits[0].gameObject.SetActive(false);
                    itemToThrow.Add(hits[0].gameObject.GetComponent<GarbageItem>());
                    selectedItem = itemToThrow[0];
                    gameManager.SetItemInfo(itemToThrow[0].itemName);
                }
                else
                {
                    gameManager.SetGameInformation("You cant pick multiple items");
                }
            }
        }
    }

    /// <summary>
    /// it selects the next item in the hand
    /// </summary>
    private void SelectNextItem()
    {
        int currentIndex = itemToThrow.IndexOf(selectedItem);
        int newIndex = currentIndex;

        while(newIndex == currentIndex)
        {
            newIndex = UnityEngine.Random.Range(0, itemToThrow.Count); 
        }

        selectedItem = itemToThrow[newIndex];  
    }
}
