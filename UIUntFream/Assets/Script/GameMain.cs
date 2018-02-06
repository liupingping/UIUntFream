using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMain : MonoBehaviour 
{
    private const string GAME_MAIN = "GameMain";
    private GameObject root;

	public void Start ()
	{
	    initLayer();
	    //showLoginGamePanel();
	}


    private void initLayer()
    {
        UIManager.ins.InitUI();
    }


    private void showLoginGamePanel()
    {
        AppManager.showApp(AppConstant.LOGIN_GAME_PANEL);
    }


	
}
