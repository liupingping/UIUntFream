using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventCenter  {

    public class EventListener
    {
        public EventListener(FuncCallback _funcCB)
        {
            funcCB = _funcCB;
        }

        public FuncCallback funcCB;
    }

    public delegate void FuncCallback(object data);
    private Dictionary<GlobalEventType, List<EventListener>> listenerMap = new Dictionary<GlobalEventType, List<EventListener>>();

    private readonly Dictionary<Type, object> typeBaseEvnents = new Dictionary<Type, object>();
    private readonly List<Type> eventInCalling = new List<Type>();

    private TypeEventBus typeEventBus = new TypeEventBus();

    //>-----------------------------------------------------------------------------

    public void Release()
    {
        RemoveAllListeners();
        UnsubscribeAndClearAllEvents();
    }

    //>-----------------------------------------------------------------------------

    /// <summary>
    /// 订阅一个事件
    /// </summary>
    /// <typeparam name="T">事件类型</typeparam>
    /// <param name="eventAction">事件回调</param>
    /// <param name="insertAsFirst">是否插入到事件队列最前端</param>
    public void Subscribe<T>(Func<T, bool> eventAction, bool insertAsFirst = false)
        where T : EventBase
    {
        typeEventBus.Subscribe<T>(eventAction, insertAsFirst);
    }

    //>-----------------------------------------------------------------------------


    /// <summary>
    /// 取消事件订阅
    /// </summary>
    /// <typeparam name="T">事件类型</typeparam>
    /// <param name="eventAction">事件回调</param>
    /// <param name="keepEvent">回调数量为空时是否在管理容器中删除时间本身</param>
    public void Unsubscribe<T>(Func<T, bool> eventAction, bool keepEvent = false)
        where T : EventBase
    {
        typeEventBus.Unsubscribe<T>(eventAction, keepEvent);
    }

    //>-----------------------------------------------------------------------------

    /// <summary>
    /// 清除一个事件的所有订阅函数
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="keepEvent"></param>
    public void UnsubscribeAll<T>(bool keepEvent = false)
        where T : EventBase
    {
        typeEventBus.UnsubscribeAll<T>(keepEvent);
    }

    //>-----------------------------------------------------------------------------

    /// <summary>
    /// 清空所有事件回调函数
    /// </summary>
    public void UnsubscribeAndClearAllEvents()
    {
        typeEventBus.UnsubscribeAndClearAllEvents();
    }

    //>-----------------------------------------------------------------------------

    /// <summary>
    /// 触发事件
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="eventMessage"></param>
    public void Publish<T>(T eventMessage)
        where T : EventBase
    {
        typeEventBus.Publish<T>(eventMessage);
    }

    //>-----------------------------------------------------------------------------

    //> 监听消息
    public void AddListener(GlobalEventType eType, FuncCallback funcCB, bool insertFirst = false)
    {
        if (GlobalEventType.None == eType)
            return;

       // ProfilerSample.BeginSample("AddListener");
        EventListener newListener = new EventListener(funcCB);
        List<EventListener> listenerList;
        if (listenerMap.TryGetValue(eType, out listenerList))
        {
            if (null != listenerList.Find(x => x.funcCB == funcCB))
            {
                Debug.LogError("Already Contains Event:" + eType + ", Function:" + funcCB);
                return;
            }
            if (insertFirst)
                listenerList.Insert(0, newListener);
            else
                listenerList.Add(newListener);
        }
        else
        {
            listenerList = new List<EventListener>() { newListener };
            listenerMap.Add(eType, listenerList);
        }
        //ProfilerSample.EndSample();
    }

    //>-----------------------------------------------------------------------------

    //> 移除监听
    public void RemoveListener(GlobalEventType eType, FuncCallback funcCB)
    {
        //ProfilerSample.BeginSample("RemoveListener");
        List<EventListener> listenerList = null;
        if (!listenerMap.TryGetValue(eType, out listenerList))
        {
            //ProfilerSample.EndSample();
            return;
        }

        int idx = listenerList.FindIndex(x => x.funcCB == funcCB);
        if (idx >= 0)
        {
            EventListener listener = listenerList[idx];
            if (null != listener) listenerList.RemoveAt(idx);
            if (listenerList.Count <= 0) listenerMap.Remove(eType);
        }
        //ProfilerSample.EndSample();
    }

    //>-----------------------------------------------------------------------------

    //> 移除所有事件
    public void RemoveAllListeners()
    {
        listenerMap.Clear();
    }

    //>-----------------------------------------------------------------------------

    //> 派发消息（常规用法）
    public void Dispatch(GlobalEventType eType, object data)
    {
        //1. 尝试使用TryGetValue，字典只会遍历一次
        //2. 防止dispatch时候remove掉元素报错，可以从后往前遍历，所以监听方法的优先级要反过来排
        List<EventListener> funcList;
        if (listenerMap.TryGetValue(eType, out funcList))
        {
            int count = funcList.Count;
            for (int i = count - 1; i >= 0; i--)
            {
                //ProfilerSample.BeginSample(funcList[i].funcCB.Method.Name);
                funcList[i].funcCB(data);
                //ProfilerSample.EndSample();
            }
        }
    }

    //>-----------------------------------------------------------------------------

    //> 派发消息（常规用法）
    public void Dispatch(GlobalEventType eType, params object[] data)
    {
        //1. 尝试使用TryGetValue，字典只会遍历一次
        //2. 防止dispatch时候remove掉元素报错，可以从后往前遍历，所以监听方法的优先级要反过来排
        List<EventListener> funcList;
        if (listenerMap.TryGetValue(eType, out funcList))
        {
            int count = funcList.Count;
            for (int i = count - 1; i >= 0; i--)
            {
                //ProfilerSample.BeginSample(funcList[i].funcCB.Method.Name);
                funcList[i].funcCB(data);
                //ProfilerSample.EndSample();
            }
        }
    }

}
