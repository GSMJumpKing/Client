using UnityEngine;

public abstract class Singleton<T> : MonoBehaviour where T : Singleton<T>
{
    private static object syncObject = new object();

    private static T instance;

    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                lock (syncObject)
                {
                    // �ν��Ͻ��� ã�´�.
                    instance = FindObjectOfType<T>();
                    // ã�Ҵµ� ���ٸ�?
                    if (instance == null)
                    {
                        // �ν��Ͻ��� ���� �����Ѵ�
                        GameObject obj = new GameObject();
                        obj.name = typeof(T).Name;
                        instance = obj.AddComponent<T>();
                    }
                }
            }
            return instance;
        }
    }
    protected virtual void Awake()
    {
        lock (syncObject)
        {
            if (instance == null)
            {
                instance = this as T;
            }
            else
            {
                Destroy(this);
            }
        }
    }
    private void OnDestroy()
    {
        lock (syncObject)
        {
            if (instance != this)
                return;

            instance = null;
        }
    }
}