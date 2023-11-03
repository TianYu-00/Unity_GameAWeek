using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Health : MonoBehaviour
{
    public int P1health;
    private Animator P1Animator;

    // Start is called before the first frame update
    void Start()
    {
        P1Animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (P1health <= 0)
        {
            //what happens when player2 has no health
            //animation
            //game ends
        }
    }

    public void P1TakeDamage(int P1Damage)
    {
        if (P1health > 2)
        {
            P1health -= P1Damage;
            P1Animator.SetTrigger("isTakeDamage");
        }
        else if (P1health <= 2)
        {
            P1health -= P1Damage;
        }



        Debug.Log("P1_TakeAwayHealth"); //instead of debug //maybe i can implement a health bar??? //yeah i think thats do able.
        //Ill do it below here tomorrow.

    }
}
