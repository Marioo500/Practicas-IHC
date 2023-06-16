using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using uPLibrary.Networking.M2Mqtt.Messages;

public class ACActuadorNode : BaseNode
{
    public float temperatureThresholdHigh = 26;
    public float temperatureThresholdLow = 20;
    private float temperature;
    public Light lightComponent;


    protected override void ClientMqttMsgPublishReceived(object sender, MqttMsgPublishEventArgs e)
    {
        base.ClientMqttMsgPublishReceived(sender, e);
    }


    private void Update()
    {
        if(string.IsNullOrEmpty(lastMessage))
        {
            return;
        }
        temperature = float.Parse(lastMessage);
        if (temperature >= temperatureThresholdHigh)
        {
            //Prender ventilador
            Debug.Log("Prender ventilador");
            lightComponent.enabled = true;
        }
        else if(temperature <= temperatureThresholdLow)
        {
            //apagar ventilador 
            Debug.Log("Apagar Ventilador");
            lightComponent.enabled = false;
            
        }
    }
}
