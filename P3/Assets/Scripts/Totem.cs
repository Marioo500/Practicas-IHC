using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Totem : Interactable
{
    public Material[] material;
    private Renderer rend;
     private int x;
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        rend.sharedMaterial = material[0];
        x = 0;
    }

    // Update is called once per frame
    protected override void Interact()
    {
        base.Interact();
       if(x < 3)
       {
           x++;
       }
       else
       {
           x = 0;
       }

       rend.sharedMaterial = material[x];
    }
}
