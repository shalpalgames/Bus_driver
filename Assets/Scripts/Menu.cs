using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Toggle))]
public class Menu : MonoBehaviour
{

    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject backSound;
    public Toggle audioToggle;


    
    public void Start()
    {
        audioToggle = GetComponent<Toggle>();
        if(AudioListener.volume == 0)
        {
            audioToggle.isOn = false;
        }
    }

    public void ToggleAudioOnValueChange(bool audioIn)
    {
        if(audioIn)
        {
            //backSound.SetActive(true);
            AudioListener.volume = 1;
        }
        else
        {
            //backSound.SetActive(false);
            AudioListener.volume = 0;
        }
    }


    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void MenuBt()
    {      
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("MyGame");
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
       
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }

    public void LoadGame()
    {
        SceneManager.LoadScene("DemoScene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
 
}
