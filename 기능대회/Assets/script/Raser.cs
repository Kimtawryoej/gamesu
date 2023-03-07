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
        StartCoroutine(active());
    }
  
    IEnumerator active()
    {
        yield return null;
        yield return new WaitUntil(()=> Boss.instance.pattern != 3);
        gameObject.SetActive(false); 

    }
}
