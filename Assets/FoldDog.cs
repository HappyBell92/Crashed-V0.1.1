using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoldDog : MonoBehaviour

{
    public Animator foldDog;


    // Start is called before the first frame update
    void Start()
    {
        
    }
private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Player"))
            foldDog.SetBool("DogTrigger 0", true);
            Debug.Log("Yee");
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
