using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    protected bool isInsideZone;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isInsideZone && Input.GetKeyDown(KeyCode.I))
        {
            Interact();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(!other.CompareTag("Player")) return; 
        Debug.Log("Collision dentro" + other.name); 
        isInsideZone = true;
    }

    void OnTriggerExit(Collider other)
    {
        if(!other.CompareTag("Player")) return; 
        Debug.Log("Saliendo de la colision " + other.name); 
        isInsideZone = false;
    }

    protected virtual void Interact()
    {
        Debug.Log("Haciendo algo ");
    }
}
