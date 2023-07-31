using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_Button : UI_Base
{
    //UI 자동화
    enum Buttons
    {
        PointButton,
    }
    enum Texts
    {
        PointText,
        ScoreText,
    }
    //오브젝트 자체 연동
    enum GameObjects
    {
        TestObject,
    }

    enum Images
    {
        ItemIcon,
    }
    private void Start()
    {
        //enum 타입 넘기기
        Bind<Button>(typeof(Buttons));
        Bind<Text>(typeof(Texts));
        Bind<GameObject>(typeof(GameObjects));
        Bind<Image>(typeof(Images));

        

        //인자를 받아서 코드로 처리
        GetButton((int)Buttons.PointButton).gameObject.AddUIEvent(OnClickedEvent);

        //이미지 뽑아오기
        GameObject go = GetImage((int)Images.ItemIcon).gameObject;
        AddUIEvent(go, (PointerEventData data) => { go.transform.position = data.position; }, Define.UIEvent.Drag);
       
    }

    int _score = 0;
    public void OnClickedEvent(PointerEventData data)
    {
        _score++;
        GetText((int)Texts.ScoreText).text = $"점수 : {_score}";
    }
}
