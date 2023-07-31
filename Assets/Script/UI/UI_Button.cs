using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_Button : UI_Base
{
    //UI �ڵ�ȭ
    enum Buttons
    {
        PointButton,
    }
    enum Texts
    {
        PointText,
        ScoreText,
    }
    //������Ʈ ��ü ����
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
        //enum Ÿ�� �ѱ��
        Bind<Button>(typeof(Buttons));
        Bind<Text>(typeof(Texts));
        Bind<GameObject>(typeof(GameObjects));
        Bind<Image>(typeof(Images));

        

        //���ڸ� �޾Ƽ� �ڵ�� ó��
        GetButton((int)Buttons.PointButton).gameObject.AddUIEvent(OnClickedEvent);

        //�̹��� �̾ƿ���
        GameObject go = GetImage((int)Images.ItemIcon).gameObject;
        AddUIEvent(go, (PointerEventData data) => { go.transform.position = data.position; }, Define.UIEvent.Drag);
       
    }

    int _score = 0;
    public void OnClickedEvent(PointerEventData data)
    {
        _score++;
        GetText((int)Texts.ScoreText).text = $"���� : {_score}";
    }
}
