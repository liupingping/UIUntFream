using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class AppConstant
{
    private static Dictionary<string, AppInfo> appNameDic = new Dictionary<string, AppInfo>();

    private static string createAppInfo(string moduleNameP,string resNameP,string loadingTitleP,string btnNameP)
    {

         AppInfo app = appNameDic.ContainsKey(moduleNameP) ? appNameDic[moduleNameP] : null;
		 if(app == null)
		 {
			app = new AppInfo(moduleNameP,resNameP,loadingTitleP,btnNameP);
			appNameDic[moduleNameP] = app;
		 }
			
         return moduleNameP;
	}

    public static AppInfo getAppinfoByAppName(string appName)
	{
			AppInfo info = appNameDic[appName];
			return info;
	}


    public static string LOGIN_GAME_PANEL = createAppInfo("LoginGamePanel", "LoginGamePanel", "登陆面板", "");

}
    
