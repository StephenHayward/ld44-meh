using UnityEngine;

internal class BasicAIBehaviour : AIBehaviour
{
    [SerializeField] IdleAI idleState;

    private void Start()
    {
        base.states.Add("Idle", idleState);

        base.ChangeState("Idle");
    }
}