using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager
{
    //기본 sortingorder 가 0부터 시작하기 때문에 order를 10으로 올려준다
    int _order = 10;

    //스택으로 팝업 관리
    //게임 오브젝트가 아닌 해당하는 컴포넌트를 가지고 있는다
    Stack<UI_Popup> _popupStack = new Stack<UI_Popup>();
    UI_Scene _scene = null;

    public GameObject Root
    {
        get
        {
            //생성 오브젝트 정리
            GameObject root = GameObject.Find("@UI_Root");
            if (root == null)
                root = new GameObject { name = "@UI_Root" };
            return root;
        }
    }
    public void SetCanvas(GameObject go, bool sort = true)
    {
        //Canvas 추출
        Canvas canvas = Util.GetOrAddComponent<Canvas>(go);
        canvas.renderMode = RenderMode.ScreenSpaceOverlay;
        //canvas가 중첩해서 있을때 부모가 있어도 자신의 sortingorder를 가진다는 의미
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
    //string 타입인 name은 옵션으로 name이 없으면 T로 그대로 사용한다
    public T ShowSceneUI<T>(string name = null) where T : UI_Scene
    {
        if (string.IsNullOrEmpty(name))
            name = typeof(T).Name;

        GameObject go = Managers.Resource.Instantiate($"UI/Scene/{name}");
        //해당 컴포넌트가 없으면 추가하고 있으면 가져온다
        T sceneUI = Util.GetOrAddComponent<T>(go);  
        _scene = sceneUI;

        go.transform.SetParent(Root.transform);

        return sceneUI;
    }

    //string 타입인 name은 옵션으로 name이 없으면 T로 그대로 사용한다
    public T ShowPopupUI<T>(string name = null) where T : UI_Popup
    {
        if(string.IsNullOrEmpty(name))
            name = typeof(T).Name;

        GameObject go = Managers.Resource.Instantiate($"UI/Popup/{name}");
        //해당 컴포넌트가 없으면 추가하고 있으면 가져온다
        T popup = Util.GetOrAddComponent<T>(go);
        _popupStack.Push(popup);

        go.transform.SetParent(Root.transform);

        return popup;
    }

    //만약 이상한 곳에서 삭제되었을때 예외처리
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
