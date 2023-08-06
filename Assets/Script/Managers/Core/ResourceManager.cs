using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;

public class ResourceManager
{
    public T Load<T>(string path) where T : Object
    {   
        if(typeof(T) == typeof(GameObject))
        {
            //경로를 이름으로 추출
            string name = path;
            int index = name.LastIndexOf('/');
            if (index >= 0)
                name = name.Substring(index + 1);

            //경로에서 파일을 찾았을 경우
            GameObject go = Managers.Pool.GetOriginal(name);
            if (go != null)
                return go as T;
        }

        //경로에서 파일을 찾지 못했을 때
        return Resources.Load<T>(path);
    }
    //생성관리
    public GameObject Instantiate(string path, Transform parent = null)
    {
        //1. original 이미 들고 있으면 바로 사용
        GameObject original = Load<GameObject>($"Prefabs/{path}");
        if(original == null)
        {
            Debug.Log($"Failed to load prefab : {path}");
            return null;
        }

        //2. 혹시 풀링된 오브젝트가 있는지
        if (original.GetComponent<Poolable>() != null)
            return Managers.Pool.Pop(original, parent).gameObject;

        //Poolable 컴포넌트가 없다면?
        GameObject go = Object.Instantiate(original, parent);
        go.name = original.name;

        return go;
    }
    //파괴 관리
    public void Destroy(GameObject go)
    {
        if (go == null) return;

        //만약 풀링이 필요한 오브젝트면 풀링 매니저에게 위탁
        Poolable poolable = go.GetComponent<Poolable>();
        if(poolable != null)
        {
            Managers.Pool.Push(poolable);
            return;
        }

        Object.Destroy(go);
    }
}
