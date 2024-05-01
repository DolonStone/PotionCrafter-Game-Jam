using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public string itemName;
    public int quantity = 1;
    public Sprite itemSprite;
    public GameObject prefab;
    
    //public Item item;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (InventoryManager.instance.full == false || (gameObject.CompareTag("StackableIngredient") && InventoryManager.instance.HasItem(itemName)))
        {

        
            if (other.CompareTag("Player"))
            {
                InventoryManager.instance.AddItem(this.gameObject);
        
                gameObject.SetActive(false);
            }
            if (other.CompareTag("InventoryBin"))
            {

                InventoryManager.instance.AddItem(this.gameObject);

                gameObject.SetActive(false);
            }
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
