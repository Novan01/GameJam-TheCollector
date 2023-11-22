using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PauseScript : MonoBehaviour
{
    public GameObject menu;

    //method to pause the game - redisplay main menu
    public void Pause()
    {
        // Set Main Menu Inactive and set Score Time UI to Active
        //Debug.Log("pause");
        menu.SetActive(true);


    }

    //keypress to pause
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
    }
}
