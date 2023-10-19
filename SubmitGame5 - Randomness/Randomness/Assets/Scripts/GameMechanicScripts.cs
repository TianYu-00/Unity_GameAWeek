using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameMechanicScripts : MonoBehaviour
{
    public TMP_InputField numberInputField;
    public TextMeshProUGUI HowCloseText;
    public TextMeshProUGUI ChancesLeftText;
    public int chancesLeftInt = 5;
    int inputtedNumber;
    [SerializeField] private static int randomNumber;
    public int amountToTakeAway;
    public int amountToAdd;
    int randomMin;
    int randomMax;

    public AudioSource submitSound;


    //for random number generator
    public int minInt;
    public int maxInt;

    //get the level text
    public TextMeshProUGUI levelText;

    //for level manager
    private int triggerLvINT;
    private int currentLvINT;
    public TextMeshProUGUI pointsText;

    //Gameover button
    public GameObject gameoverButton;


    [SerializeField] private KeyCode enter;
    // Start is called before the first frame update
    void Start()
    {
        submitSound = GetComponent<AudioSource>();


        randomNumber = Random.Range(minInt, maxInt);
        Debug.Log(randomNumber);
        randomMin = randomNumber - amountToTakeAway;
        randomMax = randomNumber + amountToAdd;
        Debug.Log("CurrentLV: " + currentLvINT);

        gameoverButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        checkIdenticalInt();
        
    }   


    public void checkIdenticalInt()
    {
        if (Input.GetKeyDown(enter))
        {
            inputtedNumber = int.Parse(numberInputField.text);
            if (randomNumber == inputtedNumber)
            {
                submitSound.Play();
                Debug.Log("Complete, Identical Number");
                HowCloseText.text =  inputtedNumber + " Is spot on!";
                
                triggerLvINT += 1;
                if (triggerLvINT == 1)
                {
                    randomNumber = Random.Range(minInt, maxInt);
                    Debug.Log(randomNumber);
                    randomMin = randomNumber - amountToTakeAway;
                    randomMax = randomNumber + amountToAdd;
                    triggerLvINT -= 1;
                    currentLvINT += 1;
                    pointsText.text = "Points: " + currentLvINT;
                    chancesLeftInt = 5;
                    ChancesLeftText.text = "Chances Left: 5";
                    numberInputField.text = "";
                }
                Debug.Log("CurrentLV: " + currentLvINT);
                switch (currentLvINT)
                {
                    //this case 0 wont be shown because its not put in start instead its after they getting the right number
                    case 0:
                        levelText.text = "Intro Level: \n Welcome to random number guesser \n A random number would be generated and your objective \n is to guess that number. Hints would be given. \n Press enter to submit your answer. \n Please enter in the field below a number between 1 - 10 \n You have 5 chances to guess the right numbers. \n";
                        return;

                    case 1:
                        maxInt = 10;
                        levelText.text = "A number between: " + minInt + " - " + maxInt;
                        return;
                    case 3:
                        maxInt = 20;
                        levelText.text = "A number between: " + minInt + " - " + maxInt;
                        return;
                    case 6:
                        maxInt = 40;
                        levelText.text = "A number between: " + minInt + " - " + maxInt;
                        return;
                    case 9:
                        maxInt = 50;
                        levelText.text = "A number between: " + minInt + " - " + maxInt;
                        return;
                    case 15:
                        maxInt = 100;
                        levelText.text = "A number between: " + minInt + " - " + maxInt;
                        return;
                }
                

            }
            else
            {
                numberInputField.text = "";
                if (inputtedNumber <= randomMin || inputtedNumber >= randomMax)
                {
                    HowCloseText.text = "Out Of Range";
                }
                else if (inputtedNumber >= randomMin && inputtedNumber <= randomMax)
                {
                    HowCloseText.text = "Close";
                }

                Debug.Log("Chances -1");
                chancesLeftInt -= 1;
                
                switch (chancesLeftInt)
                {
                    case 5:
                        ChancesLeftText.text = "Chances Left: 5";
                        return;
                    case 4:
                        ChancesLeftText.text = "Chances Left: 4";
                        return;
                    case 3:
                        ChancesLeftText.text = "Chances Left: 3";
                        return;
                    case 2:
                        ChancesLeftText.text = "Chances Left: 2";
                        return;
                    case 1:
                        ChancesLeftText.text = "Chances Left: 1";
                        return;
                    case 0:
                        ChancesLeftText.text = "Level Failed";
                        gameoverButton.SetActive(true);
                        //Or do whatever.
                        return;
                }
                
            }
            //After else
            



        }
        
    }

    public void restartButtonClick()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void mainMenuButtonClick()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
