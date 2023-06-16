using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : Interactable
{
    private Material material;
    void Start()
    {
        material = GetComponent<Renderer>().material;
    }
    
    protected override void Interact()
    {
        base.Interact();
        float r = Random.Range(0f, 1f);
        float g = Random.Range(0f, 1f);
        float b = Random.Range(0f, 1f);
        material.color = new Color(r,g,b,1f);

    }
}
