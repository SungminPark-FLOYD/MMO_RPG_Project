using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;

public class ResourceManager
{
    public T Load<T>(string path) where T : Object
    {
        return Resources.Load<T>(path);
    }
    //생성관리
    public GameObject Instantiate(string path, Transform parent = null)
    {
        GameObject prefab = Load<GameObject>($"Prefabs/{path}");
        if(prefab == null)
        {
            Debug.Log($"Failed to load prefab : {path}");
            return null;
        }

        GameObject go = Object.Instantiate(prefab, parent);
        int index = go.name.IndexOf("(Clone)");
        //문자열 자르기
        if(index > 0) 
            go.name = go.name.Substring(0, index);

        return go;
    }
    //파괴 관리
    public void Destroy(GameObject go)
    {
        if (go == null) return;

        Object.Destroy(go);
    }
}
