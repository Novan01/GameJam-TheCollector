using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script for the save point to end the game and save the player
public class SavePoint : MonoBehaviour
{
    public GameObject completeLevelUI;
    public GameObject Canvas;
    GameObject[] wolves;
    public Get_Score get_score;


    private void OnTriggerEnter(Collider other)
    {
        //if the player has trash and walks into the car invis box
        if(other.gameObject.CompareTag("Player") && PointCounter.instance.Score() > 0)
        {
            //set wolves array
            wolves = GameObject.FindGameObjectsWithTag("Wolf");
            //End the game - stop the wolves
            foreach (GameObject wolf in wolves)
            { 
                wolf.SetActive(false);
            }
            //Debug.Log("Winner");
            //Display score and end game
            get_score.Setup(PointCounter.instance.Score());
            completeLevelUI.SetActive(true);
            Canvas.SetActive(false);

            //Application.Quit();
        }
    }
}
