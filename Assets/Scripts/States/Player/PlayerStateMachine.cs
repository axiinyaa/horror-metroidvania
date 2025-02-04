using System.Collections.Generic;
using UnityEngine;
public class PlayerStateMachine : BaseStateMachine
{
    [HideInInspector]
    public Player player;

    void Start()
    {
        player = GetComponent<Player>();
        InitStates();
    }
}