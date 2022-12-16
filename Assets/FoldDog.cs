using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoldDog : MonoBehaviour, IInteractable

{
    [SerializeField] private string prompt;
    public string InteractionPromp => prompt;
    public Animator foldDog;

    public bool Interact(Interactor interactor)
    {
        Debug.Log("Yee");
        FooldDog();
        return true;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FooldDog()
    {
        foldDog.SetBool("Interact", true);
    }
}
