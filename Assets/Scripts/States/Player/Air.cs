using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "States/Player/Air")]
public class Air : BasePlayerState
{
    [Header("Parameters")]
    public float airSpeed = 5;
    public float fastAirSpeed = 10;
    public float gravity = 1;
    public float jumpTime = 0.5f;
    public float groundCheckDistance = 1;
    float curJumpTime;
    public bool wasRunning;

    public override void Enter()
    {
        base.Enter();
        curJumpTime = jumpTime;

        wasRunning = Input.GetKey(KeyCode.LeftShift);

        Debug.Log(wasRunning);
    }
    

    public override void PhysicsProcess()
    {
        base.PhysicsProcess();

        if (player.isGrounded)
        {
            stateMachine.ChangeState<Grounded>();
            return;
        }

        gravity = Input.GetKey(KeyCode.Space) && curJumpTime > 0 ? 2 : 5;
        curJumpTime -= Time.deltaTime;

        float horizontalAxis = Input.GetAxis("Horizontal");
        float speed;

        if (Mathf.Abs(horizontalAxis) > 0 && wasRunning)
        {
            speed = fastAirSpeed;
        }
        else
        {
            speed = airSpeed;
            wasRunning = false;
        }

        float x = Input.GetAxis("Horizontal") * speed;

        player.body.velocity = new Vector2(x, player.body.velocity.y);

        player.body.gravityScale = gravity;
    }
}
