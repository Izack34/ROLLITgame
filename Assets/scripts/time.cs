using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class time : MonoBehaviour
{
    //public Text counterText;
    private TextMeshProUGUI counterText;

    public float miliseconds, seconds, minutes;

    private void Start() {
        counterText = GetComponent<TextMeshProUGUI>();
        //time = 0;
    }
    void Update()
    {
        
        minutes = (int)(Time.timeSinceLevelLoad / 60f);
        seconds = (int)(Time.timeSinceLevelLoad % 60f);
        miliseconds = (int)((Time.timeSinceLevelLoad *1000) % 1000);
    
        counterText.text = minutes.ToString("00") + ":" + seconds.ToString("00") + ":" + miliseconds.ToString("00");
    }
}
