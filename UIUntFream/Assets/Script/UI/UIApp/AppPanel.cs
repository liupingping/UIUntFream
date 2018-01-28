using System;
using System.Collections;
using System.Collections.Generic;

public class AppPanel 
{
        private AppInfo _appInfo;
	    private string _appName;
	    private Object _data;
	    private string _openTable;
        private bool _isAppShowIng = false;

        private IUIBase _IUIBase;

        /**
		 * app资源是否已经在加载中 
		 */		
		private bool _isLoading = false;


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
//          if(_app)
//			{
//				return ;
//			}
//			if(_isLoading)
//			{
//				return ;
//			}
//			isAppShowIng = true;
//			
//			var appUrl:String = ClientConfig.getAppModule(_appInfo.resName);
//			if(_appInfo.appLoadType == AppInfo.SWF)
//			{
//				_isLoading = true;
//				GameLog.add("##load app res:" + _appInfo.resName);
//				AppLoadManager.instace.loadByUrl(
//					appUrl,_appInfo.loadingTitle,onLoadComplete);
//			}else{
//				onLoadComplete(appUrl);
//			}
        }

        public void show()
        {
//          isAppShowIng = true;
//			if(_app)
//			{
//				var startTime:int = getTimer();
//				if(_app.parent == null || _app.isHideEffecting())
//				{
//					_app.superAddEvent();
//					_app.addEvent();
//				}
//				_app.show(_data,_openTable,_parentContiner);
//				_app.refresh();
//				var endTime:int = getTimer();
//				trace(_appName + "##>>>>打开耗时:" + (endTime - startTime));
//			}
//			else  
//			{
//				setup();
//			}
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
        }

        public void dispose()
        {
//            hide();
//            if (_app)
//            {
//                _app.dispose();
//            }
        }


        public void onLoadComplete()
        {
             _isLoading = false;
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

        
        }





}
