using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SuckableObjectScript : MonoBehaviour
{
    public float suckabletime;
    public bool beingsucked;
    public float suckedtime;
    public GameObject slider;
    public GameObject destroyparticles;
    private bool beensucked;
    public float suckfactor;
    public GameObject drop;
    // Start is called before the first frame update
    void Start()
    {
        //destroyparticles = GameObject.FindGameObjectWithTag("destroyparticles");
    }

    // Update is called once per frame
    void Update()
    {
        if (beingsucked == true)
        {
            if (beensucked == false)
            {
                slider.SetActive(true);
            }
            suckedtime += suckfactor;
            slider.GetComponent<Slider>().value = (10-suckedtime)/10;

        }

        if (suckedtime > suckabletime)
        {
            Break();
            
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Destroyer"))
        {
            if (collision.GetComponent<enablesuck>().hooverenabled == true)
            {
                beingsucked = true;
                suckfactor = collision.GetComponent<enablesuck>().suckfactor;

            }
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        beingsucked = false;
    }
    private void Break()
    {
        Instantiate(destroyparticles);
        destroyparticles.transform.position = new Vector2(transform.position.x, transform.position.y);

        var thisdrop = Instantiate(drop);
        thisdrop.transform.position = new Vector2(transform.position.x, transform.position.y);
        
        if (thisdrop.GetComponent<Rigidbody2D>())
        {
            thisdrop.GetComponent<Rigidbody2D>().gravityScale = 0;
            thisdrop.transform.localScale = new Vector3(3f, 3f, 3f);
        }
        else
        {
            thisdrop.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
            thisdrop.GetComponentInChildren<Rigidbody2D>().gravityScale = 0;

        }
        
        //drop.GetComponent<Rigidbody2D>().AddForce(new Vector2(5,5),ForceMode2D.Impulse);

        Destroy(gameObject);
    }
}
