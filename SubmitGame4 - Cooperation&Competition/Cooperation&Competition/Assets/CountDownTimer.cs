using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class CountDownTimer : MonoBehaviour
{
    private float currentTime;
    public float startTimer = 60f;

    public TextMeshProUGUI timerText;

    private bool gameoverCalled = false;

    GameObject P1HealthScript;
    GameObject P2HealthScript;

    Animator P1Animator;
    Animator P2Animator;

    private int P1AmountHealth;
    private int P2AmountHealth;


    public bool player1Death = false;
    public bool player2Death = false;

    public GameObject gameOverText;
    public GameObject Player1WinText;
    public GameObject Player2WinText;

    public GameObject MainMenuButton;
    public GameObject RestartButton;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = startTimer;
        P1HealthScript = GameObject.FindGameObjectWithTag("Player1");
        P2HealthScript = GameObject.FindGameObjectWithTag("Player2");
        gameOverText.SetActive(false);
        Player1WinText.SetActive(false);
        Player2WinText.SetActive(false);
        MainMenuButton.SetActive(false);
        RestartButton.SetActive(false);
        resume();
    }

    // Update is called once per frame
    void Update()
    {
        P1AmountHealth = P1HealthScript.GetComponent<Player1Health>().P1health;
        P2AmountHealth = P2HealthScript.GetComponent<Player2Health>().P2health;
        P1Animator = P1HealthScript.GetComponent<PlayerMovementScript>().anim;
        P2Animator = P2HealthScript.GetComponent<PlayerMovementP2>().anim;
        

        currentTime -= 1 * Time.deltaTime;
            timerText.text = currentTime.ToString("00:00");

            if (currentTime <= 0)
            {
                currentTime = 0;
                gameOver();

            }

        if (P1AmountHealth <= 0 && gameoverCalled == false)
        {
            P1Animator.SetTrigger("isDeath");
            Debug.Log("Player2 Win");
            gameoverCalled = true;
            player1Death = true;
            
            StartCoroutine(endGame(1));
            Player2WinText.SetActive(true);

            

            



        }
        else if (P2AmountHealth <= 0 && gameoverCalled == false)
        {
            P2Animator.SetTrigger("isDeath");
            Debug.Log("Player1 Win");
            gameoverCalled = true;
            player2Death = true;
            
            
            StartCoroutine(endGame(1));
            Player1WinText.SetActive(true);



        }

    }

    public void gameOver()
    {
        Debug.Log("Time Over");

        if (P1AmountHealth > P2AmountHealth && gameoverCalled == false)
        {
            P2Animator.SetTrigger("isDeath");
            Debug.Log("Player1 Win");
            gameoverCalled = true;
            player2Death = true;
            
            StartCoroutine(endGame(1));

            Player1WinText.SetActive(true);
 
            
        }
        else if (P1AmountHealth < P2AmountHealth && gameoverCalled == false)
        {
            P1Animator.SetTrigger("isDeath");
            Debug.Log("Player2 Win");
            gameoverCalled = true;
            player1Death = true;
            
            StartCoroutine(endGame(1));

            Player2WinText.SetActive(true);

            
        }
    }

    IEnumerator endGame(float time)
    {
        yield return new WaitForSeconds(time);

        // Code to execute after the delay
        paused();
        gameOverText.SetActive(true);
        MainMenuButton.SetActive(true);
        RestartButton.SetActive(true);

    }

    void paused()
    {
        Time.timeScale = 0f;
    }

    void resume()
    {
        Time.timeScale = 1f;
    }

    public void mainMenuButtonClick()
    {
        SceneManager.LoadScene(0);
    }

    public void restart()
    {
        SceneManager.LoadScene(1);
    }

}
