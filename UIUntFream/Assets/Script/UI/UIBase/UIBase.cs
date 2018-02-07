﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using Object = UnityEngine.Object;

public class UIBase<T> : MonoBehaviour, IUIBase where T : UIRef 
{
    protected Transform m_uiTrans;          //> 界面根节点的transform
    private UIRef m_component = null;
    public T Ref { get { return (T)m_component; } }
    private void SetRef(UIRef mono) { m_component = mono; }

    public AppInfo appInfo;

    public void setAppInfo(AppInfo aInfo)
    {
        appInfo = aInfo;
    }


    //----------------------------------------------------IUIBase---------------------------------------------
    public void setAssetObject(GameObject obj)
    {
        if (obj != null)
        {
            m_uiTrans = Object.Instantiate(obj).transform;
            m_uiTrans.gameObject.name = appInfo.appName;
            m_uiTrans.parent = UIManager.ins.UIRootTransform;
            m_uiTrans.localPosition = new Vector3(0, 0, 0);
            m_uiTrans.localRotation = Quaternion.identity;
            m_uiTrans.localScale = Vector3.one;

            UIRef uiRef = m_uiTrans.GetComponent<UIRef>();
            SetRef(uiRef);
        }
    }


    public virtual void initView()
    {


    }


    public virtual void setup()
    {
        

    }

    public void show(object obj = null, string openTable = "")
    {
        
    }

    public virtual void refresh()
    {
        
    }

    public virtual void addEvent()
    {
        

    }

    public virtual void removeEvent()
    {
        
    }

    public virtual void hide()
    {
        
    }

    public virtual void dispose()
    {
        if (m_uiTrans != null)
        {
            removeEvent();
            Destroy(m_uiTrans.gameObject);
            m_uiTrans = null;
        }
        
    }


}
