using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoginGamePanel : UIBase<EX_UI_LoginGamePanel>
{

    private LoginUseCanaves _loginUseCanaves;


    public override void setup()
    {
        base.setup();
        _loginUseCanaves = new LoginUseCanaves();
        _loginUseCanaves.setup(Ref.loginUseCanvas);
    }


    public override void initView()
    {
        base.initView();
    }

    public override void refresh()
    {
        base.refresh();
        showInfo();
        _loginUseCanaves.setData();
    }

    public override void addEvent()
    {
        base.addEvent();
        _loginUseCanaves.addEvent();

        Ref.closeBtn.onClick.Add(new EventDelegate(onClickClose));
        
    }

    public override void removeEvent()
    {
        base.removeEvent();
        _loginUseCanaves.removeEvetn();
    }


    private void onClickClose()
    {
        dispose();
    }


    public override void hide()
    {
        base.hide();
    }

   

    private void showInfo()
    {
        if (Ref.lab == null)
        {
        }
        else
        {
            Ref.lab.text = "-------12345";
        }
    }

    

    
}
