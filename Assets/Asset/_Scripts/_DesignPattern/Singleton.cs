using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    public static T Instance { get; protected set; }
    protected virtual void Awake()
    {
        if (Instance == null)
        {
            Instance = this.GetComponent<T>();
        }
        if (this.GetInstanceID() != Instance.GetInstanceID())
        {
            Destroy(this);
            return;
        }
    }
}

public class SingletonDonDestroyOnLoad<T> : MonoBehaviour where T : MonoBehaviour
{
    public static T Instance { get; private set; }
    protected virtual void Awake()
    {
        if (Instance == null)
        {
            if (Instance == null)
            {
                Instance = this.GetComponent<T>();
                DontDestroyOnLoad(gameObject);
            }
            if (this.GetInstanceID() != Instance.GetInstanceID())
            {
                Destroy(this);
                return;
            }
        }
    }
}
