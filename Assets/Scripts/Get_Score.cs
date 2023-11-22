using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Get_Score : MonoBehaviour
{
    public Text pointsText;

    public GameObject compass;

    //display the score
    public void Setup(int score){
        gameObject.SetActive(true);
        pointsText.text = "Trash Collected: " + score.ToString();
        compass.SetActive(false);
    }
}
