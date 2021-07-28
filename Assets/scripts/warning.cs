using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class warning : MonoBehaviour
{
    private InGameGui Gui;

    private void Start() {
        Gui = GameObject.FindWithTag("MainGUI").GetComponent<InGameGui>();
    }

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Player"))
        {
            Gui.WarningActive();
        } 
    }

}
