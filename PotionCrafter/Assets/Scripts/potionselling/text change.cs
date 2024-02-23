using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using static UnityEditor.PlayerSettings;

public class textchange : MonoBehaviour
{
    public TextMeshProUGUI CustomerText;
    public static string potionwanted = string.Empty;

    // Start is called before the first frame update
    void Start()
    {
        CustomerText = FindAnyObjectByType<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        int textnum = dragthepotion.num; // takes the variable from the other file to cnage the sprite //
        switch (textnum)
        {
            case 0:
                //Debug.Log("text change");
                CustomerText.text = "pink";
                potionwanted = "P_magenta";
                break;
            case 1:
                //Debug.Log("text change");
                CustomerText.text = "love";
                potionwanted = "P_love";
                break;
            case 2:
                //Debug.Log("text change");
                CustomerText.text = "green";
                potionwanted = "P_green";
                break;
            case 3:
                //Debug.Log("text change");
                CustomerText.text = "flower";
                potionwanted = "P_flower";
                break;
            case 4:
                //Debug.Log("text change");
                CustomerText.text = "love";
                potionwanted = "P_love";
                break;
            default:
                Debug.Log("ERROR: end of switch case");
                break;
        }
    }
}
