using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PickupTrash : MonoBehaviour
{
    private bool pickUpAllowed; //check if you can pick up

    public static PickupTrash instance; //instance of trash script


    private void Update()
    {
        //check if they can pick up and press e
        if(pickUpAllowed && Input.GetKeyDown(KeyCode.E))
        {
            PickUp(); //pick up and increase score
            PointCounter.instance.AddPoint();
        }
    }
    //if player walks into trigger allow pickup
    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Player")
        {
            pickUpAllowed = true;
        }
        
    }

    //if player leaves cannot pick up
    private void OnTriggerExit(Collider other)
    {
        pickUpAllowed = false;
    }

    //method to destroy gameobject
    public void PickUp()
    {
        Destroy(gameObject, 2f);
       
    }
}
