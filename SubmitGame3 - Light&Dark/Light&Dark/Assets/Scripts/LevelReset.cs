using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelReset : MonoBehaviour
{
    public KeyCode resetlevel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(resetlevel))
        {
            PlayerPrefs.DeleteAll();
        }
    }
}
