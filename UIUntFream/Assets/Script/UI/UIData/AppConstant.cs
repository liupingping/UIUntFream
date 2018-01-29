using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class AppConstant
{
    private static Dictionary<string, AppInfo> appNameDic = new Dictionary<string, AppInfo>();
    
    /// <summary>
    /// 创建面板信息
    /// </summary>
    /// <param name="moduleNameP">模块名</param> 
    /// <param name="folderNameP">目录名</param>
    /// <param name="resNameP">资源名</param>
    /// <param name="loadingTitleP">加载名</param>
    /// <param name="btnNameP">点击按钮</param>
    /// <returns></returns>
    private static string createAppInfo(string moduleNameP,string folderNameP,string resNameP,string loadingTitleP,string btnNameP)
    {

         AppInfo app = appNameDic.ContainsKey(moduleNameP) ? appNameDic[moduleNameP] : null;
		 if(app == null)
		 {
             app = new AppInfo(moduleNameP, folderNameP,resNameP, loadingTitleP, btnNameP);
			appNameDic[moduleNameP] = app;
		 }
			
         return moduleNameP;
	}

    public static AppInfo getAppinfoByAppName(string appName)
	{
			AppInfo info = appNameDic[appName];
			return info;
	}


    public static string LOGIN_GAME_PANEL = createAppInfo("LoginGamePanel","LoginGamePanel", "LoginGamePanel", "登陆面板", "");

}
    
