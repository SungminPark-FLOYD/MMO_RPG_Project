using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Popup : UI_Base
{

    //항상 Init함수를 따로 생성해서 관리 해야한다
    public override void Init()
    {
        Managers.UI.SetCanvas(gameObject, true);
    }

    //삭제
    public virtual void ClosePopupUI()
    {
        Managers.UI.ClosePopupUI(this);
    }

}
