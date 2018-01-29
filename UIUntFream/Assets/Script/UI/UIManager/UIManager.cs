using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class UIManager : MonoSingleton<UIManager>
{
    public Transform UIRootTransform { get; private set; }
    private const string UI_STAGE = "UIStage"; //> 主界面

    private AssetLoadAgent uiRootloadAgent = null; // uiroot的加载代理


    public IEnumerator InitUI()
    {

        uiRootloadAgent = ResourceMgr.LoadAssetFromeAssetsFolderFirst(ResourcesPath.UIPrefabPath,
                                                 (string)UI_STAGE, "prefab", typeof(UnityEngine.Object), null);

        while (!uiRootloadAgent.IsDone)
        {
            yield return null;
        }

        if (uiRootloadAgent.AssetObject == null)
        {
            Debug.LogError("Load UI Root Faild!");
            yield break;
        }

        Transform stageTrans = ((GameObject)Instantiate(uiRootloadAgent.AssetObject)).transform;
        stageTrans.gameObject.name = UI_STAGE;
        stageTrans.parent = CachedTrans;

        //> 创建界面面板
        UIRootTransform = new GameObject("UIContainers").transform;
        //> 设置在主界面下
        UIRootTransform.parent = stageTrans;
        UIRootTransform.localScale = Vector3.one;
        UIRootTransform.gameObject.layer = stageTrans.gameObject.layer;
        //> Z坐标不要放太远，会影响3D模型动作计算，导致模型抖动
        transform.position = new Vector3(0, 100, 0);


           

    }


}