using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoginGamePanel : UIBase<EX_UI_LoginGamePanel>
{
    public override string FolderName { get { return "LoginGamePanel"; } }

    public override string ResouceName { get { return "LoginGamePanel"; } }

    public void show()
    {
        base.show(showInfo);    

    }

    public void showInfo()
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

    public override void addEvent()
    {
        base.addEvent();

    }

    public override void removeEvent()
    {
        base.removeEvent();


    }

    
}
