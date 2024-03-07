using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquashableIngreadient : MonoBehaviour
{
    public GameObject thisgameobject;
    public float sizeScale = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        /*if (collision.CompareTag("Mortar"))
        {
            GameObject drop1 = Instantiate(thisgameobject);
            GameObject drop2 = Instantiate(thisgameobject);
            drop1.transform.localScale = new Vector3(0.5f, 0.5f);
            drop2.transform.localScale = new Vector3(0.5f, 0.5f);
            Destroy(gameObject);

        }*/
        if (collision.CompareTag("Pestle"))
        {
            
        }
    }
    
}
