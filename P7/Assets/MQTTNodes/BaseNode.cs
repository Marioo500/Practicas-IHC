using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;
using uPLibrary.Networking.M2Mqtt.Utility;
using uPLibrary.Networking.M2Mqtt.Exceptions;

public class BaseNode : MonoBehaviour
{
    public string brokerHostName = "test.mosquitto.org";
    public int brokerPort = 1883;
    public List<string> subscribers = new List<string>();
    protected MqttClient client;
    protected string lastMessage;
    
	protected virtual void Start ()
     {
		// create client instance 
		client = new MqttClient(brokerHostName, brokerPort, false, null); 
		
		// register to message received 
		client.MqttMsgPublishReceived += ClientMqttMsgPublishReceived; 
		string clientId = Guid.NewGuid().ToString(); 
		client.Connect(clientId); 

		// subscribe to the topic  with QoS 2 
        if(subscribers.Count>0)
        {
            byte[] qosArray = new byte[subscribers.Count];
            for (int i = 0; i < qosArray.Length; i++)
            {
                qosArray[i] = MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE;
            }
		    client.Subscribe(subscribers.ToArray(), qosArray);
        }
	}

    protected virtual void ClientMqttMsgPublishReceived(object sender, MqttMsgPublishEventArgs e) 
	{ 
		Debug.Log("Received: " + System.Text.Encoding.UTF8.GetString(e.Message));
		lastMessage = System.Text.Encoding.UTF8.GetString(e.Message);
	}

    protected virtual void PublishMessage(string topic, string message)
    {
        Debug.Log($"Mandando Mensaje desde Nodo {gameObject.name} al topic {topic}");
        client.Publish(topic, System.Text.Encoding.UTF8.GetBytes(message), MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE,true);
    }

    void OnApplicationQuit()
	{
		client.Disconnect();
	}
}
