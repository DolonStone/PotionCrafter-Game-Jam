using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquashableIngreadient : MonoBehaviour
{
    public GameObject thisgameobject;
    public float sizeScale = 1;
    public Rigidbody2D pestleRb;
    public ParticleSystem mushing;
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
            
            if (Mathf.Abs(pestleRb.velocity.magnitude) >= 0.3)
            {
                float crushingpower = Mathf.Abs(pestleRb.velocity.magnitude) / 1000;
                mushing.Play();
                if (transform.localScale.x > 0.01)
                {
                    transform.localScale = new Vector3(transform.localScale.x - crushingpower, transform.localScale.y - crushingpower, transform.localScale.z);
                }
            }
            else
            {
                
                mushing.Stop();
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        
        mushing.Stop();
    }
}
