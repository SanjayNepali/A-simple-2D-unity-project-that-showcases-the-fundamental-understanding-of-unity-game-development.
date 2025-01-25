using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class CameraMovement : MonoBehaviour
{
  //SerializeField help us directly set values in unity inspector
   
    [SerializeField] GameObject player;
    [SerializeField] float smoothSpeed=0.125f;
    //using offset helps our camera be always be centered around our player
    [SerializeField] Vector3 offset;



//using lateupdate to move camera at a later time than our player
    public void LateUpdate()
  {
      offset.z=-10f;

       Vector3 newPosition = player.transform.position+ offset;
       Vector3 smoothPosition = Vector3.Lerp(transform.position,newPosition,smoothSpeed);
       transform.position=smoothPosition;


    }
}
