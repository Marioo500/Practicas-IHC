using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : Interactable
{
    private Material m;
    public string CambiarColor = "cambia de color";
    // Start is called before the first frame update
    private void Awake()
    {
        m = GetComponent<Renderer>().material;
    }
    void Start()
    {
        VoiceCommandManager.Instance.RegisterCommand(CambiarColor, Interact);
    }

    protected override void Interact()
    {
        base.Interact();
        float r = Random.Range(0f, 1f);
        float g = Random.Range(0f, 1f);
        float b = Random.Range(0f, 1f);
        m.color = new Color(r,g,b,1f); 
    }
}
