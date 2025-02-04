using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePlayerState : BaseState
{
    [HideInInspector]
    public Player player;

    public override void Enter()
    {
        player = stateMachine.GetComponent<Player>();
    }
}
