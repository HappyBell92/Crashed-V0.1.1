using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverGravDown : MonoBehaviour, IInteractable
{
    [SerializeField] private string prompt;

    public GravityBehaviour gravityBehaviourScript;

    public string InteractionPromp => prompt;

    public bool Interact(Interactor interactor)
    {
        gravityBehaviourScript.GravityDown();
        return true;
    }

    private void Update()
    {
        
    }
}
