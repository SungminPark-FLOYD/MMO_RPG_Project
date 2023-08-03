using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScene : BaseScene
{
    Coroutine co;
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

        //Coroutine Ÿ������ ���� ����
         co = StartCoroutine("ExplodeAfterSeconds", 4.0f);
        StartCoroutine("CoStopExplode", 2.0f);

    }
    IEnumerator CoStopExplode(float seconds)
    {
        Debug.Log("Stop Enter");
        yield return new WaitForSeconds(seconds);
        Debug.Log("Stop Excute!!");
        if(co != null)
        {
            StopCoroutine(co);
            co = null;
        }
            
    }

    IEnumerator ExplodeAfterSeconds(float seconds)
    {
        Debug.Log("Explode Enter");
        yield return new WaitForSeconds(seconds);
        Debug.Log("Explode Excute!!");
        co = null;
    }

    public override void Clear()
    {

    }
}

/* Coroutine�� �Լ��� ���¸� ����/���� ����
 *  -> ��û ���� �ɸ��� �۾��� ��� ���ų�
 *  -> ���ϴ� Ÿ�ֿ̹� �Լ��� ��� Stop/�����ϴ� ���
 *  -> return�� �츮�� ���ϴ� Ÿ�����ε� �����ϴ�
 */
