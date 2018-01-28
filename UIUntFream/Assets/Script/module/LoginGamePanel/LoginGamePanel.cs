using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoginGamePanel : EX_UI_LoginGamePanel
{


    public void show()
    {
        base.show(showInfo);    

    }

    public void showInfo()
    {
        Debug.LogError("--------------LoginGamePanel-----------");

        if (lab == null)
        {
            Debug.LogError("===================lab===============");
        }
    }

   

}
