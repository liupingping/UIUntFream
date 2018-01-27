using System;
using UnityEngine;
using Object = UnityEngine.Object;

public class AssetLoadAgent
{
    public virtual void Release()
    {
    }

    public virtual void AddRef()
    {

    }
    public virtual void SubRef()
    {

    }

    public virtual void FireLoadCompletedEvent()
    {
        if (callback != null)
        {
            try
            {
                callback(this);
            }
            catch (Exception e)
            {
                Debug.LogErrorFormat("message:{0},asset:{1}", e.Message, Path);
                throw;
            }
        }
    }

    protected AssetHandler.LoadCallbackFunc callback;

    protected Object assetObject = null;

    protected object userdata = null;

    public object UserData
    {
        get { return userdata; }
    }

    public virtual Object AssetObject
    {
        get { return assetObject; }
    }

    public virtual bool IsDone { get { return false; } }

    public virtual string Path { get { return ""; } }

    public virtual byte[] Bytes
    {
        get
        {
            if (AssetObject == null)
            {
                return null;
            }

            TextAsset go = AssetObject as TextAsset;
            return go.bytes;
        }
    }

    public virtual string Text
    {
        get
        {
            if (AssetObject == null)
            {
                return null;
            }

            TextAsset go = AssetObject as TextAsset;
            return go.text;
        }
    }


    public virtual UIAtlas Atlas
    {
        get
        {
            if (AssetObject == null)
            {
                return null;
            }

            UIAtlas go = ((GameObject)AssetObject).GetComponent<UIAtlas>();
            return go;
        }
    }
}
