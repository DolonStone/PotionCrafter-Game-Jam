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
        int textnum = (int)dragthepotion.Randnumpotion; // takes the variable from the other file to cnage the sprite //
        switch (textnum)
        {
            case 0:
                //Debug.Log("text change");
                CustomerText.text = "Can I have an antidote potion please?";
                potionwanted = "P_antidote";
                break;
            case 1:
                //Debug.Log("text change");
                CustomerText.text = "Can I get a speed potion please?";
                potionwanted = "P_speed";
                break;
            case 2:
                //Debug.Log("text change");
                CustomerText.text = "Just a base solution please.";
                potionwanted = "P_base";
                break;
            case 3:
                //Debug.Log("text change");
                CustomerText.text = "Do you have any [4th potion]";
                potionwanted = "P_4";
                break;
            default:
                Debug.Log("ERROR: end of switch case");
                break;
        }
    }
}
