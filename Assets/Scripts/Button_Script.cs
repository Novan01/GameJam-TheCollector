using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Button_Script : MonoBehaviour
{
    //button to reload scene
    public void Play_Again_Buttion(){
        SceneManager.LoadScene("C_World");
    }

    //button to quit game
    public void Exit_Button(){
        Application.Quit();
    }
}
