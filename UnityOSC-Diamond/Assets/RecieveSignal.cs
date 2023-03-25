using UnityEngine;
using System.Collections;
using System;

public class RecieveSignal : MonoBehaviour
{

    public OSC osc;


    // Use this for initialization
    void Start()
    {
        osc.SetAddressHandler("/Signal", OnReceiveSignal);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnReceiveSignal(OscMessage message)
    {
        String soundData = message.ToString();
    }

}
