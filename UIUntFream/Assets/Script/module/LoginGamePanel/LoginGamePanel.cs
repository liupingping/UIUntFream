using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoginGamePanel : UIBase<EX_UI_LoginGamePanel>
{
    public override void setup()
    {
        base.setup();
        Debug.Log("--------------------setup---------------------");
    }


    public override void initView()
    {
        base.initView();
        Debug.Log("--------------------initView---------------------");
    }

    public override void refresh()
    {
        base.refresh();
        Debug.Log("--------------------refresh---------------------");
        showInfo();

    }

    public override void addEvent()
    {
        base.addEvent();
        Debug.Log("--------------------addEvent---------------------");
    }

    public override void removeEvent()
    {
        base.removeEvent();
        Debug.Log("--------------------removeEvent---------------------");
    }

    public override void hide()
    {
        base.hide();
        Debug.Log("--------------------hide---------------------");
    }

    public override void dispose()
    {
        base.dispose();
        Debug.Log("--------------------dispose---------------------");
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
