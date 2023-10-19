using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject pauseMenu;
    public static bool checkPause = false;
    void Start()
    {
        pauseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (checkPause)
            {
                resumeGame();
                Cursor.lockState = CursorLockMode.Locked; //lock mouse
            }
            else
            {
                pauseGame();
                Cursor.lockState = CursorLockMode.None; //unlock mouse
            }
            Debug.Log("Paused ACTIVE");
        }
    }

    void resumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        checkPause = false;
        Debug.Log("Resume");
    }
    void pauseGame() 
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        checkPause = true;
        Debug.Log("Paused");
    }

    public void resumeClick()
    {
        pauseMenu.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked; //lock mouse
        Time.timeScale = 1f;
        checkPause = false;
        Debug.Log("Resume");
    }

    public void mainmenuClick()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1f;
    }
    public void quitClick()
    {
        Application.Quit();
        Debug.Log("Quit");
    }


}
