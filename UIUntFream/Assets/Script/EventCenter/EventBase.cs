using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventBase {

    public object sender { get; private set; }

    public float timeStamp { get; private set; }

    public EventBase(object sender)
    {
        this.sender = sender;
        timeStamp = Time.time;
    }
}


public class StringArgEvent : EventBase
{
    public string stringArg { get; set; }

    public StringArgEvent(object sender, string arg)
        : base(sender)
    {
        stringArg = arg;
    }
}

public class IntArgEvent : EventBase
{
    public int intArg { get; set; }

    public IntArgEvent(object sender, int arg)
        : base(sender)
    {
        intArg = arg;
    }
}