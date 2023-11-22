using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    public Text pointsText;

    //gameobjects to turn off
    public GameObject compass;
    public GameObject canvas;

    //display score in death screen and display screen
    public void Setup(int score){
        gameObject.SetActive(true);
        pointsText.text = score.ToString() + " Trash(es) Collected";
        canvas.SetActive(false);
        compass.SetActive(false);
    }

    //reload scene, play again
    public void RestartButton(){
        SceneManager.LoadScene("C_World");
    }

    //quit game
    public void ExitButton(){
        Application.Quit();
        //UnityEditor.EditorApplication.isPlaying = false;
    }
}
