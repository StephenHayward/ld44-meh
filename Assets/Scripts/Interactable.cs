using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(ProximityChecker))]
public class Interactable : MonoBehaviour
{
    [SerializeField] KeyCode interactKey = KeyCode.E;

    [SerializeField] UnityEvent onInteract;

    bool canInteract = false;

    private void Awake()
    {
        var proxChecker = GetComponent<ProximityChecker>();
        proxChecker.onProximityEnter.AddListener(() => canInteract = true);
        proxChecker.onProximityExit.AddListener(() => canInteract = false);
    }

    private void Update()
    {
        if(canInteract && Input.GetKeyDown(interactKey) && onInteract != null)
        {
            onInteract.Invoke();
        }
    }
}
