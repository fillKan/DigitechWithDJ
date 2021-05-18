using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    public  static T  Instance
    {
        get
        {
            if (_Instance == null)
            {
                _Instance = GameObject.FindObjectOfType(typeof(T)) as T;

                if (_Instance == null)
                {
                    _Instance = new GameObject(typeof(T).ToString(), typeof(T)) as T;
                }
                Object.DontDestroyOnLoad(_Instance.gameObject);
            }
            return _Instance;
        }
    }
    private static T _Instance;
}
