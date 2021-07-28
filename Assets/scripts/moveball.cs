using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class moveball : MonoBehaviour
{
    private InGameGui Gui;
    public float speed = 10f;
    public Transform camera_root;

    private Vector3 movement;

    public float jump_Force = 35f;

    private float vertical_Velocity;

    private int count = 0;

    private Rigidbody rb;

    private Vector3 start_vector;

    private float DisstanceToTheGround;
    
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        start_vector = transform.position;
        Gui = GameObject.FindWithTag("MainGUI").GetComponent<InGameGui>();

        float DisstanceToTheGround = GetComponent<Collider>().bounds.extents.y;
        
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)){
            Application.LoadLevel(Application.loadedLevel);
        }
        
        if (Input.GetKeyDown(KeyCode.Q)){
            SceneManager.LoadScene(0);
            Cursor.lockState = CursorLockMode.None;
        }

        //movement
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        bool IsGround = Physics.Raycast(transform.position, Vector3.down, DisstanceToTheGround + 1.2f);

        Vector3 movement = new Vector3 (moveHorizontal, 0.0f ,moveVertical);

        if (Input.GetButtonDown("Jump") && IsGround ){
            rb.AddForce(Vector3.up * jump_Force, ForceMode.Impulse);   
        }

        movement = Quaternion.Euler(0,camera_root.eulerAngles.y,0) * movement ;
        //if (IsGround){
        rb.AddForce(movement * speed);
        //}
    }
    
    void OnTriggerEnter(Collider other) {

        //kolizje
        if (other.gameObject.CompareTag("PickUP"))
        {
            other.gameObject.SetActive(false);
            count += 1;
            Gui.SetNumberOfPickups(count);
        } 

        if (other.gameObject.CompareTag("Finish"))
        {
            if (count == 3)
            {
                Time.timeScale = 0f;

                Gui.EndResult();

                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
        }
    }
}

