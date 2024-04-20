using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SquashableIngreadient : MonoBehaviour
{
    public GameObject thisgameobject;
    public float sizeScale = 1;
    public float minsize = 0.01f;
    public float bestSquishAmount = 0.7f;
    private float maxSquish = 1f;
    public GameObject pestle;
    public Rigidbody2D pestleRb;
    public ParticleSystem mushing;
    public GameObject sliderGameObject;
    private Slider slider;
    private float startScale;
    private float scaleTotalDif;
    private float scaleCurrentDiff;
    public Image sliderFill;
    public float sliderIncriment = 0f;
    private float overflowSliderIncriment = 0f;

    // Start is called before the first frame update
    void Start()
    {
        pestle = GameObject.FindGameObjectWithTag("Pestle");
        pestleRb = pestle.GetComponent<Rigidbody2D>();
        startScale = transform.localScale.x;
        scaleTotalDif = startScale - minsize;
        slider = sliderGameObject.GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Mortar"))
        {
            sliderGameObject.SetActive(true);
        }

        if (collision.CompareTag("Pestle"))
        {
            
            if (Mathf.Abs(pestleRb.velocity.magnitude) >= 0.3)
            {
                float crushingpower = Mathf.Abs(pestleRb.velocity.magnitude) / 100;
                mushing.Play();
                if (transform.localScale.x > minsize)
                {
                    transform.localScale = new Vector3(transform.localScale.x - crushingpower, transform.localScale.y - crushingpower, transform.localScale.z);
                    sliderIncriment = (startScale - transform.localScale.x) / scaleTotalDif;
                    sliderFill.color = Color.Lerp(Color.gray, Color.green, sliderIncriment);
                    slider.value = sliderIncriment;
                    
                }
                
                if (slider.value >= 1)
                {

                    overflowSliderIncriment += 0.07f;
                    sliderFill.color = Color.Lerp(Color.green, Color.red, overflowSliderIncriment);
                    slider.value += 0.02f;
                }
                if(slider.value >= 1.25)
                {
                    Destroy(sliderGameObject);
                    Destroy(gameObject);
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
        if (collision.CompareTag("Mortar"))
        {
            sliderGameObject.SetActive(false);
        }
    }

}
