using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]private Image healthBar1;
    [SerializeField]private Image healthBar2;

    GameObject P1HealthScript;
    GameObject P2HealthScript;

    private int P1AmountHealth;
    private int P2AmountHealth;

    private float maxHealth = 10f;


    

    private void Awake()
    {
        P1HealthScript = GameObject.FindGameObjectWithTag("Player1");
        P2HealthScript = GameObject.FindGameObjectWithTag("Player2");
    }
    void Start()
    {
/*        P1AmountHealth = P1HealthScript.GetComponent<Player1Health>().P1health;
        P2AmountHealth = P2HealthScript.GetComponent<Player2Health>().P2health;*/
    }

    // Update is called once per frame
    void Update()
    {
        P1AmountHealth = P1HealthScript.GetComponent<Player1Health>().P1health;
        P2AmountHealth = P2HealthScript.GetComponent<Player2Health>().P2health;
        healthBar1.fillAmount = P1AmountHealth / maxHealth;
        healthBar2.fillAmount = P2AmountHealth / maxHealth;
    }
}
