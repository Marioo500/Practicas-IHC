using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Talk : Interactable
{
    public string turnOnCommand = "comienza a hablar";
    public string turnOffCommand = "para de hablar";
    public AudioSource source;
    public AudioClip sonido;

    // Start is called before the first frame update

    private void Awake()
    {
        source.clip = sonido;
    }

    void Start()
    {
        Interact();
        VoiceCommandManager.Instance.RegisterCommand(turnOnCommand, EmpezarAHablar);
        VoiceCommandManager.Instance.RegisterCommand(turnOffCommand, PararDeHablar);
    }

    protected override void Interact()
    {
        base.Interact();
    }

    private void EmpezarAHablar()
    {
        source.Play();
    }

    private void PararDeHablar()
    {
        source.Stop();
    }
}
