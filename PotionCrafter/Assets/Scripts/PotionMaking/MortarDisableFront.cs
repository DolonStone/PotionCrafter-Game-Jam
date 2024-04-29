using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MortarDisableFront : MonoBehaviour
{
    public SpriteRenderer frontbowl;
    public List<GameObject> gameObjectsWithin;
    public List<ingredient> ingredientScriptsWithin;
    public int itemsWithin = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void LateUpdate()
    {
        if (itemsWithin == 0)
        {
            frontbowl.enabled = true;
            gameObjectsWithin.Clear();
        }
        else
        {
            frontbowl.enabled = false;
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.isTrigger)
        {
            itemsWithin += 1;
            gameObjectsWithin.Add(collision.gameObject);
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.isTrigger)
        {
            itemsWithin -= 1;
            gameObjectsWithin.Remove(collision.gameObject);
        }
    }



}
