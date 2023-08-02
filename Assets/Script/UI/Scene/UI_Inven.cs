using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Inven : UI_Scene
{
    enum GameObjects
    {
        GridPanel,
    }
    void Start()
    {
        Init();
    }

    public override void Init()
    {
        base.Init();

        Bind<GameObject>(typeof(GameObjects));

        //���ε� �׸��� �г� ��������
        GameObject gridPanel = Get<GameObject>((int)GameObjects.GridPanel);
        //������ �ִ� �ڽ� ������Ʈ ����
        foreach (Transform child in gridPanel.transform)        
             Managers.Resource.Destroy(child.gameObject);

            //���� �κ��丮 ���� ����
            for(int i = 0; i < 8; i++)
            {
                //������ ä���
                GameObject item = Managers.UI.MakeSubItem<UI_Inven_Item>(gridPanel.transform).gameObject;
                UI_Inven_Item invenItem = item.GetOrAddComponent<UI_Inven_Item>();
                invenItem.SetInfo($"����� {i}��");
            }
        
    }
}
