using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "States/Player/Jump")]
public class Jump : BasePlayerState
{
    public float jumpForce = 100;

    public override void Enter()
    {
        base.Enter();
        player.body.velocity += new Vector2(0, jumpForce);
    }

    public override void PhysicsProcess()
    {
        base.PhysicsProcess();

        if (!player.isGrounded)
        {
            stateMachine.ChangeState<Air>();
        }
    }
}
