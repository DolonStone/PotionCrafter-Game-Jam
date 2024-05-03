using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IngredientManager : MonoBehaviour
{
    public static List<GameObject> ingredients;

    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
    void OnEnable()
    {

        SceneManager.sceneLoaded += OnLevelFinishedLoading;
    }

    void OnDisable()
    {

        SceneManager.sceneLoaded -= OnLevelFinishedLoading;
    }

    void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode)
    {
        if (GameObject.FindWithTag("Mortar"))
        {
            for (int i = 0; i <= ingredients.Count; i++)
            {
                Instantiate(ingredients[i]);
            }
        }

    }
}
