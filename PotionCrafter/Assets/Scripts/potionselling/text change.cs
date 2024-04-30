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
        //CustomerText = FindAnyObjectByType<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        int textnum = (int)dragthepotion.Randnumpotion; // takes the variable from the other file to change the sprite //
        switch (textnum)
        {
            case 0:
                //Debug.Log("text change");
                CustomerText.text = "Can I have an Antidote Potion please?";
                potionwanted = "P_antidote";
                break;
            case 1:
                //Debug.Log("text change");
                CustomerText.text = "May I purchase a Speed Potion please?";
                potionwanted = "P_speed";
                break;
            case 2:
                //Debug.Log("text change");
                CustomerText.text = "Just a Potion Solution please.";
                potionwanted = "P_base";
                break;
            case 3:
                //Debug.Log("text change");
                CustomerText.text = "Do you have any Strength Potions";
                potionwanted = "P_4";
                break;
            case 4:
                //Debug.Log("text change");
                CustomerText.text = "May I purchase an Antidote Potion please?";
                potionwanted = "P_antidote";
                break;
            case 5:
                //Debug.Log("text change");
                CustomerText.text = "Do you have anything to make me run faster?";
                potionwanted = "P_speed";
                break;
            case 6:
                //Debug.Log("text change");
                CustomerText.text = "I wish to buy something to help me make potions at home?";
                potionwanted = "P_base";
                break;
            case 7:
                //Debug.Log("text change");
                CustomerText.text = "A tree has fallen on the path out of town, Do you have anything to make me strong enough to move it on my own?";
                potionwanted = "P_4";
                break;
            case 8:
                //Debug.Log("text change");
                CustomerText.text = "Please Help, I got Stung by a Scary looking plant in the forest. Now i'm not feeling well";
                potionwanted = "P_antidote";
                break;
            case 9:
                //Debug.Log("text change");
                CustomerText.text = "That Bastard neighbour of mine is participating in a race, Do you have anything that can get him disquailfied for cheating?";
                potionwanted = "P_speed";
                break;
            case 10:
                //Debug.Log("text change");
                CustomerText.text = "I wish to Poiso-... Make Potions at home, Do you have anything to help me?";
                potionwanted = "P_Base";
                break;
            case 11:
                //Debug.Log("text change");
                CustomerText.text = "I'm remodelling my house, would you have anything to make moving furniture less tiring?";
                potionwanted = "P_4";
                break;
            default:
                Debug.Log("ERROR: end of switch case");
                break;
        }
    }
}
