using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using TMPro;

public class TemperatureSensorNode : BaseNode
{
    public string temperatureTopic = "casa/sala/sensor/prueba";    
    public float publishRate = 10;
    private float publishTimer = 0;
    public float temperature = 19;

    public Button b1;
    public TMP_Text b1text;
    
    protected override void Start()
    {
        base.Start();
        //iniciar sensor;
        PublishMessage(temperatureTopic, temperature.ToString());
        b1text = b1.GetComponentInChildren<TextMeshProUGUI>();
        b1text.text = temperature.ToString();
    }

    protected override void PublishMessage(string topic, string message)
    {
        base.PublishMessage(topic, message);
        // Algo mas depues despues este nodo
    }
    
    // Update is called once per frame
    void Update()
    {
        if((publishTimer += Time.deltaTime) >= publishRate)
        {
            temperature += 1f;
            PublishMessage(temperatureTopic, temperature.ToString());
            b1text.text = temperature.ToString();
            publishTimer = 0;
        }

    }
}
