using System;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    IState currentState;
    Dictionary<Type, IState> states = new Dictionary<Type, IState>();
    void Update()
    {
        currentState?.LogicUpdate();
    }
    void FixedUpdate()
    {
        currentState?.PhysicsUpdate();
    }

    public void AddState(IState state)
    {
        if (!states.ContainsKey(state.GetType())) states.Add(state.GetType(), state);
        
    }

    public void ChangeState<T>() where T : IState
    {
        if (!states.ContainsKey(typeof(T))) { Debug.Log(gameObject.name + " Does Not Contain " + typeof(T).ToString()); return; }
        ChangeState(states[typeof(T)]);
    }
    
    public void ChangeState(IState nextState)
    {
        if (currentState != null && currentState.GetType() == nextState.GetType()) return;
        currentState?.Exit();
        currentState = nextState;
        currentState?.Enter();
    }
}
