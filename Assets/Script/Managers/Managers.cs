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

    #region Contents
    GameManager _game = new GameManager();

    public static GameManager Game { get { return Instance._game; } }
    #endregion

    #region Core
    DataManager _data = new DataManager();
    InputManager _input = new InputManager();
    PoolManager _pool = new PoolManager();
    ResourceManager _resourceManager = new ResourceManager();
    SceneManagerEx _scene = new SceneManagerEx();
    SoundManager _sound = new SoundManager();
    UIManager _ui = new UIManager();

    
    public static DataManager Data { get { return Instance._data; } }
    public static InputManager Input { get { return Instance._input; } }
    public static PoolManager Pool { get { return Instance._pool; } }
    public static ResourceManager Resource { get { return Instance._resourceManager; } }
    public static SceneManagerEx Scene { get { return Instance._scene; } }
    public static SoundManager Sound { get { return Instance._sound; } }
    public static UIManager UI { get { return Instance._ui; } }
    #endregion
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

            //Init �ȿ��� Instance�� �ٽ� ����ϰ� �Ǹ� ���� ������ ���� �� �����Ƿ� �����ؾ��Ѵ�
            s_instance._data.Init();
            s_instance._pool.Init();
            s_instance._sound.Init();
        }
    }

    public static void Clear()
    {
        Input.Clear();
        Sound.Clear();
        Scene.Clear();
        UI.Clear(); 
        Pool.Clear();
    }
}
