using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (!SceneManager.GetSceneByBuildIndex(1).isLoaded) 
        {
            SceneManager.LoadSceneAsync(1, LoadSceneMode.Additive);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
