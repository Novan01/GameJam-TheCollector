using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlashlightScript : MonoBehaviour
{
    // Start is called before the first frame update
    
    public bool isOn = false; //checks if light is on/off
    
    //gamestate variables
    public GameObject lightSource;
    public AudioSource clickSound;
 
    public bool failSafe = false; //failsafe from infinite loop

    public Text prompt; //user prompt to turn on light

    // Update is called once per frame
    void Update()
    {
        //check if its getting dark - prompt user for keybind for light
        if (LightingManager.instance.getTimeOfDay() > 18f && LightingManager.instance.getTimeOfDay() < 24f)
        {
            //Debug.Log("Its Now");
            prompt.text = "Press F for Flashlight";
            
        }
        else
        {
            prompt.text = "";
        }

        //input for light and turning on or off
        if (Input.GetButtonDown("Flashlight"))
        {
            if(isOn == false)
            {
                lightSource.SetActive(true);
                isOn = true;
                failSafe = true;
                clickSound.Play();
                StartCoroutine(FailSafe());
                
            }
            if(isOn == true && failSafe == false)
            {
                failSafe = true;
                lightSource.SetActive(false);
                isOn = false;
                clickSound.Play();
                StartCoroutine(FailSafe());
            }
        }
    }

    //enum for failsafe to stop infinite loop
    IEnumerator FailSafe()
    {
        yield return new WaitForSeconds(0.25f);
        failSafe = false;
    }

}
