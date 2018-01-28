using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using Object = UnityEngine.Object;

public class UIBase<T> : MonoBehaviour where T : UIRef 
{
    protected List<IEnumerator> loadCoroutines = new List<IEnumerator>();
    protected AssetLoadAgent prefabAssetLoadAgent; // 界面预设的资源
    protected Transform m_uiTrans;          //> 界面根节点的transform

    private UIRef m_component = null;
    public T Ref { get { return (T)m_component; } }

    private void SetRef(UIRef mono) { m_component = mono; }

    /// <summary>
    /// prefab所在文件夹名称
    /// </summary>
    public virtual string FolderName{ 
        get { return ""; }
    }

    public virtual string ResouceName {
        get { return ""; }
    }

    public void show(Action onAsyncFinish)
    {
        loaderAsset(onAsyncFinish);
    }

    public void loaderAsset(Action onAsyncFinish)
    {
        IEnumerator enumerator = _AssembleUIPrefab(onAsyncFinish);
        loadCoroutines.Add(enumerator);
        CoroutineHelper.ins.StartTrackedCoroutine(enumerator);
    }
   

    /// <summary>
    /// >组装界面prefab
    /// </summary>
    /// <returns></returns>
    private IEnumerator _AssembleUIPrefab(Action onAsyncFinish)
    {
        string resname = FolderName + "/" + ResouceName;
        prefabAssetLoadAgent = ResourceMgr.LoadAssetFromeAssetsFolderFirst(ResourcesPath.UIPrefabPath, resname, "prefab",
                                                typeof(UnityEngine.Object), null);

        while (!prefabAssetLoadAgent.IsDone)
        {
            yield return null;
        }

        if (prefabAssetLoadAgent.AssetObject == null)
        {
            Debug.LogError("Load UI Root Faild!");
            yield break;
        }


        GameObject obj = (GameObject)prefabAssetLoadAgent.AssetObject;
        m_uiTrans = Object.Instantiate(obj).transform;

        //> 新界面放置到主界面下面
        m_uiTrans.gameObject.name = ResouceName;
        m_uiTrans.parent = UIManager.ins.UIRootTransform;
        m_uiTrans.localPosition = new Vector3(0, 0, 0);
        m_uiTrans.localRotation = Quaternion.identity;
        m_uiTrans.localScale = Vector3.one;

        UIRef uiRef = m_uiTrans.GetComponent<UIRef>();
        SetRef(uiRef);

        if (onAsyncFinish != null)
        {
            onAsyncFinish();
        }
    }

    public virtual void onHide()
    {

    }


    /// <summary>
    /// >卸载界面
    /// </summary>
    public virtual void Unload()
    {
        onHide();
        if (prefabAssetLoadAgent != null)
        {
            prefabAssetLoadAgent.Release();
        }

        Destroy(this.gameObject.transform);
        m_uiTrans = null;
    }

    private void onCloseBtn(GameObject obj)
    {
        Unload();
    }


    public virtual void addEvent()
    {
        if (Ref.closeBtn != null)
        {
            UIEventListener.Get(Ref.closeBtn.gameObject).onClick = onCloseBtn;
        }

    }

    public virtual void removeEvent()
    {
        if (Ref.closeBtn != null)
        {
            
        }
    }


}
