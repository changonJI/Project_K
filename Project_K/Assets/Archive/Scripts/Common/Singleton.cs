using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 현재 씬에만 존재하는 싱글톤
/// </summary>
/// <typeparam name="T"></typeparam>
public class Singleton<T> where T : class, new()
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
    public Singleton()
    {

    }

    /// <summary>
    /// 소멸자
    /// </summary>
    ~Singleton()
    {

    }
}

/// <summary>
/// 어플이 종료될때까지 존재하는 싱글톤
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
        Debug.Log(IsValid());

        if (instance != null)
            DestroyImmediate(instance.gameObject);

        instance = this as T;
        DontDestroyOnLoad(instance.gameObject);
    }
}
