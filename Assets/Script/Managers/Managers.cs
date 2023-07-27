using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Managers : MonoBehaviour
{
    static Managers instance;                           //���ϼ��� ����ȴ�
    public static Managers GetInstance() { return instance; }  //������ �Ŵ����� ���� �´�
    void Start()
    {
        Init();
    }

    
    void Update()
    {
        
    }

    static void Init()
    {
        if (instance == null)
        {
            GameObject go = GameObject.Find("@Managers");   //���� �� �̸��� ������Ʈ�� ������ ������ �����
            if (go == null)
            {
                go = new GameObject { name = "@Managers" };
                go.AddComponent<Managers>();
            }
            instance = go.GetComponent<Managers>();
        }
        //�ʱ�ȭ
    }
}
