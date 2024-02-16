using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dragthepotion : MonoBehaviour
{
    Vector2 difference = Vector2.zero;

    private void OnMouseDown()
    {
        difference = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) - (Vector2)transform.position;
    }

    private void OnMouseDrag()
    {
        transform.position = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) - difference;
    }
    
    void Update()
    {
        // if potion collided with sprite call the sprie chage class to chage the sprite //
    }
}

