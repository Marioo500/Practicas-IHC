using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Capsule : Interactable
{
    private Rigidbody rb;
    public Vector3 direction;
    public Material material;
    private Renderer rend;
    public AudioSource audiosource;
    public AudioClip clip;

    public float kickforce = 10f;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rend = GetComponent<Renderer>();
        rend.enabled = true;
    }

    protected override void Interact()
    {
        base.Interact();
        rb.AddForce(direction);
        rend.sharedMaterial = material;
        audiosource.PlayOneShot(clip);
    }
}
