using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AccessMenu : MonoBehaviour
{
    [SerializeField] public bool isMenuOpen = true;
    [SerializeField] public Transform mainMenu;
    [SerializeField] public Transform crossHair;
    private void Start()
    {
        if (mainMenu.GetChild(0).gameObject.activeSelf == false)
        {
            ShowMainMenu();
        }
        

        //Scene menuScene = SceneManager.GetSceneByName("MainMenuScene");
        //isMenuOpen = menuScene.isLoaded;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (!isMenuOpen)
            {
                ShowMainMenu();
            }
            else
            {
                HideMainMenu();
            }

        }

        //if (Input.GetKeyDown(KeyCode.Tab))
        //{
        //    if (!isMenuOpen)
        //    {
        //        Cursor.lockState = CursorLockMode.Confined;
        //        //SceneManager.LoadScene(0); //Load mainmenu scene
        //        SceneManager.LoadSceneAsync(0, LoadSceneMode.Additive);
        //        isMenuOpen = true;
        //    }
        //    else
        //    {
        //        Cursor.lockState = CursorLockMode.Locked;
        //        //SceneManager.LoadScene(0); //Load mainmenu scene
        //        SceneManager.UnloadSceneAsync(0); //Unload mainmenu scene
        //        isMenuOpen = false;
        //    }

        //}
    }

    public void ShowMainMenu()
    {
        //Lock cursor and make cross hair dissappear
        Cursor.lockState = CursorLockMode.Confined;
        crossHair.GetChild(0).gameObject.SetActive(false);

        //Make the Main menu visible
        mainMenu.GetChild(0).gameObject.SetActive(true);
        isMenuOpen = true;
    }

    public void HideMainMenu()
    {
        //Unlock cursor and show cross hair
        Cursor.lockState = CursorLockMode.Locked;
        crossHair.GetChild(0).gameObject.SetActive(true);

        //Hide main menu
        mainMenu.GetChild(0).gameObject.SetActive(false);
        isMenuOpen = false;
    }
}
