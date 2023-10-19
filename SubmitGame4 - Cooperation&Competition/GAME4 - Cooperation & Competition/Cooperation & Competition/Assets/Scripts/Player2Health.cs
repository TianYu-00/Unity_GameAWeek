using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Health : MonoBehaviour
{
    public int P2health;
    private Animator P2Animator;

    // Start is called before the first frame update
    void Start()
    {
        P2Animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (P2health <= 0)
        { 
            //what happens when player2 has no health
            //animation
            //game ends
        }
    }

    public void P2TakeDamage(int P2Damage)
    {


        if (P2health > 2)
        {
            P2health -= P2Damage;
            P2Animator.SetTrigger("isTakeDamage");
        }
        else if (P2health <= 2)
        {
            P2health -= P2Damage;
        }
        Debug.Log("P2_TakeAwayHealth"); //instead of debug //maybe i can implement a health bar??? //yeah i think thats do able.
        //Ill do it below here tomorrow.

    }
}
