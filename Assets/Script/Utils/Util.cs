using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class Util
{
    public static T GetOrAddComponent<T>(GameObject go) where T : UnityEngine.Component
    {
        T component = go.GetComponent<T>();
        if(component == null)
            component = go.AddComponent<T>();
        return component;
    }
    public static GameObject FindChild(GameObject go, string name = null, bool recursive = false)
    {
        Transform transform = FindChild<Transform>(go, name, recursive);
        if (transform == null)
            return null;

        return transform.gameObject;
    }

    public static T FindChild<T>(GameObject go, string name = null, bool recursive = false) where T : UnityEngine.Object
    {
        //최상위 객체가 null이라면
        if(go == null)
            return null;

        if(recursive == false)
        {
            for(int i =0; i < go.transform.childCount; i++)
            {
                //자식들을 하나씩 스캔해서 해당 컴포넌트를 가지고 있는지 확인
                Transform transform = go.transform.GetChild(i);
                if (string.IsNullOrEmpty(name) || transform.name == name)
                {
                   T component = transform.GetComponent<T>();
                    if(component != null)
                        return component;
                }
            }
            
        }
        else
        {
            foreach(T component in go.GetComponentsInChildren<T>())
            {
                //이름을 입력하지 않았을 떄도 찾을 수 있게 조건 추가
                if(string.IsNullOrEmpty(name) || component.name == name)
                    return component;
            }
        }

        return null;
    }
}
