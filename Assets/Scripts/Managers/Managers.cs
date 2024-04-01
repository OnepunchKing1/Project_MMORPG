using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Managers : MonoBehaviour
{
    static Managers s_instance; // ���ϼ��� ����ȴ�.
    static Managers Instance { get { Init(); return s_instance; } } // ������ �Ŵ����� ����´�.

    DataManager _data = new DataManager();
    InputManager _input = new InputManager();
    ResourcesManager _resource = new ResourcesManager();
    SceneManagerEX _scene = new SceneManagerEX();
    SoundManager _sound = new SoundManager();
    PoolManager _pool = new PoolManager();
    UIManager _ui = new UIManager();
    public static DataManager Data { get { return Instance._data; } }
    public static InputManager Input { get { return Instance._input; } }
    public static ResourcesManager Resource { get { return Instance._resource; } }
    public static SceneManagerEX Scene { get { return Instance._scene; } }
    public static SoundManager Sound { get { return Instance._sound; } }
    public static PoolManager Pool { get { return Instance._pool; } }
    public static UIManager UI { get { return Instance._ui; } }

    void Start()
    {
        Init();
    }


    void Update()
    {
        _input.OnUpdate();
    }

    static void Init()
    {
        if (s_instance == null)
        {
            GameObject go = GameObject.Find("@Managers");
            if (go == null)
            {
                go = new GameObject { name = "@Managers" };
                go.AddComponent<Managers>();
            }

            DontDestroyOnLoad(go);
            s_instance = go.GetComponent<Managers>();

            s_instance._data.Init();
            s_instance._pool.Init();
            s_instance._sound.Init();
        }

    }
    public static void Clear()
    {
        Input.Clear();
        Sound.Clear();
        UI.Clear();
        Scene.Clear();
        Pool.Clear();
    }
}
