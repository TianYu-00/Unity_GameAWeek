using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuManagerScript : MonoBehaviour
{
    public GameObject pausemenuPanel;
    public KeyCode pauseMenuButton;
    private bool pauseChecker = false;
    // Start is called before the first frame update
    void Start()
    {
        pausemenuPanel.SetActive(false);
        resume();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(pauseMenuButton) && pauseChecker == false)
        {
            pausemenuPanel.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            pause();
            pauseChecker = true;
            
        }
        else if(Input.GetKeyDown(pauseMenuButton) && pauseChecker == true)
        {
            pausemenuPanel.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            resume();
            pauseChecker = false;

        }
    }

    public void backButtonClick()
    {
        pausemenuPanel.SetActive(true);

    }

    public void LevelSelectorButtonClick()
    {
        SceneManager.LoadScene("LevelSelector");
    }

    public void mainmenuClickButton()
    {
        
        SceneManager.LoadScene("MainMenu");
    }

    public void quitButtonClick()
    {
        Application.Quit();
    }

    void pause()
    {
        Time.timeScale = 0f;
    }

    void resume()
    {
        Time.timeScale = 1f;
    }



}
