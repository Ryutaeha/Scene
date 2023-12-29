using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    private static Main _instance;
    private static bool _initialized;
    private static Main Instance
    {
        get
        {
            if (_initialized) return _instance;
            _initialized = true;
            GameObject main = GameObject.Find("@Main");
            if (main != null) return _instance;
            main = new GameObject { name = "@Main" };
            main.AddComponent<Main>();
            DontDestroyOnLoad(main);
            _instance = main.GetComponent<Main>();
            return _instance;
        }
    }
    private readonly GameManager _game = new();
    public static GameManager Game => Instance._game;

}
