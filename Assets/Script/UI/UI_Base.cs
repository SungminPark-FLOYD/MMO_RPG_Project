using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public abstract class UI_Base : MonoBehaviour
{
    //유니티에서 사용되는 모든 것들은 UnityEngine.Object로 저장할 수 있다

    protected Dictionary<Type, UnityEngine.Object[]> _objects = new Dictionary<Type, UnityEngine.Object[]>();

    public abstract void Init();
    protected void Bind<T>(Type type) where T : UnityEngine.Object
    {
        string[] names = Enum.GetNames(type);

        UnityEngine.Object[] objects = new UnityEngine.Object[names.Length];
        _objects.Add(typeof(T), objects);

        for (int i = 0; i < names.Length; i++)
        {
            //GameObject전용 버전
            if (typeof(T) == typeof(GameObject))
                objects[i] = Util.FindChild(gameObject, names[i], true);
            else
                objects[i] = Util.FindChild<T>(gameObject, names[i], true);
        }
    }

    protected T Get<T>(int idx) where T : UnityEngine.Object
    {
        //키값 뽑아오기

        UnityEngine.Object[] objects = null;
        if (_objects.TryGetValue(typeof(T), out objects) == false)
            return null;

        //성공 시

        return objects[idx] as T;
    }

    protected GameObject GetObjet(int idx) { return Get<GameObject>(idx); }
    protected Text GetText(int idx) { return Get<Text>(idx); }
    protected Button GetButton(int idx) { return Get<Button>(idx); }
    protected Image GetImage(int idx) { return Get<Image>(idx); }

    public static void BindEvent(GameObject go, Action<PointerEventData> action, Define.UIEvent type = Define.UIEvent.Click)
    {
    
        UI_EventHandler evt = Util.GetOrAddComponent<UI_EventHandler>(go);

        switch(type)
        {
            case Define.UIEvent.Click:
                evt.OnClickHandler -= action;
                evt.OnClickHandler += action;
                break;
            case Define.UIEvent.Drag:
                evt.OnDragHandler -= action;
                evt.OnDragHandler += action;
                break;

        }
        evt.OnDragHandler += ((PointerEventData data) => { evt.gameObject.transform.position = data.position; });
    }
}
