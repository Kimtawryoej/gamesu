using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class afterattack : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    public GameObject dirction;
    public static afterattack Instance;
    private void Awake()
    {
        Instance = this;
        spriteRenderer = GetComponent<SpriteRenderer>();
        gameObject.SetActive(false);
    }
    
    private void OnEnable()
    {
        StartCoroutine(Move());
        StartCoroutine(active());
    }
    IEnumerator Move()
    {
        yield return null;
        WaitForSeconds wait = new WaitForSeconds(1f);
        while (true)
        {
            Instantiate(dirction, transform.position + new Vector3(0,5.8f,0), Quaternion.identity);
            yield return wait;
        }
    }
    IEnumerator active()
    {
        yield return new WaitUntil(() => Raser.Instance.gameObject.activeSelf);
        gameObject.SetActive(false);

    }

}
