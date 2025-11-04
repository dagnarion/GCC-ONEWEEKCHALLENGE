using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooling : Singleton<ObjectPooling>
{
    Dictionary<GameObject, List<GameObject>> container = new Dictionary<GameObject, List<GameObject>>();

    public GameObject Pool(GameObject obj,Vector2 Pos,Quaternion rotation,Transform holder)
    {
        if (!container.ContainsKey(obj))
        {
            container.Add(obj, new List<GameObject>());
        }
        foreach (var it in container[obj])
        {
            if (!it.gameObject.activeSelf) return it;
        }
        GameObject tmp = Instantiate(obj,Pos,rotation,holder);
        container[obj].Add(tmp);
        return tmp;
    }
}
