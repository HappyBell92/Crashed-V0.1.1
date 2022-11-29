using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverGrav : MonoBehaviour, IInteractable
{
    [SerializeField] private string prompt;
    [SerializeField] string GravityCardinalDirection;

    public GravityBehaviour gravityBehaviourScript;

    public string InteractionPromp => prompt;

    public bool Interact(Interactor interactor)
    {
        gravityBehaviourScript.SwitchGravity(GravityCardinalDirection);
        return true;
    }

    private void Update()
    {

    }
}
