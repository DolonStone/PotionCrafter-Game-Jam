using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class todoboard_enter : MonoBehaviour
{
    public GameObject orderboard;
    public GameObject order1;
    public GameObject order2;
    public GameObject order3;
    public GameObject order4;
    public GameObject order5;
    public GameObject order6;
    // Start is called before the first frame update
    void Start()
    {
        
        orderboard.SetActive(false);
        order1.SetActive(false);
        order2.SetActive(false);
        order3.SetActive(false);
        order4.SetActive(false);
        order5.SetActive(false);
        order6.SetActive(false);
    }
    void OnMouseDown()
    {
        launch_orderboard();
    }
    // Update is called once per frame
    void Update()
    {
    }
    public void launch_orderboard()
    {
        if (orderboard.active == true)
        {
            orderboard.SetActive(false);
            order1.SetActive(false);
            order2.SetActive(false);
            order3.SetActive(false);
            order4.SetActive(false);
            order5.SetActive(false);
            order6.SetActive(false);
        }
        else
        {
            orderboard.SetActive(true);
            order1.SetActive(true);
            order2.SetActive(true);
            order3.SetActive(true);
            order4.SetActive(true);
            order5.SetActive(true);
            order6.SetActive(true);
        }
    }
}
