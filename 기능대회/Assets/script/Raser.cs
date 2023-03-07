using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raser : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    public static Raser Instance { get; private set; }
    public void Awake()
    {
        Instance = this;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void Start()
    {
        gameObject.SetActive(false);
    }
    private void OnEnable()
    {
        StartCoroutine(raser());
    }
    IEnumerator raser()
    {
        yield return null;
        WaitForSeconds wait = new WaitForSeconds(1);
        while (true)
        {
            spriteRenderer.color = Color.blue;
            yield return wait;
            spriteRenderer.color = Color.magenta;
        }
    }
}
