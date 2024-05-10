using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class InventoryManager : MonoBehaviour
{
    /*public ItemSlot[] itemSlots;
    private Sprite[] inventorySprites;
    public int maxInvSize = 10;

    void Start()
    {
        inventorySprites = new Sprite[maxInvSize];
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Item item = collision.GetComponent<Item>();
        if(item != null)
        {
            if (inventorySprites.Length < maxInvSize)
            {
                AddItemToInventory(item.itemSprite);
                Destroy(collision.gameObject);
            }

            else
            {
                Debug.Log("Oopsies, mistakes were made!");
            }
        }
    }

    void AddItemToInventory(Sprite itemSprite)
    {
        for(int i = 0; i < inventorySprites.Length; i++)
        {
            if (inventorySprites[i] == null)
            {
                inventorySprites[i] = itemSprite;
                Debug.Log("YAY! I have picked up " + itemSprite.name);
                UpdateInventoryUI();
                return;
            }
        }
    }

    void UpdateInventoryUI()
    {
        for (int i = 0; i < itemSlots.Length; i++)
        {
            if (i < inventorySprites.Length && inventorySprites[i] != null)
            {
                itemSlots[i].UpdateSlot(inventorySprites[i]);
            }
            else
            {
                itemSlots[i].ClearSlot();
            }
        }
    }*/






    public GameObject InventoryMenu;
    public GameObject InventoryHud;
    private bool menuActivated;
    public static InventoryManager instance; // Checks this is the only instance
    private Dictionary<string, GameObject> inventory; // Stores information
    public int NextSlot; // used to designate the next inventory slot to target. (May want a max slots to prevent adding items to non exsistant slots.)
    public Text quantityText;
    public GameObject[] ItmSlots;
    public bool full;
    // Notifies other scripts over modifications
    public delegate void OnInventoryChanged();
    public OnInventoryChanged onInventoryChangedCallback;


    void Update()
    {
        if (Input.GetButtonDown("Inventory") && menuActivated)
        {
            Time.timeScale = 1;
            InventoryMenu.SetActive(false);
            menuActivated = false;
        }

        else if (Input.GetButtonDown("Inventory") && !menuActivated)
        {
            Time.timeScale = 0;
            InventoryMenu.SetActive(true);
            menuActivated = true;
        }
    }

    // Destroys itself if another instance is found
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        else
        {
            Destroy(gameObject);
            return;
        }
        inventory = new Dictionary<string, GameObject>();
        DontDestroyOnLoad(this.gameObject);
    }

    //Adds item to inventory

    public void AddItem(GameObject itemObject)
    {
        for (int i = 0; i < ItmSlots.Length; i++)
        {
            if (ItmSlots[i].GetComponent<ItemSlot>().ItmName == "")
            {
                full = false;
                print("notFull");
                NextSlot = i;
                break;
            }
        }
            var itemscript = itemObject.GetComponent<Item>();
        if (((inventory.ContainsKey(itemscript.itemName)) && GameObject.FindWithTag("Player") != null) || (inventory.ContainsKey(itemscript.itemName))&&itemObject.CompareTag("StackableIngredient"))//checks if it exists already in the inventory, and if we are in resource collection so it doesnt mess with quality variables
        {
            //inventory[itemscript.itemName].GetComponent<Item>().quantity += itemscript.quantity;
            for (int i = 0; i < ItmSlots.Length; i++)
            { // Checks each Child for its Code component.
                if (ItmSlots[i].GetComponent<ItemSlot>().ItmName == itemscript.itemName)
                {
                    print(inventory.ContainsKey(itemscript.itemName));

                    print(inventory[itemscript.itemName.Replace("(Clone)", "")]);
                    ItmSlots[i].GetComponent<ItemSlot>().UpdateSlot(itemObject, 1);//inventory[itemscript.itemName.Replace("(Clone)","")], inventory[itemscript.itemName].GetComponent<Item>().quantity);
                }

            }
        }

        else
        {
            if (inventory.ContainsKey(itemscript.itemName))
            {
                itemscript.itemName += " 1";
            }
            inventory.Add(itemscript.itemName, itemObject);
            ItmSlots[NextSlot].GetComponent<ItemSlot>().UpdateSlot(inventory[itemscript.itemName], inventory[itemscript.itemName].GetComponent<Item>().quantity);
            for (int i = 0; i < ItmSlots.Length; i++)
            {
                if (ItmSlots[i].GetComponent<ItemSlot>().ItmName == "")
                {
                    full = false;
                    NextSlot = i;
                    break;
                }
                else
                {
                    full = true;
                }
            }

            foreach (var Keys in inventory.Keys)
            {
                UnityEngine.Debug.Log("Inventory contains " + Keys);
            }
        }

        if (onInventoryChangedCallback != null)
        {
            onInventoryChangedCallback.Invoke();
        }

    }

    public void DeselectAllSlots()
    {
        for (int i = 0; i < ItmSlots.Length; i++)
        {
            ItmSlots[i].GetComponent<ItemSlot>().selectedShader.SetActive(false);
            ItmSlots[i].GetComponent<ItemSlot>().thisItemSelected = false;
        }
    }

    //Removing item from inventory


    public void RemoveItem(string itemName, int quantity)
    {
        if (inventory.ContainsKey(itemName))
        {
            //inventory[itemName].GetComponent<Item>().quantity -= quantity;

            //if (inventory[itemName].GetComponent<Item>().quantity <= 0)
            

                for (int i = 0; i < ItmSlots.Length; i++)
                {
                    if (ItmSlots[i].GetComponent<ItemSlot>().ItmName == itemName)
                    {
                        ItmSlots[i].GetComponent<ItemSlot>().ClearSlot();
                    }
                }
                inventory.Remove(itemName);
                for (int i = 0; i < ItmSlots.Length; i++)
                {
                    if (ItmSlots[i].GetComponent<ItemSlot>().ItmName == "")
                    {
                        NextSlot = i;
                        break;
                    }
                }
            

            if (onInventoryChangedCallback != null)
            {
                onInventoryChangedCallback.Invoke();
            }
        }
    }

    //Checks for items
    public bool HasItem(string itemName)
    {
        return inventory.ContainsKey(itemName);
    }

    //Checks quantity
    public int GetItemQuantity(string itemName)
    {
        if (inventory.ContainsKey(itemName))
        {
            return inventory[itemName].GetComponent<Item>().quantity;
        }
        return 0;
    }














    /*public GameObject InventoryMenu;
    private bool menuActivated;
    public static InventoryManager instance; // Checks this is the only instance
    private Dictionary<string, Item> inventory; // Stores information

    // Notifies other scripts over modifications
    public delegate void OnInventoryChanged();
    public OnInventoryChanged onInventoryChangedCallback;

    void Update()
    {
        if (Input.GetButtonDown("Inventory") && menuActivated)
        {
            Time.timeScale = 1;
            InventoryMenu.SetActive(false);
            menuActivated = false;
        }

        else if (Input.GetButtonDown("Inventory") && !menuActivated)
        {
            Time.timeScale = 0;
            InventoryMenu.SetActive(true);
            menuActivated = true;
        }
    }

    // Destroys itself if another instance is found
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }

        else
        {
            Destroy(gameObject);
            return;
        }
        inventory = new Dictionary<string, Item>();
    }

    //Adds item to inventory

    public void AddItem(Item item)
    {
        if(inventory.ContainsKey(item.name))
        {
            inventory[item.name].quantity += item.quantity;
        }

        else 
        {
            inventory.Add(item.name, item);
        }

        if(onInventoryChangedCallback != null)
        {
            onInventoryChangedCallback.Invoke();
        }
    }

    //Removing item from inventory


    public void RemoveItem(string itemName, int quantity)
    {
        if(inventory.ContainsKey(itemName))
        {
            inventory[itemName].quantity -= quantity;

            if (inventory[itemName].quantity <= 0)
            {
                inventory.Remove(itemName);
            }

            if(onInventoryChangedCallback != null)
            {
                onInventoryChangedCallback.Invoke();
            }
        }
    }

    //Checks for items
    public bool HasItem(string itemName)
    {
        return inventory.ContainsKey(itemName);
    }

    //Checks quantity
    public int GetItemQuantity(string itemName)
    {
        if(inventory.ContainsKey(itemName))
        {
            return inventory[itemName].quantity;
        }
        return 0;
    }*/
}