using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D body;
    public LayerMask groundLayer;
    public bool isGrounded;

    public void Update()
    {
        isGrounded = Physics2D.OverlapCircle(transform.position, 0.1f, groundLayer);
    }
}
