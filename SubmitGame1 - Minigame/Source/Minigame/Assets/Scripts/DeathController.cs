using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DeathController : MonoBehaviour
{
    public GameObject menuContainer;
    public GameObject colourText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //If the GameObject has the same tag as specified, output this message in the console
            Debug.Log("Death");
            menuContainer.SetActive(true);
            colourText.SetActive(false);
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0f;
        }
    }


}
