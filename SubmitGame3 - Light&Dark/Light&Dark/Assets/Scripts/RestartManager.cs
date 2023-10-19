using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartManager : MonoBehaviour
{
    public KeyCode restartButton;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(restartButton))
        {

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
