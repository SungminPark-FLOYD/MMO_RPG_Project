using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Managers : MonoBehaviour
{
    //�̱��� ����
    //��ü�� �ν��Ͻ��� ���� �ϳ��� �����Ǵ� ����
    static Managers s_instance;                           //���ϼ��� ����ȴ�
    static Managers Instance { get { Init(); return s_instance; } }
    //������ �Ŵ����� ���� �´�

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
        //�Է¿� ���� Update���� ��� ����
        _input.OnUpdate();
    }

    static void Init()
    {
        if (s_instance == null)
        {
            GameObject go = GameObject.Find("@Managers");   //���� �� �̸��� ������Ʈ�� ������ ������ �����
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
