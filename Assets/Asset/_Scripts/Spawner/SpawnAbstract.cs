using UnityEngine;

public abstract class SpawnAbstract : MonoBehaviour
{
    [SerializeField] protected Transform holder;
    [SerializeField] protected float delayTime;
    protected float timer;
    protected void OnEnable()
    {
        timer = delayTime;
    }
    protected void Spawn(GameObject prefabs)
    {
        GameObject obj = ObjectPooling.Instance.Pool(prefabs, this.transform.position, Quaternion.identity, holder);
        obj.transform.position = new Vector3(transform.position.x,prefabs.transform.position.y,prefabs.transform.position.z);
        obj.SetActive(true);
    }


}
