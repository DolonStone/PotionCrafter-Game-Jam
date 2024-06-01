using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnableTextOnHover : MonoBehaviour
{
    public GameObject objectToEnable;

    public void EnableObject()
    {
        objectToEnable.SetActive(true);
    }
    public void DisableObject()
    {
        objectToEnable.SetActive(false);
    }
}
