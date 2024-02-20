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
    // Start is called before the first frame update
    void Start()
    {

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
            suckedtime += 0.01f;
            slider.GetComponent<Slider>().value = (10-suckedtime)/10;

        }

        if (suckedtime > suckabletime)
        {
            Break();
            
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.GetComponent<enablesuck>().hooverenabled == true)
        {
            beingsucked = true;

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        beingsucked = false;
    }
    private void Break()
    {
        //Instantiate(destroyparticles);
        destroyparticles.transform.position = new Vector2(transform.position.x, transform.position.y);
        destroyparticles.SetActive(false);
        destroyparticles.SetActive(true);
        Destroy(gameObject);
    }
}
