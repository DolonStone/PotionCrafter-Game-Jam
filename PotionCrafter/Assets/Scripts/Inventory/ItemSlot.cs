using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour, IPointerClickHandler
{
    /*public Image itemImage;

    public void UpdateSlot(Sprite itemSprite)
    {
        Debug.Log("Updating item slot with sprite: " + itemSprite.name);
        itemImage.sprite = itemSprite;
        itemImage.enabled = true;
    }

    public void ClearSlot()
    {
        Debug.Log("Clearing item slot");
        itemImage.sprite = null;
        itemImage.enabled = false;
    }*/

    public int SlotID; // Set in the Inspector to Desginate which slot this item represents
    public GameObject SpriteDisplay; // the Sprite display Game object Set in the Inspector.
    public int Amount = 0;
    public GameObject CounterText; // The text Renderer component assigned in Inspector. (Would recomend making this a child of the object)
    public string ItmName; // the name of the currently stored object
    public GameObject selectedShader;
    public bool thisItemSelected;
    public Item itemScript;
    private InventoryManager inventoryManager;
    public GameObject itemObject;
    public int prefabIndex;
    private GameObject Player;
    private Transform transformer;
    public GameObject Gru;
    private GameObject cam;

    /*private void Start()
     {
         InventoryManager.instance = GameObject.Find("InventoryCanvas").GetComponent<InventoryManager.instance>();
     }*/

    public void UpdateSlot(GameObject newitem, int itmAmount)
    {
        
        Amount += itmAmount;
        itemScript = newitem.GetComponent<Item>();
        SpriteDisplay.GetComponent<Image>().enabled = true; // Switches on the Sprite display component.
        SpriteDisplay.GetComponent<Image>().sprite = itemScript.itemSprite;
        CounterText.GetComponent<TextMeshProUGUI>().text = Amount.ToString();
        ItmName = newitem.GetComponent<Item>().itemName;

        
        //print(item);
        itemObject = newitem;
        // this.item = item;
        Debug.Log(ItmName);
        // return;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            OnLeftClick();
        }
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            OnRightClick(prefabIndex);
        }
    }

    public void OnLeftClick()
    {
        InventoryManager.instance.DeselectAllSlots();
        selectedShader.SetActive(true);
        thisItemSelected = true;
    }

    public void OnRightClick(int prefabIndex)
    {
        if (prefabIndex < 0)// || prefabIndex >= itemPrefabs.Length)
        {
            Debug.LogError("Nope, you fucked up");
            return;
        }

        if (Amount > 0)
        {
            Amount -= 1;
            CounterText.GetComponent<TextMeshProUGUI>().text = Amount.ToString();
            if (GameObject.FindWithTag("Player") != null)
            {
                Player = GameObject.FindWithTag("Player"); // gets player object
                transformer = Player.transform; // takes his location
                Gru = new GameObject(); // makes a new dummy spawner game object
                Gru.transform.position = (transformer.position); //sets its transform position to be the same as the players.
                Gru.transform.position += new Vector3(-2.5f, 0, 0); // applys the ofset. (should no longer affect the player character)
                itemObject.transform.position = Gru.transform.position;
                itemObject.SetActive(true); // and poops out the Correct object at the correct position 
                //GameObject droppedItem = Instantiate(itemPrefab, Gru.transform.position, Quaternion.identity);

            }
            else
            {
                
                cam = GameObject.FindWithTag("MainCamera");
                Gru = new GameObject();
                Gru.transform.position = cam.transform.position;
                if (Amount > 0)
                {
                    GameObject droppedItem = Instantiate(itemScript.prefab, Gru.transform.position += new Vector3(-8.05f + (SlotID * 2), 4.85f, 10), Quaternion.identity);
                    if (droppedItem.GetComponent<Item>()) 
                    { 
                        droppedItem.GetComponent<Item>().quantity = 1;
                    }
                    else
                    {
                        droppedItem.transform.GetChild(0).gameObject.GetComponent<Item>().quantity = 1;
                        //droppedItem.transform.position = Gru.transform.position;
                        droppedItem.transform.GetChild(0).gameObject.transform.position = Gru.transform.position;
                        droppedItem.transform.GetChild(0).gameObject.SetActive(true);
                    }
                    droppedItem.SetActive(true);
                    

                }
                else
                {
                    itemObject.transform.position = Gru.transform.position += new Vector3(-8.05f + (SlotID * 2), 4.85f, 10);
                    itemObject.GetComponent<Item>().quantity = 1;
                    itemObject.SetActive(true);
                }
                //GameObject droppedItem = Instantiate(itemPrefab, Gru.transform.position += new Vector3(-8.05f+(prefabIndex*2),4.85f,0), Quaternion.identity);

            }
            //droppedItem.AddComponent<BoxCollider>(); It should allready have one.
            Debug.Log("Wowwee the quantity is " + Amount);
        }

        if (Amount == 0)
        {
            SpriteDisplay.GetComponent<Image>().enabled = false;
            InventoryManager.instance.RemoveItem(ItmName, 1);
            // GetComponent<InventoryManager>().RemoveItem(ItmName, Amount);
        }
    }

    public void ClearSlot()
    {
        Amount = 0;
        ItmName = "";
        itemScript = null;
        itemObject = null;
        return;
    }
}
