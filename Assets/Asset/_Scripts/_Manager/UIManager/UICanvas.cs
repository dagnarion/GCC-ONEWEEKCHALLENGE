using UnityEngine;

public class UICanvas : MonoBehaviour
{
    [SerializeField] bool destroyOnClose = false;
    public virtual void SetUp()
    {

    }
    //Mo canvas
    public virtual void Open()
    {
        gameObject.SetActive(true);
    }
    // Tat canvas
    public virtual void Close(float time)
    {
        Invoke(nameof(CloseDirectly),time);
    }
    public virtual void CloseDirectly()
    {
        if (!destroyOnClose) gameObject.SetActive(false);
        else Destroy(this.gameObject);
    }
}
