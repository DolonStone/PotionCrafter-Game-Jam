using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scenechange : MonoBehaviour
{
    public string newScene;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void OnMouseDown()
    {
        SceneManager.LoadScene(newScene);
    }

    // Update is called once per frame
    void Update()
    {
    }
}
