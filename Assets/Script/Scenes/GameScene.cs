using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScene : BaseScene
{
    protected override void Init()
    {
        base.Init();

        SceneType = Define.Scene.Game;
        //�κ��丮 �����
        Managers.UI.ShowSceneUI<UI_Inven>();

        /* UIManager �ǽ�
        //ui����
        //Managers.UI.ShowPopupUI<UI_Button>("UI_Button");
        //����
        //ver1
        //Managers.UI.ClosePopupUI();
        //ver2
        //Managers.UI.ClosePopupUI(ui);
        */
    }

    public override void Clear()
    {

    }
}
