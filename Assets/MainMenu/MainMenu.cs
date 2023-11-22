using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{   
    //gameobjects
    public GameObject canvas;
    public GameObject options;
    public GameObject compass;
    public GameObject menu;

    //player
    public PlayerController player;
    
    //ui for score + time
    public GameObject scoreTimeUI;


    //method to start the game
    public void PlayGame(){
        // Set Main Menu Inactive and set Score Time UI to Active
        Debug.Log("start");
        scoreTimeUI.SetActive(true);
        canvas.SetActive(false);
        compass.SetActive(true);
        player.isDead = false;
        
        
    }
    //pause menu
   /* private void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            Pause();
        }
    } */

    /*public void Pause()
    {
        // Set Main Menu Inactive and set Score Time UI to Active
        Debug.Log("pause");
        menu.SetActive(true);
        scoreTimeUI.SetActive(true);
        canvas.SetActive(false);
        compass.SetActive(false);
        player.isDead = false;


    } */

    //menu options
    public void OpenOptions(){
        options.SetActive(true);
        gameObject.SetActive(false);
    }

    //method to quit the game
    public void QuitGame(){
        Debug.Log("quit");
        Application.Quit();
    }

    
}
