using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class UICreatPanelInstance : MonoSingleton<UICreatPanelInstance>
{

    public IUIBase getUIPanelInstance(string resName)
    {
        IUIBase instance = null;
        switch (resName)
        {
            case "LoginGamePanel":
            {
                instance = new LoginGamePanel();
                break;
            }

        }

        return instance;
    }

}
