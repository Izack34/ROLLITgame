﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class time : MonoBehaviour
{
    public Text counterText;

    public float seconds, minutes;
    // Start is called before the first frame update
    void Start()
    {
        //Time.time=Time.timeSinceLevelLoad;
    }

    // Update is called once per frame
    void Update()
    {
        minutes =(int)(Time.timeSinceLevelLoad/60f);
        seconds =(int)(Time.timeSinceLevelLoad % 60f);
        counterText.text = minutes.ToString("00") + ":" + seconds.ToString("00");
    }
}
