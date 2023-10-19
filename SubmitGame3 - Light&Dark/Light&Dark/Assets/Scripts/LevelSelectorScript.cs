using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelectorScript : MonoBehaviour
{
    public Button[] allLevelButton;
    // Start is called before the first frame update
    void Start()
    {
        int curLevel = PlayerPrefs.GetInt("curLevel", 2);

        for (int i = 0; i < allLevelButton.Length; i++)
        {
            if (i + 2 > curLevel)
            {
                allLevelButton[i].interactable = false;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void levelSelectorBackButton()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void ChangeSceneButton(string levels)
    {
        SceneManager.LoadScene(levels);
    }
}
