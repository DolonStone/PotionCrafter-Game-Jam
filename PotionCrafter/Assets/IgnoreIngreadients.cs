using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnoreIngreadients : MonoBehaviour
{
    public Collider2D thisCollider;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ingredient"))
        {
            Physics2D.IgnoreCollision(thisCollider, collision.gameObject.GetComponent<Collider2D>());
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
       
    }
}
