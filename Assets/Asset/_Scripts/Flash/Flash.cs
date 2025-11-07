using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flash : MonoBehaviour
{
    [SerializeField] Material flashMaterial;
    [SerializeField] float duration;
    Material originMaterial;
    SpriteRenderer spriteRenderer;
    Coroutine flashRoutine;
    void Awake()
    {
        spriteRenderer = this.GetComponent<SpriteRenderer>();
    }
    void Start()
    {
        originMaterial = spriteRenderer.material;
        flashMaterial = new Material(flashMaterial);
    }
    public void Flashed()
    {
        if (flashRoutine != null) StopCoroutine(flashRoutine);
        flashRoutine = StartCoroutine(FlashRoutine()); 
    }

    IEnumerator FlashRoutine()
    {
        spriteRenderer.material = flashMaterial;
        yield return new WaitForSeconds(duration);
        spriteRenderer.material = originMaterial;
    } 
}
