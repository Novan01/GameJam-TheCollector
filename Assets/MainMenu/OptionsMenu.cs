using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class OptionsMenu : MonoBehaviour
{
    public GameObject mainMenu;
    public AudioMixer audioMixer;

    //volume slider
    public void changeVolume(float volume){
        audioMixer.SetFloat("volume", volume);
    }

    //method to go mack to main menu
    public void goBack(){
        mainMenu.SetActive(true);
        gameObject.SetActive(false);
       
    }
}
