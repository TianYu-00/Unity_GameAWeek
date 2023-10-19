using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheckerScript : MonoBehaviour
{
    [SerializeField] private LayerMask groundLayerMask;
    public bool isGrounded;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        isGrounded = collision != null && (((1<<collision.gameObject.layer) & groundLayerMask) != 0);

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isGrounded = false;
    }
}
