using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class BallScript : MonoBehaviour
{
    [SerializeField]private float currentTime;
    public float startTimer = 5f;

    public TextMeshProUGUI timerText;
    public TextMeshProUGUI whichSideWon;
    public GameObject restartButton;
    public GameObject mainMenuButton;

    private bool gameoverCalled = false;

    
    // Start is called before the first frame update
    void Start()
    {
        currentTime = startTimer;
        gameoverCalled = false;
        Time.timeScale = 1f;
        whichSideWon.gameObject.SetActive(false);
        restartButton.SetActive(false);
        mainMenuButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        timerText.text = currentTime.ToString("00:00");

        if (currentTime <= 0)
        {
            currentTime = 0;
            

        }
    }

    public void gameOver()
    {
        Debug.Log("Time Over");
        gameoverCalled = true;
        whichSideWon.gameObject.SetActive(true);
        restartButton.SetActive(true);
        mainMenuButton.SetActive(true);
    }

   private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "BlackSide" && currentTime <= 0 && gameoverCalled == false)
        {
            gameOver();
            Debug.Log("BlackSide Loses");
            whichSideWon.text = "Yellow Side Wins";
            Time.timeScale = 0f;
        }
        else if (collision.gameObject.name == "YellowSide" && currentTime <= 0 && gameoverCalled == false)
        {
            gameOver();
            Debug.Log("YellowSide Loses");
            whichSideWon.text = "Black Side Wins";
            Time.timeScale = 0f;
        }

    }

    public void restartClickButton() {
        SceneManager.LoadScene("Level1"); 
    }

    public void mainMainClickButton()
    {
        SceneManager.LoadScene("MainMenu");
    }


}
