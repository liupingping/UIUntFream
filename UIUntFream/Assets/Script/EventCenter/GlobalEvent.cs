using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalEvent : EventCenter
{

    private GlobalEvent() { }
    private static GlobalEvent m_instance = null;
    public static GlobalEvent Instance
    {
        get
        {
            if (null == m_instance)
                m_instance = new GlobalEvent();
            return m_instance;
        }
    }

}
