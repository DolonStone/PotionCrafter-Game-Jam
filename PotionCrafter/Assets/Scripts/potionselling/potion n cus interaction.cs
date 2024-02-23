using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class potionncusinteraction : MonoBehaviour
{
    [SerializeField] private Vector3 setPosition;

    public void SetPositionFunction()
    {
        transform.position = setPosition;
    }

}
