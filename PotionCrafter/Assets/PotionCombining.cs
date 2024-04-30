using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionCombining : MonoBehaviour
{
    public List<ingredient> ingredientsScripts;
    private float quality;
    public List<string> currentIngredientNames;
    private List<string> speedPotion = new() { "BaseSolution", "Sugar", "Feather", "Feather", "Feather", "Chalk", "Chalk", "Wood" };
    private List<string> baseSolution = new() { "Ross","Ross" };
    private List<string> antidotePotion = new() { "BaseSolution", "Charcoal", "Elf", "Elf" };
    private List<string> strengthPotion = new() { "BaseSolution", "Blot", "Grot", "Grot","Vigour", "Reeds", "Reeds","Damp"};
    private List<List<string>> potionOptions;
    private int currentPotion; 
    private string madePotionName;
    public GameObject baseSolutionObject, speedPotionObject, antidotePotionObject, strengthPotionObject;
    // Start is called before the first frame update
    void Start()
    {
        potionOptions = new() { baseSolution, antidotePotion, speedPotion, strengthPotion};
        foreach(List<string> potion in potionOptions)
        {
            potion.Sort();
        }
    }

    // Update is called once per frame
    void Update()
    {
        MakePotion();
        //test
        
    }
    void MakePotion()
    {
        currentPotion = -1;
        quality = 0;
        var gameObjectsWithin = gameObject.GetComponent<MortarDisableFront>().gameObjectsWithin;
        
        ingredientsScripts.Clear();
        currentIngredientNames.Clear();
        foreach (GameObject ingredientObject in gameObjectsWithin) //This loop gets the contained ingredients name and quality
        {
            if (ingredientObject.CompareTag("Ingredient"))
            {
                ingredientsScripts.Add(ingredientObject.GetComponent<ingredient>());
                quality += ingredientObject.GetComponent<ingredient>().quality;
                currentIngredientNames.Add(ingredientObject.GetComponent<ingredient>().ingredientName);
            }
        }
        quality /= gameObjectsWithin.Count;
        currentIngredientNames.Sort();


        bool same = true;
        foreach(List<string> potion in potionOptions) //This series of loops checks if the ingredients in the pot are the same as any recipies
        {
            if (currentIngredientNames.Count == potion.Count)
            {
                for(int i = 0; i<currentIngredientNames.Count; i++)
                {
                    if(currentIngredientNames[i] != potion[i])
                    {
                        same = false;
                    }
                }
                if (same == true)
                {
                    currentPotion = potionOptions.IndexOf(potion);
                }
                same = true;
            }
        }
        if (currentPotion != -1)
        {
            if (currentPotion == 0)
            {
                GameObject tempPotion = Instantiate(baseSolutionObject);
                tempPotion.GetComponent<potionObjectScript>().quality = quality;
                
            }
            else if (currentPotion == 1)
            {
                GameObject tempPotion = Instantiate(speedPotionObject);
                tempPotion.GetComponent<potionObjectScript>().quality = quality;
            }
            else if (currentPotion == 2)
            {
                GameObject tempPotion = Instantiate(antidotePotionObject);
                tempPotion.GetComponent<potionObjectScript>().quality = quality;
            }
            else if (currentPotion == 3)
            {
                GameObject tempPotion = Instantiate(strengthPotionObject);
                tempPotion.GetComponent<potionObjectScript>().quality = quality;
            }
            
            for (int i = 0; i<gameObjectsWithin.Count;i=0)
            {
                Destroy(gameObjectsWithin[i]);
            }

        }
        else
        {
            //return "none";
        }

    }
}
