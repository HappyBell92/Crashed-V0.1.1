using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverGravWest : MonoBehaviour, IInteractable
{
    [SerializeField] private string prompt;

    public GravityBehaviour gravityBehaviourScript;

    public string InteractionPromp => prompt;

    public bool Interact(Interactor interactor)
    {
        gravityBehaviourScript.GravityWest();
        return true;
    }

    private void Update()
    {

    }
}
