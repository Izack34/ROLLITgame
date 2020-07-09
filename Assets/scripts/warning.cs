using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class warning : MonoBehaviour
{

    public GameObject warning_text;
    // Start is called before the first frame update

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Player"))
        {
            warning_text.SetActive(true);
        } 
    }

}
