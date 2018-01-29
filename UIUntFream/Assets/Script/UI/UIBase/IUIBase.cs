using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public interface IUIBase
{
    /**
    void supperSetup();
	void superAddEvent();
	void superRemoveEvent();


    void setup();
	void initAttr();
	void initView();


    void show(object obj = null, string openTable = "");
    void refresh();

    void hide();
	void addEvent();
	void removeEvent();
	void dispose();
     */

    void setAppInfo(AppInfo appInfo);

    void setAssetObject(GameObject obj);


    void initView();
    void setup();
    void show(object obj = null, string openTable = "");

    void refresh();

    void addEvent();
    void removeEvent();
    void hide();
    void dispose();
}
