using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    public Transform Player;

    //follow the players position with the camera
    void LateUpdate(){
        Vector3 CameraFollowPosition = Player.position;
        CameraFollowPosition.y = transform.position.y;
        transform.position = CameraFollowPosition;
    }
}
