using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class InGameGui : MonoBehaviour
{
    
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject WarningText;
    public GameObject end_results;
    public TextMeshProUGUI CountPickUps;
    public TextMeshProUGUI CountTime;
    public TextMeshProUGUI EndTime;
    public float miliseconds, seconds, minutes;


    void Start()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false; 
        Cursor.lockState = CursorLockMode.Locked; 
        Cursor.visible = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(GameIsPaused){
                Resume();
            }
            else{
                Pause();
            }
        }

        TimeCount();
    }

    public void Resume()
    {

        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        Cursor.lockState = CursorLockMode.Locked; 
        Cursor.visible = false;

    }
    void Pause()
    {

        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

    }

    public void toMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void toQuit()
    {
        Application.Quit();
    }

    public void toReset()
    {
        SceneManager.LoadScene(Application.loadedLevel);
    }

    public void SetNumberOfPickups(int i){
        CountPickUps.text = i.ToString()+"/3";
    }

    public void TimeCount(){

        minutes = (int)(Time.timeSinceLevelLoad / 60f);
        seconds = (int)(Time.timeSinceLevelLoad % 60f);
        miliseconds = (int)((Time.timeSinceLevelLoad * 1000) % 1000);
    
        CountTime.text = minutes.ToString("00") + ":" + seconds.ToString("00") + ":" + miliseconds.ToString("00");
    }

    public void WarningActive(){
        WarningText.SetActive(true);
    }
    public void EndResult(){
        end_results.gameObject.SetActive(true);
        EndTime.text = "Your time: " + minutes.ToString("00") + ":" + seconds.ToString("00") + ":" + miliseconds.ToString("00");
    }
}
