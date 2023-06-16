using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Talk : Interactable
{
    public AudioSource source;
    public AudioClip clip;
    // Start is called before the first frame update

    protected override void Interact()
    {
        base.Interact();
        source.PlayOneShot(clip);
    }

}
