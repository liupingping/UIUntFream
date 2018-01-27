using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditorAssetLoadAgent : AssetLoadAgent
{
    public void Init(Object obj, AssetHandler.LoadCallbackFunc callbackFunc, object userdata = null)
    {
        this.callback = callbackFunc;
        this.userdata = userdata;
        assetObject = obj;
        isDone = true;

        CoroutineHelper.ins.StartCoroutine(WaitResourcesLoadComplete());
    }

    public virtual void Release()
    {
        assetObject = null;
    }

    IEnumerator WaitResourcesLoadComplete()
    {
        isDone = true;
        FireLoadCompletedEvent();
        yield break;
    }

    private bool isDone = false;

    public override bool IsDone
    {
        get { return isDone; }
    }
}
