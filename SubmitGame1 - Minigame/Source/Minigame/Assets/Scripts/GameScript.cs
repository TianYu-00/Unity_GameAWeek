using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;

public class GameScript : MonoBehaviour
{
    public int platformTimer;
    public float reactTimer;

    public GameObject[] platformArray;
    public GameObject[] blocks; //Holds all the clones for platformArray

    private int randomPrefab;

    //create a list to store values

    private int checker;

    //Timer
    float timer;
    public Text timerText;


    //AUDIO
    private AudioSource onChange;
    

    // Start is called before the first frame update
    void Start()
    {
        onChange = GetComponent<AudioSource>();
        Time.timeScale = 1f;
        //Loop through 3 x 3 square onto the map
        /*      for (int i = 0; i < 3; i++)
                {
                    Instantiate(objectPrefab, new Vector3(i * -13.77f, 36.1233f, 25.83288f), Quaternion.identity);
                    Instantiate(objectPrefab, new Vector3(i * -13.77f, 36.1233f, 12f), Quaternion.identity);
                    Instantiate(objectPrefab, new Vector3(i * -13.77f, 36.1233f, 40f), Quaternion.identity);
                }*/
        spawnObject();

        //randomizer //no repeat



        //Find the text
        Text colourText = GameObject.Find("Canvas/colourText").GetComponent<Text>();
        colourText.text = "";

        InvokeRepeating("start", 0f, 7f); //start the function in 0 seconds and loop it every 7 seconds

        
    }

    // Update is called once per frame
    void Update()
    {

        //Useless update smh //nvm
        timer += Time.deltaTime;

        float minutes = timer / 60;
        float seconds = timer % 60;
        float fraction = (timer * 100) % 100;
        timerText.text = string.Format("{0:00} : {1:00} : {2:000}", minutes, seconds, fraction);



    }

    void start()
    {
        StartCoroutine(startGame(5));
    }




    IEnumerator startGame(float time)
    {
        yield return new WaitForSeconds(time);

        // Code to execute after the delay
        gameMechanic();
        StartCoroutine(cloneCreatorTimer(platformTimer));
        

    }


    IEnumerator cloneCreatorTimer(float time)
    {
        yield return new WaitForSeconds(time);

        // Code to execute after the delay
        if (checker == 1)
        {
            spawnObject();
        }
        

    }


    public void gameMechanic()
    {
        

        randomPrefab = UnityEngine.Random.Range(0, platformArray.Length);
        Debug.Log(randomPrefab); //Display in consol which prefab has been destroyed
        //Destroy(blocks[randomPrefab]);

        for (int i = 0; i < platformArray.Length; i++) //loop through the array
        {
            if (randomPrefab != 0)
            {
                if (i != randomPrefab) //check to see if the i is NOT EQUAL to the random generated number
                { //if above statement is true //do these
                    Destroy(blocks[i], reactTimer); //destroy ALL object but 1
                    Debug.Log(randomPrefab); //log it into console.
                    Destroy(blocks[randomPrefab], platformTimer); //destroy the last prefab
                    checker = 1;
                }

            }
            else
            {
                checker = 0;
            }
            



            
        }

        int caseSwitch = randomPrefab;
        onChange.Play();
        Text colourText = GameObject.Find("Canvas/colourText").GetComponent<Text>();
        switch (caseSwitch)
        {
            case 0:
                Debug.Log("ALL");
                colourText.text = "Sike! No colours";
                colourText.color = Color.white;
                break;
            case 1:
                Debug.Log("BROWN");
                colourText.text = "BROWN";
                colourText.color = Color.black;
                colourText.color = new Color32(107, 38, 11, 255);

                break;
            case 2:
                Debug.Log("BLUE");
                colourText.text = "BLUE";
                colourText.color = Color.blue;
                break;
            case 3:
                Debug.Log("GREEN");
                colourText.text = "GREEN";
                colourText.color = Color.green;
                break;
            case 4:
                Debug.Log("ORANGE");
                colourText.text = "ORANGE";
                //colourText.color = Color.;
                colourText.color = new Color32(255, 171, 0, 255);
                break;
            case 5:
                Debug.Log("PINK");
                colourText.text = "PINK";
                colourText.color = new Color32(255, 135,248, 255);
                break;
            case 6:
                Debug.Log("PURPLE");
                colourText.text = "PURPLE";
                colourText.color = new Color32(188, 0,255, 255);
                break;
            case 7:
                Debug.Log("RED");
                colourText.text = "RED";
                colourText.color = Color.red;
                break;
            case 8:
                Debug.Log("YELLOW");
                colourText.text = "YELLOW";
                colourText.color = Color.yellow;
                break;
            case 9:
                Debug.Log("AQUA");
                colourText.text = "AQUA";
                colourText.color = Color.cyan;
                break;
        }



    }



    public void spawnObject()
    {
        /*        Instantiate(redPlatform, new Vector3(1 * -13.77f, 36.1233f, 25.83288f), Quaternion.identity);
                Instantiate(blackPlatform, new Vector3(2 * -13.77f, 36.1233f, 25.83288f), Quaternion.identity);
                Instantiate(greenPlatform, new Vector3(3 * -13.77f, 36.1233f, 25.83288f), Quaternion.identity);

                Instantiate(bluePlatform, new Vector3(1 * -13.77f, 36.1233f, 12f), Quaternion.identity);
                Instantiate(pinkPlatform, new Vector3(2 * -13.77f, 36.1233f, 12f), Quaternion.identity);
                Instantiate(yellowPlatform, new Vector3(3 * -13.77f, 36.1233f, 12f), Quaternion.identity);

                Instantiate(aquaPlatform, new Vector3(1 * -13.77f, 36.1233f, 40f), Quaternion.identity);
                Instantiate(purplePlatform, new Vector3(2 * -13.77f, 36.1233f, 40f), Quaternion.identity);
                Instantiate(orangePlatform, new Vector3(3 * -13.77f, 36.1233f, 40f), Quaternion.identity);*/

        blocks = new GameObject[platformArray.Length]; //makes sure they match length
        int counterX = 0;
        int counterX2 = 0;
        int counterX3 = 0;
        for (int i = 0; i < platformArray.Length; i++)
        {
            if (i <= 3 && i > 0)
            {
                blocks[i] = Instantiate(platformArray[i], new Vector3(counterX * -13.77f, 36.1233f, 12f), Quaternion.identity) as GameObject;
                counterX += 1;
            }
            else if (i <= 6 && i > 3)
            {
                blocks[i] = Instantiate(platformArray[i], new Vector3(counterX2 * -13.77f, 36.1233f, 25.83288f), Quaternion.identity) as GameObject;
                counterX2 += 1;
            }
            else if (i <= 9 && i > 6)
            {
                blocks[i] = Instantiate(platformArray[i], new Vector3(counterX3 * -13.77f, 36.1233f, 40f), Quaternion.identity) as GameObject;
                counterX3 += 1;
            }

            for (int a = 0; a < platformArray.Length; a++)
            {
                int indexPlace = a;
                //Debug.Log(a);
            }

        }

    }


}
