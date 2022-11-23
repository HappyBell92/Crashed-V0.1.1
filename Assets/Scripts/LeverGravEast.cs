using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverGravEast : MonoBehaviour, IInteractable
{
    [SerializeField] private string prompt;

    public GravityBehaviour gravityBehaviourScript;

    public string InteractionPromp => prompt;

    public bool Interact(Interactor interactor)
    {
        gravityBehaviourScript.GravityEast();
        return true;
    }

    private void Update()
    {

    }
}
