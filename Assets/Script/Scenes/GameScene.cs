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

        //Data ��������
        Dictionary<int, Stat> dict = Managers.Data.StatDict;

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

/* Coroutine�� �Լ��� ���¸� ����/���� ����
 *  -> ��û ���� �ɸ��� �۾��� ��� ���ų�
 *  -> ���ϴ� Ÿ�ֿ̹� �Լ��� ��� Stop/�����ϴ� ���
 *  -> return�� �츮�� ���ϴ� Ÿ�����ε� �����ϴ�
 *  -> Coroutine Ÿ������ ���� ����
 */
