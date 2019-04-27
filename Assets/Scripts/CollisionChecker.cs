using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CollisionChecker : MonoBehaviour
{
    [SerializeField] LayerMask testerMask;

    public bool IsColliding { get; private set; }
    public OnCollidingUpdated onCollidingUpdated;

    public List<Collider2D> colliders = new List<Collider2D>();
    Collider2D collider;

    private void Awake()
    {
        collider = GetComponent<Collider2D>();
        onCollidingUpdated = onCollidingUpdated ?? new OnCollidingUpdated();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (testerMask == (testerMask | (1 << collision.gameObject.layer)))
        {
            IsColliding = true;
            colliders.Add(collision);

            if(colliders.Count == 1)
            {
                onCollidingUpdated.Invoke(true);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (testerMask == (testerMask | (1 << collision.gameObject.layer)))
        {
            colliders.Remove(collision);

            if(colliders.Count <= 0)
            {
                IsColliding = false;
                onCollidingUpdated.Invoke(false);
            }
        }
    }
}

public class OnCollidingUpdated : UnityEvent<bool>
{
}
