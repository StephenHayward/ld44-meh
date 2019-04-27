using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ProximityChecker : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] public UnityEvent onProximityEnter, onProximityExit;
    [SerializeField] float proximity = 3f;

    bool isInProximity = false;

    private void Update()
    {
        float distSqr = (target.position - transform.position).sqrMagnitude;

        if (!isInProximity && distSqr < Mathf.Pow(proximity, 2))
        {
            isInProximity = true;
            onProximityEnter.Invoke();
        }
        else if(isInProximity && distSqr > Mathf.Pow(proximity, 2))
        {
            isInProximity = false;
            onProximityExit.Invoke();
        }
    }
}
