using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfAudio : MonoBehaviour
{
    public GameObject wolfAudio;
    int safe = 0;


    // Update is called once per frame
    void Update()
    {
        if (LightingManager.instance.getTimeOfDay() > 18f && safe == 0)
        {
            wolfAudio.SetActive(true);
            safe += 1;
        }
    }
}
