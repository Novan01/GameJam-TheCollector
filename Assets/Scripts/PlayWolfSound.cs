using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Wolf audio controller script
public class PlayWolfSound : MonoBehaviour
{
    public AudioSource wolfSound;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame

    //if time is night play wolf sound
    void Update()
    {
        if(LightingManager.instance.getTimeOfDay() >= 18)
        {
            wolfSound.Play();
        }
    }
}
