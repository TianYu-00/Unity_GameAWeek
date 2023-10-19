using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackScript2 : MonoBehaviour
{
    //sets the time between each attack
    [SerializeField] private float attackRate = 1f;
    float nextAttackTime = 0f;

    //keycode to be used to attack
    [SerializeField] private KeyCode player2Attack;

    //main attacking variables
    public Transform attackPosition;
    public float attackRange;
    public LayerMask player1LayerMask;
    private Animator anim;

    //damage variable
    public int P1Damage;

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
            if (Input.GetKeyDown(player2Attack))
            {
                anim.SetTrigger("isAttacking");
                //checks to see if they are overlapping
                Collider2D[] player1ToAttack = Physics2D.OverlapCircleAll(attackPosition.position, attackRange, player1LayerMask);
                for (int i = 0; i < player1ToAttack.Length; i++)
                {
                    player1ToAttack[i].GetComponent<Player1Health>().P1TakeDamage(P1Damage); // divide by 2 to get the correct amount of damage;
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
