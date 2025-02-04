using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "States/Base State")]
public class BaseState : ScriptableObject
{
    [HideInInspector]
    public BaseStateMachine stateMachine;

    public virtual void Enter() {}

    public virtual void Exit() {}

    public virtual void Process() {}

    public virtual void PhysicsProcess() {}
}
