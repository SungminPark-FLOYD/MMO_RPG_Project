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

        //맵핑된 그리드 패널 가져오기
        GameObject gridPanel = Get<GameObject>((int)GameObjects.GridPanel);
        //가지고 있는 자식 오브젝트 삭제
        foreach (Transform child in gridPanel.transform)        
             Managers.Resource.Destroy(child.gameObject);

            //실제 인벤토리 정보 참고
            for(int i = 0; i < 8; i++)
            {
                //아이템 채우기
                GameObject item = Managers.UI.MakeSubItem<UI_Inven_Item>(gridPanel.transform).gameObject;
                UI_Inven_Item invenItem = item.GetOrAddComponent<UI_Inven_Item>();
                invenItem.SetInfo($"집행검 {i}번");
            }
        
    }
}
