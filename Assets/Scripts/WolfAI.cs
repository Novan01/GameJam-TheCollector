using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The wolf AI to control wolf attacking and chasing player
/// </summary>
public class WolfAI : MonoBehaviour
{
    //player objects
    public GameObject player;
    public PlayerController pc;

    public static WolfAI instance;
    //wolf speed, rotation, and detection radius
    float speed = 4;
    float radius = 400;
    float rotationSpeed = 100f;
    //check if the player is not safe
    public bool isNotSafe;

    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
        this.isNotSafe = true;
    }

    // Update is called once per frame

    //method to stop the wolfs if player is safe
    public void stopWolf()
    {
        //Debug.Log("STOP");
        this.isNotSafe = false;
        speed = 0;
        //Debug.Log("stopW test " + isNotSafe);

    }

    void Update()
    {
        //if the time is night and player is not safe start wolves to chase
        if ((LightingManager.instance.getTimeOfDay() >= 18 || LightingManager.instance.getTimeOfDay() <= 6) && isNotSafe)
        {

            transform.LookAt(player.transform); //cause wolves to look at player

            //move wolfs to the player
            if (Vector3.Distance(transform.position, player.transform.position) <= radius)
            {
                //Debug.Log("speed: " + speed);
                if (pc.isDead == false)
                {
                    transform.Translate(Vector3.forward * speed * Time.deltaTime);
                }
                else
                {
                    transform.Rotate(Vector3.up * rotationSpeed);
                    transform.Translate(Vector3.forward * speed * Time.deltaTime);
                }


            }
        }

        
    }
            
        
}

