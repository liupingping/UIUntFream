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
	}


    private void initLayer()
    {
        StartCoroutine(UIManager.ins.InitUI(showLoginGamePanel));
    }


    private void showLoginGamePanel()
    {
        AppManager.showApp(AppConstant.LOGIN_GAME_PANEL);
    }


	
}
