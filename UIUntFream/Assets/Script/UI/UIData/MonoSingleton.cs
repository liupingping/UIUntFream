using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**********************************************************************************
*-> 创建一个以T.name为名字的GameObject，并且挂在GameMain节点上的MonoBehaviour单例. <-*
***********************************************************************************/
public abstract class MonoSingleton<T> : MonoBehaviour where T : Component
{
    protected static AssetLoadAgent agent = null;
    protected static T s_instance = null;
    public static T ins
    {
        get
        {
            if (s_instance == null)
                CreateSingleton();
            return s_instance;
        }
    }

    public static T GetInstance(string parentFolderPath, string resourceName)
    {
        if (s_instance == null)
            CreateSingleton(parentFolderPath, resourceName);
        return s_instance;
    }

    private const string GAME_MAIN = "GameMain";

    public static bool HasInstance { get { return (s_instance != null); } }

    private static Transform GetRootTrans()
    {
        GameObject root = GameObject.FindGameObjectWithTag(GAME_MAIN);
        if (root == null)
        {
            /*Debug.LogError("Please Select Scene:'GreatWall' First.");
            return null;*/
            root = new GameObject(GAME_MAIN);
            root.tag = GAME_MAIN;
            DontDestroyOnLoad(root);
        }
        return root.transform;
    }

    protected static void CreateSingleton()
    {
        GameObject singleton = new GameObject(typeof(T).Name);
        singleton.transform.parent = GetRootTrans();
        s_instance = singleton.AddComponent<T>();
    }

    protected static void CreateSingleton(string parentFolderPath, string resourceName)
    {
        agent = ResourceMgr.LoadAssetFromeAssetsFolderFirst(parentFolderPath, resourceName, "prefab",
            typeof(GameObject), a =>
            {
                Debug.LogFormat("load monosingle prefab ,prefab name:{0}", resourceName);

                var prefab = (GameObject)a.AssetObject;

                if (prefab == null)
                {
                    CreateSingleton();
                    return;
                }
                var trans = CreatePrefab(prefab, typeof(T).Name, GetRootTrans());
                s_instance = trans.gameObject.GetComponent<T>() ?? trans.gameObject.AddComponent<T>();

                //agent.Release();
            });
    }

    private Transform m_cachedTrans;
    public Transform CachedTrans
    {
        get
        {
            if (m_cachedTrans == null)
                m_cachedTrans = transform;
            return m_cachedTrans;
        }
    }

    private void Awake()
    {
        if (s_instance != null)
        {
            if (this != s_instance)
                Destroy(this.gameObject);
            return;
        }
        s_instance = this as T;
        if (CachedTrans.root.tag != GAME_MAIN)
        {
            CachedTrans.parent = GetRootTrans();
            gameObject.name = typeof(T).Name;
        }
        OnAwake();
    }

    private void Destory()
    {
        if (agent != null)
        {
            agent.Release();
        }

        OnDestory();
    }

    protected virtual void OnAwake()
    {
    }

    protected virtual void OnDestory()
    {

    }

    protected static Transform CreatePrefab(GameObject go, string objectName, Transform parentTrans)
    {
        GameObject newGO = Object.Instantiate(go) as GameObject;
        newGO.name = objectName;
        if (parentTrans != null)
        {
            NGUITools.SetLayer(newGO, parentTrans.gameObject.layer);
        }
        Transform t = newGO.transform;
        t.parent = parentTrans;
        t.localPosition = Vector3.zero;
        t.localRotation = Quaternion.identity;
        t.localScale = Vector3.one;
        return t;
    }
}