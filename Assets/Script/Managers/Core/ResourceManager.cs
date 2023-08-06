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
            //��θ� �̸����� ����
            string name = path;
            int index = name.LastIndexOf('/');
            if (index >= 0)
                name = name.Substring(index + 1);

            //��ο��� ������ ã���� ���
            GameObject go = Managers.Pool.GetOriginal(name);
            if (go != null)
                return go as T;
        }

        //��ο��� ������ ã�� ������ ��
        return Resources.Load<T>(path);
    }
    //��������
    public GameObject Instantiate(string path, Transform parent = null)
    {
        //1. original �̹� ��� ������ �ٷ� ���
        GameObject original = Load<GameObject>($"Prefabs/{path}");
        if(original == null)
        {
            Debug.Log($"Failed to load prefab : {path}");
            return null;
        }

        //2. Ȥ�� Ǯ���� ������Ʈ�� �ִ���
        if (original.GetComponent<Poolable>() != null)
            return Managers.Pool.Pop(original, parent).gameObject;

        //Poolable ������Ʈ�� ���ٸ�?
        GameObject go = Object.Instantiate(original, parent);
        go.name = original.name;

        return go;
    }
    //�ı� ����
    public void Destroy(GameObject go)
    {
        if (go == null) return;

        //���� Ǯ���� �ʿ��� ������Ʈ�� Ǯ�� �Ŵ������� ��Ź
        Poolable poolable = go.GetComponent<Poolable>();
        if(poolable != null)
        {
            Managers.Pool.Push(poolable);
            return;
        }

        Object.Destroy(go);
    }
}
