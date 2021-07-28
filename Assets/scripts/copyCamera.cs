using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameracontrol : MonoBehaviour
{
    public GameObject player;

    private Vector3 offset;

    private float turnAngle;

    public float Smoothfactor =0.5f;

    public float Rotatespeed =5f;

    const float distance=6f;

    public float distanceFromObject = 3f;

    Quaternion r1= Quaternion.Euler(27,23,0);

    
    void Start()
    {
        offset= transform.position - player.transform.position;
        //position= ScreenToViewportPoint(Input.mousePosition);

    }


    //void LateUpdate()
    //{
    //    Vector3 direction=player.GetComponent<Rigidbody>().velocity.normalized;
    //    Vector3 offset2= (-1)*(direction);
    //    transform.position = player.transform.position + offset + offset2 ;
    //    transform.LookAt(player.transform);
    //    
    //}
    
    void Update() {
        Quaternion camTurnAngle = Quaternion.AngleAxis(Input.GetAxis("Mouse X")* Rotatespeed , Vector3.up);
    
        offset = camTurnAngle * offset;
    
        Vector3 position = player.transform.position + offset;
    
        transform.position =Vector3.Slerp(transform.position, position , Smoothfactor);

        Vector3 directiontoface= transform.position - player.transform.position; 

        transform.rotation= Quaternion.LookRotation(directiontoface);
    }

    //void Update()
    //{
    //    Vector3 lookOnObject = player.transform.position - transform.position;
    //    lookOnObject = player.transform.position - transform.position;
    //    transform.forward = lookOnObject.normalized;
    //    Vector3 playerLastPosition;
    //    playerLastPosition = player.transform.position - lookOnObject.normalized * distanceFromObject;
    //    playerLastPosition.y = player.transform.position.y + distanceFromObject / 2;
    //    transform.position = playerLastPosition;
    //}
}
