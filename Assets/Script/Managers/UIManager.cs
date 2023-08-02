using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager
{
    //�⺻ sortingorder �� 0���� �����ϱ� ������ order�� 10���� �÷��ش�
    int _order = 10;

    //�������� �˾� ����
    //���� ������Ʈ�� �ƴ� �ش��ϴ� ������Ʈ�� ������ �ִ´�
    Stack<UI_Popup> _popupStack = new Stack<UI_Popup>();
    UI_Scene _scene = null;

    public GameObject Root
    {
        get
        {
            //���� ������Ʈ ����
            GameObject root = GameObject.Find("@UI_Root");
            if (root == null)
                root = new GameObject { name = "@UI_Root" };
            return root;
        }
    }
    public void SetCanvas(GameObject go, bool sort = true)
    {
        //Canvas ����
        Canvas canvas = Util.GetOrAddComponent<Canvas>(go);
        canvas.renderMode = RenderMode.ScreenSpaceOverlay;
        //canvas�� ��ø�ؼ� ������ �θ� �־ �ڽ��� sortingorder�� �����ٴ� �ǹ�
        canvas.overrideSorting = true;
        
        if(sort)
        {
            canvas.sortingOrder = _order;
            _order++;
        }
        else
        {
            canvas.sortingOrder = 0;
        }
    }

    public T MakeSubItem<T>(Transform parent = null, string name = null) where T : UI_Base
    {
        if(string.IsNullOrEmpty(name))
            name = typeof(T).Name;
        
        GameObject go = Managers.Resource.Instantiate($"UI/SubItem/{name}");

        if (parent != null)
            go.transform.SetParent(parent);

        return Util.GetOrAddComponent<T>(go);
    }
    //string Ÿ���� name�� �ɼ����� name�� ������ T�� �״�� ����Ѵ�
    public T ShowSceneUI<T>(string name = null) where T : UI_Scene
    {
        if (string.IsNullOrEmpty(name))
            name = typeof(T).Name;

        GameObject go = Managers.Resource.Instantiate($"UI/Scene/{name}");
        //�ش� ������Ʈ�� ������ �߰��ϰ� ������ �����´�
        T sceneUI = Util.GetOrAddComponent<T>(go);  
        _scene = sceneUI;

        go.transform.SetParent(Root.transform);

        return sceneUI;
    }

    //string Ÿ���� name�� �ɼ����� name�� ������ T�� �״�� ����Ѵ�
    public T ShowPopupUI<T>(string name = null) where T : UI_Popup
    {
        if(string.IsNullOrEmpty(name))
            name = typeof(T).Name;

        GameObject go = Managers.Resource.Instantiate($"UI/Popup/{name}");
        //�ش� ������Ʈ�� ������ �߰��ϰ� ������ �����´�
        T popup = Util.GetOrAddComponent<T>(go);
        _popupStack.Push(popup);

        go.transform.SetParent(Root.transform);

        return popup;
    }

    //���� �̻��� ������ �����Ǿ����� ����ó��
    public void ClosePopupUI(UI_Popup popup) 
    {
        if (_popupStack.Count == 0) return;

        if(_popupStack.Peek() != popup)
        {
            Debug.Log("Close Popup Failed!");
            return;
        }
    }
    public void ClosePopupUI()
    {
        if (_popupStack.Count == 0) return;

        UI_Popup popup = _popupStack.Pop();
        Managers.Resource.Destroy(popup.gameObject);
        popup = null;

        _order--;
    }

    public void CloseAllPopupUI()
    {
        while(_popupStack.Count > 0)
        {
            ClosePopupUI();
        }
    }

    public void Clear()
    {
        CloseAllPopupUI();
        _scene = null;
    }
}
