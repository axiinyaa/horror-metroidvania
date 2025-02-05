using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Components")]
    public Rigidbody2D body;
    public CapsuleCollider2D normalCollider;
    public CapsuleCollider2D crouchCollider;

    [Header("Other stuff")]
    public LayerMask groundLayer;
    public bool isGrounded;
    public float jumpBuffer = 0.2f;
    [HideInInspector]
    public float curJumpBuffer;

    public void SwitchCollider(bool crouching)
    {
        normalCollider.enabled = !crouching;
        crouchCollider.enabled = crouching;
    }

    public void Update()
    {
        isGrounded = Physics2D.OverlapCircle(transform.position, 0.1f, groundLayer);

        if (isGrounded) 
        {
            curJumpBuffer = jumpBuffer;
        }
        else
        {
            curJumpBuffer -= Time.deltaTime;
        }
    }
}
