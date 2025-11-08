using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
  public static T Instance { get; protected set; }
    protected virtual void Awake()
    {
        if (Instance == null) { Instance = this.GetComponent<T>(); return; }
        if (this.GetInstanceID() != Instance.GetInstanceID())
        {
            Debug.LogError("There are two Singleton Object proceed to delete one Object");
            Destroy(this); 
            return;
        }
    }
}
