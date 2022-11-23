using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverGravNorth : MonoBehaviour, IInteractable
{
    [SerializeField] private string prompt;

    public GravityBehaviour gravityBehaviourScript;

    public string InteractionPromp => prompt;

    public bool Interact(Interactor interactor)
    {
        gravityBehaviourScript.GravityNorth();
        return true;
    }

    private void Update()
    {

    }
}
