using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Compass : MonoBehaviour
{
    //direction variables
    public Vector3 northDirection;
    public Transform player;
    public Quaternion carDirection;

    //sprite layers
    public RectTransform northLayer;
    public RectTransform carLayer;

    //car location
    public Transform carPlace;
    // Update is called once per frame
    void Update()
    {
        //methods to change arrow direction
        changeNorthDirection();
        changeCarDirection();
    }

    //orient the north facing arrow
    public void changeNorthDirection()
    {
        northDirection.z = player.eulerAngles.y;
        northLayer.localEulerAngles = northDirection;
    }

    //orient the yellow arrow to face the car
    public void changeCarDirection()
    {
        Vector3 dir = transform.position - carPlace.position;
        carDirection = Quaternion.LookRotation(dir);
        carDirection.z = -carDirection.y;
        carDirection.x = 0;
        carDirection.y = 0;

        carLayer.localRotation = carDirection * Quaternion.Euler(northDirection);
    }
}
