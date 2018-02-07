using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class UICanvase<T> :IUICanvase where T : MonoBehaviour
{

    private object _component = null;
    protected T Ref { get { return (T)_component; } }


    /// <summary>
    /// 添加 UI 给 _component (必须要给一个UI 不然没法初始化数据)
    /// </summary>
    /// <param name="ob"></param>
    public virtual void setup(object ob)
    {
        string className = typeof (T).Name;
        if ( !( className.StartsWith("EX_UI_") && className.EndsWith("Canaves") ) )
        {
            Debug.LogError("Class Name Error! Should Be [ EX_UI_ " + className + " Canaves ]");
        }
        _component = ob;
    }

    public virtual void initView()
    {

        
    }

    public virtual void setActive(bool isActive)
    {
        Ref.gameObject.SetActive(isActive);
    }

    public virtual void destory()
    {
        if (Ref.gameObject != null)
        {
            GameObject.Destroy(Ref.gameObject);
            _component = null;
        }
    }


}