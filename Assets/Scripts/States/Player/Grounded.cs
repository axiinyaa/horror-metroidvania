using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "States/Player/Grounded")]
public class Grounded : BasePlayerState
{
    [Header("Parameters")]
    public float walkSpeed = 5;
    public float runSpeed = 10;
    public float crawlSpeed = 2;
    public float coyoteTime = 0.1f;
    float curCoyoteTime;


    public override void Enter()
    {
        base.Enter();
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

        if (Input.GetKeyDown(KeyCode.Space) && curCoyoteTime > 0)
        {
            stateMachine.ChangeState<Jump>();
            return;
        }
    }

    public override void PhysicsProcess()
    {
        var pos = player.transform.position + new Vector3(0f, 0.2f, 0f);
        bool isCeiling = Physics2D.Raycast(pos, Vector2.up, 1, player.groundLayer);

        Debug.DrawRay(pos, Vector2.up, Color.red);

        var crouching = Input.GetKey(KeyCode.LeftControl);
        var running = Input.GetKey(KeyCode.LeftShift);

        // We should stay crouching if there is a ceiling above us
        crouching = isCeiling ? true : crouching;
        
        player.SwitchCollider(crouching);

        float speed;

        speed = walkSpeed;
        
        if (running)
        {
            speed = runSpeed;
        }

        if (crouching)
        {
            speed = crawlSpeed;
        }

        float x = Input.GetAxis("Horizontal") * speed;

        player.body.velocity = new Vector2(x, player.body.velocity.y);
    }
}
