using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class moveball : MonoBehaviour
{
    public float speed = 10f;

    public Text count_Text;

    public Text count_time;

    public Transform camera_root;

    public GameObject end_results;

    private Vector3 movement;

    public float jump_Force = 25f;

    private float vertical_Velocity;

    private int count;

    private Rigidbody rb;

    private Vector3 start_vector;

    private GameObject[] goArray;

    private float DisstanceToTheGround;
    
    //public Material[] material;
    //Renderer rend;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        start_vector=transform.position;
        float DisstanceToTheGround = GetComponent<Collider>().bounds.extents.y;
        count =0;
        goArray = GameObject.FindGameObjectsWithTag("PickUP");
        //rend = GetComponent<Renderer>();
        //rend.sharedMaterial = material[1];
    }

    
    void Update()
    {
        //restart
        if (Input.GetKeyDown(KeyCode.R)){
            Application.LoadLevel(Application.loadedLevel);
        }
        
        if (Input.GetKeyDown(KeyCode.Q)){
            SceneManager.LoadScene(0);
            Cursor.lockState = CursorLockMode.None;
        }

        //movement
        float moveHorizontal =Input.GetAxis("Horizontal");
        float moveVertical =Input.GetAxis("Vertical");
        bool IsGround = Physics.Raycast(transform.position, Vector3.down, DisstanceToTheGround + 0.7f);

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
            count= count + 1;
            SetCounttext();
        } 
        
        //else if (other.gameObject.CompareTag("ToLightBall")){
        //    rb.mass = 0.3f;
        //    rend.sharedMaterial = material[0];
        //    jump_Force = 1.5f;
        //    speed = 0.7f;
        //} else if (other.gameObject.CompareTag("ToHeavyBall")){
        //    rb.mass = 1.5f;
        //    rend.sharedMaterial = material[2];
        //    jump_Force = 8f;
        //    speed = 3f;
        //} else if (other.gameObject.CompareTag("ToNormalBall")){
        //    rb.mass = 1f;
        //    rend.sharedMaterial = material[1];
        //    jump_Force = 4.6f;
        //    speed = 1.76f;
        //}
        if (other.gameObject.CompareTag("Finish"))
        {
            if (count == 3)
            {
                float minutes =(int)(Time.timeSinceLevelLoad/60f);
                float seconds =(int)(Time.timeSinceLevelLoad % 60f);
                count_time.text = "Your time: "+ minutes.ToString("00") + ":" + seconds.ToString("00");
                end_results.gameObject.SetActive(true);
                Time.timeScale = 0f;
                //pauseMenuUI.GameIsPaused = false; 
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
        }
    }
    void SetCounttext()
    {
        count_Text.text = count.ToString()+"/3";
    }
    
}

