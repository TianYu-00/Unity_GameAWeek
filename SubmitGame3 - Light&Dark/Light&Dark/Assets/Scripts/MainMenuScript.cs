using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    private int nextSceneToLoad;
    public GameObject optionsMenuPanel;
    public GameObject mainMenuPanel;


    // Start is called before the first frame update
    void Start()
    {
        optionsMenuPanel.SetActive(false);
        mainMenuPanel.SetActive(true);


    }

    // Update is called once per frame
    void Update()
    {

    }


    public void backButtonClick()
    {
        
        mainMenuPanel.SetActive(true);
        optionsMenuPanel.SetActive(false);

    }


    public void LevelSelectorButtonClick()
    {
        SceneManager.LoadScene("LevelSelector");
    }

    
    
    public void playButtonClick()
    {
        nextSceneToLoad = SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadScene(nextSceneToLoad);
    }

    public void optionButtonClick()
    {
        optionsMenuPanel.SetActive(true);
        mainMenuPanel.SetActive(false);
    }



    public void quitButtonClick()
    {
        Application.Quit();
    }
}
