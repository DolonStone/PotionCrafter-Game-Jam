using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ingredient : MonoBehaviour
{
    public string ingredientName;
    public float quality;
    private void Update()
    {
        if (gameObject.GetComponent<SquashableIngreadient>() != null)
        {
            quality = gameObject.GetComponent<SquashableIngreadient>().sliderIncriment;
        }
        else if(gameObject.GetComponent<BoilIngredient>() != null)
        {
            quality = gameObject.GetComponent<BoilIngredient>().sliderIncrimented;
        }
        else if (gameObject.GetComponent<potionObjectScript>() != null)
        {
            quality = gameObject.GetComponent<potionObjectScript>().quality;
        }
    }
}
