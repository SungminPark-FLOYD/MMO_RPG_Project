using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Scene : UI_Base
{
    //�׻� Init�Լ��� ���� �����ؼ� ���� �ؾ��Ѵ�
    public override void Init()
    {
        Managers.UI.SetCanvas(gameObject, false);
    }

}
