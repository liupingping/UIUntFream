﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class AppInfo
{
    public string appName;
    public string loadingTitle;
    public string resName;
    public string btnName;     

    public AppInfo(string moduleNameP,string resNameP, string loadingTitleP,string btnNameP)
    {
		btnName = btnNameP;
		appName = moduleNameP;
		loadingTitle = loadingTitleP;
		resName = resNameP;
	}

}