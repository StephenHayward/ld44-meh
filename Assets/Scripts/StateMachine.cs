using System.Collections.Generic;
using UnityEngine;

class StateMachine : MonoBehaviour
{
    protected Dictionary<string, State> states = new Dictionary<string, State>();

    string currentState;

    protected Actor owner;

    private void Awake()
    {
        Initialized(GetComponent<Actor>());    
    }

    public void Initialized(Actor owner)
    {
        this.owner = owner;
    }

    public void ChangeState(string newState)
    {
        if(!string.IsNullOrEmpty(currentState))
        {
            states[currentState].OnExitState(owner);
        }

        currentState = newState;

        states[currentState].OnEnterState(owner);
    }

    public void Update()
    {
        if (!string.IsNullOrEmpty(currentState))
        {
            states[currentState].UpdateState(owner);
        }
    }
}

public abstract class State : ScriptableObject
{
    public abstract void OnEnterState(Actor owner);

    public abstract void OnExitState(Actor owner);

    public abstract void UpdateState(Actor owner);
}