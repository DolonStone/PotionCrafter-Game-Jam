using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ingredient : MonoBehaviour
{
    public MonoBehaviour test;
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

    }
}
