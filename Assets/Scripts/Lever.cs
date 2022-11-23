using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour, IInteractable
{
    [SerializeField] private string prompt;

    public RotateRoom rotateRoomScript;

    public string InteractionPromp => prompt;

    public bool Interact(Interactor interactor)
    {
        rotateRoomScript.RotateAround();
        return true;
    }

    private void Start()
    {
        
    }
}
