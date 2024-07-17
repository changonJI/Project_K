using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ���� ������ �����ϴ� �̱���
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
    /// ������
    /// </summary>
    public Singleton()
    {

    }

    /// <summary>
    /// �Ҹ���
    /// </summary>
    ~Singleton()
    {

    }
}

/// <summary>
/// ������ ����ɶ����� �����ϴ� �̱���
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
                    Debug.LogError($"___________DontDestroySIngleton_������ ������Ʈ ���� : {typeof(T).ToString()}");
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
