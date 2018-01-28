using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class AppManager
{

        private static  Dictionary<string, AppPanel> _modulePanel = new Dictionary<string, AppPanel>(); 

        /**
		 * 打开某个app  
		 * @param appInfo		指定打开哪个面板
		 * @param data			打开时给面板传入的参数
		 * @param openTable		要打开面板的哪个标签页 ,确定面板里调用了setMainTableBar方法设置主tableBar
		 * @param parentContiner app的父容器对象
		 */			
		public static void showApp(string appName,Object data,String openTable)
		{
			AppInfo appInfo = AppConstant.getAppinfoByAppName(appName);
			preTurnModule(appInfo,data,openTable);
		}


        private static void preTurnModule(AppInfo appInfo,Object data,string openTable)
		{
			//if(AppOpenFilter.isCanOpenApp(appInfo.appName,data,openTable))
			//{
				turnModule(appInfo,data,openTable);
			//}
		}


        /**
		 *  
		 * @param appInfo		要打开的app信息
		 * @param data			给打开的app传递的参数
		 * @param isCloseAll	是否要关闭掉其他已打开的app
		 * @param isAutoHide	如果要打开的app已经是在打开状态，是否要执行对打开的app执行关闭
		 * 
		 */		
		private static void turnModule(AppInfo appInfo,Object data,string openTable)
		{
			if(appInfo != null)
			{
				String moduleName = appInfo.appName;
                AppPanel appPanel = _modulePanel.ContainsKey(moduleName)?_modulePanel[moduleName]:null;
				if(appPanel != null)
				{
//					if(appPanel.isShowing() && isAutoHide)
//					{
//						appPanel.hide();
//					}
//					else 
//					{
//						appPanel.init(data,openTable,parentContiner);
//						appPanel.show();
//					}
				}
				else
				{
//					appPanel = new AppPanel(appInfo);
//					appPanel.depth = _moduleMap.length;
//					_moduleMap.add(moduleName,appPanel);
//					appPanel.init(data,openTable,parentContiner);
//					appPanel.setup();
				}
			}
		}

}