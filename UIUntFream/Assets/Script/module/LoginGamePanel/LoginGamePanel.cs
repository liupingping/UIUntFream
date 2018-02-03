using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoginGamePanel : UIBase<EX_UI_LoginGamePanel>
{

    private LoginUseCanaves _loginUseCanaves;


    public override void setup()
    {
        base.setup();
        Debug.LogError("--------------------setup---------------------");
        _loginUseCanaves = new LoginUseCanaves();
        _loginUseCanaves.setup(Ref.loginUseCanvas);
    }


    public override void initView()
    {
        base.initView();
        Debug.LogError("--------------------initView---------------------");

       

    }

    public override void refresh()
    {
        base.refresh();
        Debug.LogError("--------------------refresh---------------------");
        showInfo();
        _loginUseCanaves.setData();
    }

    public override void addEvent()
    {
        base.addEvent();
        _loginUseCanaves.addEvent();
        Debug.LogError("--------------------addEvent---------------------");
    }

    public override void removeEvent()
    {
        base.removeEvent();
        _loginUseCanaves.removeEvetn();
        Debug.LogError("--------------------removeEvent---------------------");
    }

    public override void hide()
    {
        base.hide();
        Debug.LogError("--------------------hide---------------------");
    }

    public override void dispose()
    {
        _loginUseCanaves.destory();
        base.dispose();
        Debug.LogError("--------------------dispose---------------------");
    }


    private void showInfo()
    {
        Debug.LogError("--------------LoginGamePanel-----------");

        if (Ref.lab == null)
        {
            Debug.LogError("===================lab===============");
        }
        else
        {
            Ref.lab.text = "-------12345";
        }
    }

    

    
}
