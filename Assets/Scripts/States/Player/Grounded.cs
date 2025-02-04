using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "States/Player/Grounded")]
public class Grounded : BasePlayerState
{
    [Header("Parameters")]
    public float walkSpeed = 5;
    public float runSpeed = 10;
    public float coyoteTime = 0.1f;
    float curCoyoteTime;


    public override void Enter()
    {
        base.Enter();
        player.body.velocity = Vector2.zero;
    }

    public override void Process()
    {
        base.Process();

        if (player.isGrounded)
        {
            curCoyoteTime = coyoteTime;
        }
        else
        {
            curCoyoteTime -= Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.Space) && coyoteTime > 0)
        {
            stateMachine.ChangeState<Jump>();
            return;
        }
    }

    public override void PhysicsProcess()
    {
        float speed = Input.GetKey(KeyCode.LeftShift) ? runSpeed : walkSpeed;
        float x = Input.GetAxis("Horizontal") * speed;

        player.body.velocity = new Vector2(x, player.body.velocity.y);
    }
}
