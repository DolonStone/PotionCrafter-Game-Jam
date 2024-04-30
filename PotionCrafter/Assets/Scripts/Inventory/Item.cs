using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public string itemName;
    public int quantity;
    public Sprite itemSprite;
    public GameObject prefab;
    
    //public Item item;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            InventoryManager.instance.AddItem(this.gameObject);

            Debug.Log("Item Collected: " + itemName);
            Destroy(gameObject);
        }
        if (other.CompareTag("InventoryBin"))
        {
            
            InventoryManager.instance.AddItem(this.gameObject);

            gameObject.SetActive(false);
        }
    }
    /*public string itemName;
    public int quantity;
    public Sprite itemSprite;

    public Item item;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            InventoryManager.instance.AddItem(this);
            Destroy(gameObject);
            Debug.Log("Item Collected: " + itemName);
        }
    }*/
}
