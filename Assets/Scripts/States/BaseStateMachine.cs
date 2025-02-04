using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseStateMachine : MonoBehaviour
{
    [Header("States")]
    public BaseState[] states;
    private Dictionary<string, BaseState> stateDictionary = new Dictionary<string, BaseState>();
    public BaseState currentState;

    void Start()
    {
        InitStates();
    }

    // Initializes the states and adds them to the dictionary
    public virtual void InitStates()
    {
        foreach (BaseState state in states)
        {
            state.stateMachine = this;
            stateDictionary.Add(state.GetType().Name, state);
        }

        currentState.Enter();
    }

    // Changes the current state to the state of type T
    public virtual void ChangeState<T>() where T : BasePlayerState
    {
        currentState.Exit();
        currentState = stateDictionary[typeof(T).Name];
        currentState.Enter();
    }

    void FixedUpdate()
    {
        currentState.PhysicsProcess();
    }

    void Update()
    {
        currentState.Process();
    }
}
