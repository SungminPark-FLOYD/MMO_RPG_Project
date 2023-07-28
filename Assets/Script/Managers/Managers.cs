using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Managers : MonoBehaviour
{
    //싱글톤 패턴
    //객체의 인스턴스가 오직 하나만 생성되는 패턴
    static Managers s_instance;                           //유일성이 보장된다
    static Managers Instance { get { Init(); return s_instance; } }
    //유일한 매니저를 갖고 온다

    InputManager _input = new InputManager();
    ResourceManager _resourceManager = new ResourceManager();
    public static InputManager Input { get { return Instance._input; } }
    public static ResourceManager Resource { get { return Instance._resourceManager; } }
    void Start()
    {
        Init();
    }

    
    void Update()
    {
        //입력에 대한 Update문을 대신 실행
        _input.OnUpdate();
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
