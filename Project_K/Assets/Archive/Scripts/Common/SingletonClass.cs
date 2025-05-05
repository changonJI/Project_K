using UnityEngine;

/// <summary>
/// 싱글톤
/// </summary>
/// <typeparam name="T"></typeparam>
public class SingletonClass<T> where T : class, new()
{
    private static T instance = null;

    public static T Instance
    {
        get
        {
            if(instance == null)
            {
                instance = new T();
            }

            return instance;
        }
    }

    public bool IsValid()
    {
        return instance != null;
    }

    /// <summary>
    /// 생성자
    /// </summary>
    public SingletonClass()
    {

    }

    /// <summary>
    /// 소멸자
    /// </summary>
    ~SingletonClass()
    {

    }
}

/// <summary>
/// 싱글톤
/// </summary>
/// <typeparam name="T"></typeparam>
public class SingletonMono<T> : MonoBehaviour where T : class, new()
{
    private static T instance = null;

    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new T();
            }

            return instance;
        }
    }

    public bool IsValid()
    {
        return instance != null;
    }

    /// <summary>
    /// 생성자
    /// </summary>
    public SingletonMono()
    {

    }

    /// <summary>
    /// 소멸자
    /// </summary>
    ~SingletonMono()
    {

    }
}


/// <summary>
/// 오브젝트를 생성하는 싱글톤
/// </summary>
/// <typeparam name="T"></typeparam>
public class DontDestroySIngleton<T> : MonoBehaviour where T : DontDestroySIngleton<T>
{
    protected static T instance = null;

    public static T Instance
    {
        get
        {
            if(instance == null)
            {
                var go = GameObject.Find(typeof(T).ToString());
                if (go != null)
                {
                    instance = go.GetComponent<T>();
                }
                else
                {
                    Debug.LogError($"___________DontDestroySIngleton_생성된 오브젝트 없음 : {typeof(T).ToString()}");
                }
            }

            return instance;
        }
    }

    public bool IsValid()
    {
        return instance != null;
    }

    protected virtual void Awake()
    {
        if (instance != null)
            DestroyImmediate(instance.gameObject);

        instance = this as T;
        DontDestroyOnLoad(instance.gameObject);
    }
}
