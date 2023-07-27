using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Managers : MonoBehaviour
{
    static Managers s_instance;                           //유일성이 보장된다
    public static Managers Instance { get { Init(); return s_instance; } }  //유일한 매니저를 갖고 온다
    void Start()
    {
        Init();
    }

    
    void Update()
    {
        
    }

    static void Init()
    {
        if (s_instance == null)
        {
            GameObject go = GameObject.Find("@Managers");   //만약 이 이름의 오브젝트가 없으면 문제가 생긴다
            if (go == null)
            {
                go = new GameObject { name = "@Managers" };
                go.AddComponent<Managers>();
            }
            DontDestroyOnLoad(go);
            s_instance = go.GetComponent<Managers>();
        }

    }
}
