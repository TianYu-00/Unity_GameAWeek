using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameMechanicScript : MonoBehaviour
{
    public KeyCode placeBlockButton;
    public GameObject gameobjectBlock; //The placed gameobject
    private Vector3 spawnPos; //spawn point
    public GameObject player; //Player
    public int amountOfBlocks = 5; //allow 5 blocks

    //amount of blocks text
    public TextMeshProUGUI amountOfBlocksText;


    // Start is called before the first frame update
    void Start()
    {
        spawnPos = transform.position;
        amountOfBlocksText.text = amountOfBlocks + "/5";
        Cursor.lockState = CursorLockMode.Locked;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(placeBlockButton) && amountOfBlocks > 0)
        {

            amountOfBlocks = amountOfBlocks - 1;
            amountOfBlocksText.text = amountOfBlocks + "/5";
            GameObject tempBlock = Instantiate(gameobjectBlock, transform.position, Quaternion.identity);
            //Destroy(tempBlock, 0.8f);
            Instantiate(player, spawnPos, Quaternion.identity);
            Destroy(player);

            
        }
        /*else
        {
            Debug.Log("No more blocks allowed.");
        }*/
    }
}
