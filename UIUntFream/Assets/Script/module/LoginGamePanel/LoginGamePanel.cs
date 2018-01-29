using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoginGamePanel : UIBase<EX_UI_LoginGamePanel>
{
    public override void setup()
    {
        base.setup();
        Debug.LogError("--------------------setup---------------------");
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

    }

    public override void addEvent()
    {
        base.addEvent();
        Debug.LogError("--------------------addEvent---------------------");
    }

    public override void removeEvent()
    {
        base.removeEvent();
        Debug.LogError("--------------------removeEvent---------------------");
    }

    public override void hide()
    {
        base.hide();
        Debug.LogError("--------------------hide---------------------");
    }

    public override void dispose()
    {
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
