using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoilIngredient : MonoBehaviour
{
    public GameObject sliderGameObject;
    private GameObject heater;
    private Rigidbody2D heaterRB;
    public ParticleSystem boiling;
    private Slider slider;
    public Image sliderFill;
    public float sliderIncrimented = 0f;
    private float timer = 0f;
    public float underdoneIncriment = 0.005f;
    public float overdoneIncriment = 0.02f;
    public Sprite heatedSprite;
    private SpriteRenderer spriteRenderer;
    
    
    private void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        heater = GameObject.FindGameObjectWithTag("Heater");
        heaterRB = heater.GetComponent<Rigidbody2D>();
        slider = sliderGameObject.GetComponent<Slider>();
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Container"))
        {
            sliderGameObject.SetActive(true);
        }

        if ((collision.CompareTag("Heater")) && (Mathf.Abs(gameObject.GetComponent<Rigidbody2D>().velocity.magnitude)>0.1))
        {
            timer += Time.deltaTime;

            if (timer >= 0.05)
            {
                if(sliderIncrimented >= 1)
                {
                    spriteRenderer.sprite = heatedSprite;
                }
                if (sliderIncrimented <= 1)
                {
                    timer = 0f;
                    boiling.Play();
                    sliderIncrimented += underdoneIncriment;
                    slider.value = sliderIncrimented;
                    sliderFill.color = Color.Lerp(Color.gray, Color.green, sliderIncrimented);
                }
                else
                {
                    sliderIncrimented += overdoneIncriment; 
                    slider.value = sliderIncrimented;
                    sliderFill.color = Color.Lerp(Color.green, Color.red, (sliderIncrimented-1)*4);
                }
            }


        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        boiling.Stop();
        if (collision.CompareTag("Container"))
        {
            sliderGameObject.SetActive(false);
        }
    }
}
