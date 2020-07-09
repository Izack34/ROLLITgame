using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menurotation : MonoBehaviour
{
    public Transform camera_rotate;
    void Start()
    {
        Time.timeScale = 1;

    }
    // Update is called once per frame
    void Update()
    {
        
        camera_rotate.Rotate(0, 2f * Time.deltaTime ,0);
        
    }
}
