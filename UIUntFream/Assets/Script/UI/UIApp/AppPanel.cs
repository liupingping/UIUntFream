using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = System.Object;

public class AppPanel 
{
        private AppInfo _appInfo;
	    private string _appName;
	    private Object _data;
	    private string _openTable;
        public bool isAppShowIng = false;

        private IUIBase _IUIBase;//面板；

        /**
		 * app资源是否已经在加载中 
		 */		
		private bool _isLoading = false;
        protected AssetLoadAgent prefabAssetLoadAgent; // 界面预设的资源
        protected List<IEnumerator> loadCoroutines = new List<IEnumerator>();
       

        public  AppPanel(AppInfo appInfoP)
	    {
		    _appInfo = appInfoP;
		    _appName = _appInfo.appName; 
	    }

        public void init(Object data,string openTable)
	    {
		    _data = data;
            _openTable = openTable;
	    }

        public void setup()
        {
            isAppShowIng = true;
            IEnumerator enumerator = starLoaderResouce();
            loadCoroutines.Add(enumerator);
            CoroutineHelper.ins.StartTrackedCoroutine(enumerator);
        }

        private IEnumerator starLoaderResouce()
        {
            string resname = _appInfo.folderName != "" ? _appInfo.folderName + "/" + _appInfo.appName : _appInfo.appName;
            prefabAssetLoadAgent = ResourceMgr.LoadAssetFromeAssetsFolderFirst(ResourcesPath.UIPrefabPath, resname, "prefab", typeof(UnityEngine.Object), null);
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
            isLoaderComplete(obj);
        }


        private void isLoaderComplete(GameObject assetObj)
        {
            if (assetObj != null)
            {
                if (_IUIBase == null)
                {
                    _IUIBase = UICreatPanelInstance.ins.getUIPanelInstance(_appInfo.appName);
                }

                _IUIBase.setAssetObject(assetObj);
                show();
            }
        }


        private void show()
        {
            isAppShowIng = true;
            if (_IUIBase != null)
            {
                _IUIBase.addEvent();
                _IUIBase.show(_data,_openTable);
                _IUIBase.refresh();
            }
        }

        public void hide()
        {
//            isAppShowIng = false;
//            if (_app)
//            {
//                _app.superRemoveEvent();
//                _app.removeEvent();
//                if (_app is IAutoRes)
//                {
//                    IAutoRes(_app).autoDispose();
//                }
//                if (!ClientConfig.isRelease)
//                {
//                    TweenLite.delayedCall(0.3, checkEvent);
//                }
//                _app.hide();
//                AppDispather.instance.dispatchEvent(new AppEvent(AppEvent.APP_HIDE, appInfo));
//            }

            isAppShowIng = false;
            if (_IUIBase != null)
            {
                _IUIBase.removeEvent();
                _IUIBase.hide();
            }

            if (prefabAssetLoadAgent != null)
            {
                prefabAssetLoadAgent.Release();
            }

        }

        public void dispose()
        {
            hide();
            if (_IUIBase != null)
            {
                _IUIBase.dispose();
            }

            if (prefabAssetLoadAgent != null)
            {
                prefabAssetLoadAgent.Release();
            }
        }


//        public void onLoadComplete()
//        {
//             _isLoading = false;
//			if(isAppShowIng)
//			{
//				var startTime:int = getTimer();
//				var cls:Class = null;
//				try
//				{
//					cls = ApplicationDomain.currentDomain.getDefinition("com.rpgGame.appModule." +_appName +"." + _appName) as Class;
//				} 
//				catch(error:Error) 
//				{
//					try
//					{
//						cls = ApplicationDomain.currentDomain.getDefinition(_appName) as Class;
//					}
//					catch(error:Error) 
//					{
//						GameLog.addError(error.message);
//					}
//				}
//				if(cls != null)
//				{
//					_app =  new cls();
//					_app.appinfo = _appInfo;
//					_app.supperSetup();
//					_app.setup();
//					_app.initAttr();
//					_app.initView();
//					show();
//					_app.addEventListener(Event.CLOSE,onPanelClose);
//					dispatchEvent(new Event(Event.COMPLETE));
//				}
//				else
//				{
//					var appName:String = "com.rpgGame.appModule." +_appName +"." + _appName
//					trace(appName,"##appName->AppPanel.onLoadComplete() 未找到");
//					
//				}
//				var endTime:int = getTimer();
//				trace(_appName + "##>>>>初始化并打开耗时:" + (endTime - startTime));
//			}
//        }





}
