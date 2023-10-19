using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private int nextSceneToLoad;
    AudioSource completeSound;
    public GameObject endgameCanvas;
    // Start is called before the first frame update
    void Start()
    {
        nextSceneToLoad = SceneManager.GetActiveScene().buildIndex + 1;
        completeSound = GetComponent<AudioSource>();
        endgameCanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (SceneManager.GetActiveScene().buildIndex == 11)
            {
                endgameCanvas.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
            }
            else
            {
                completeSound.Play();
                SceneManager.LoadScene(nextSceneToLoad);
                if (nextSceneToLoad > PlayerPrefs.GetInt("curLevel"))
                {
                    PlayerPrefs.SetInt("curLevel", nextSceneToLoad);
                }
            }
            
        }
        else
        {
            Debug.Log("Max Level Reached/No Next Scene");
        }
        
    }
}
