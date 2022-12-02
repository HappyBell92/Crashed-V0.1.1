using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverGrav : MonoBehaviour, IInteractable
{
    [SerializeField] private string prompt;
    [SerializeField] string GravityCardinalDirection;

    public GravityBehaviour gravityBehaviourScript;

    AudioSource rotateSound;

    public string InteractionPromp => prompt;

    public bool Interact(Interactor interactor)
    {
        //gravityBehaviourScript.SwitchGravity(GravityCardinalDirection);
        StartCoroutine(Lever());
        return true;
    }

    void Start()
    {
        rotateSound= GetComponent<AudioSource>();
    }

    private void Update()
    {

    }

    IEnumerator Lever()
    {
        rotateSound.Play();
        yield return new WaitForSeconds(3);
        gravityBehaviourScript.SwitchGravity(GravityCardinalDirection);
    }

    void LeverScript()
    {
        gravityBehaviourScript.SwitchGravity(GravityCardinalDirection);
        //return true;
    }
}
