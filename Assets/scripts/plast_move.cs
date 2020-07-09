using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plast_move : MonoBehaviour
{
    private float movementSpeed = -4f;
    // Update is called once per frame
    void Update()
    {
        if(transform.position.x <= -218 || transform.position.x >= -198){
            movementSpeed = -movementSpeed;
        }
        transform.position += new Vector3(movementSpeed*Time.deltaTime, 0, 0);
    }
}
