using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackScript : MonoBehaviour
{
    //sets the time between each attack
    [SerializeField]private float attackRate = 1f;
    float nextAttackTime = 0f;

    //keycode to be used to attack
    [SerializeField] private KeyCode player1Attack;

    //main attacking variables
    public Transform attackPosition;
    public float attackRange;
    public LayerMask player2LayerMask;
    private Animator anim;
    
    //damage variable
    public int P2Damage;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextAttackTime)
        {
            if (Input.GetKeyDown(player1Attack))
            {
                anim.SetTrigger("isAttacking");
                //checks to see if they are overlapping
                Collider2D[] player2ToAttack = Physics2D.OverlapCircleAll(attackPosition.position, attackRange, player2LayerMask);
                for (int i = 0; i < player2ToAttack.Length; i++)
                {
                    player2ToAttack[i].GetComponent<Player2Health>().P2TakeDamage(P2Damage); // divide by 2 to get the correct amount of damage;
                }
                nextAttackTime = Time.time + 1f / attackRate;

            }
            
        }
    }

    private void OnDrawGizmosSelected()
    {
        //draws the outline of the attack.
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(attackPosition.position, attackRange);
    }

}
