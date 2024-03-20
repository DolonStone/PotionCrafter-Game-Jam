using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderRenderer : MonoBehaviour
{
    
    public int sortingOrderBase = 5000;
    private Renderer myRenderer;
    public int offset = 0;
    private void Awake()
    {
        myRenderer = gameObject.GetComponent<Renderer>();
    }
    private void LateUpdate()
    {
        myRenderer.sortingOrder = sortingOrderBase - (int)(transform.position.y*10) - offset;
    }
}
