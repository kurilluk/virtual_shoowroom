using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    // This requires the _Showroom scene to have Build index 0 and be in the Build Scenes.
    // Then the other scene with your content can be loaded on Start().
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
