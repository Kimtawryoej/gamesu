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
        if (gameObject.CompareTag("BossSkillRang"))
        {
            gameObject.SetActive(false);
            Debug.Log("비활성화");
        }

    }

    private void OnEnable()
    {
        if (Boss.instance.gameObject.activeSelf)
        {
            StartCoroutine(Move());
            StartCoroutine(active());
        }
        else if (Meteor.Instance.gameObject.activeSelf)
        {
            StartCoroutine(Move2());
            StartCoroutine(active2());
        }
    }
    IEnumerator Move()
    {
        yield return null;
        WaitForSeconds wait = new WaitForSeconds(1f);
        while (true)
        {
            Debug.Log("비활성화");
            Instantiate(dirction, transform.position + new Vector3(0, 15f, 0), Quaternion.identity);
            yield return wait;
        }
    }
    IEnumerator Move2()
    {
        yield return null;
        WaitForSeconds wait = new WaitForSeconds(1f);
        while (true)
        {
            if (Meteor.Instance.DESTORY == true)
            {
                Debug.Log("비활성화");
                Instantiate(dirction, transform.position + new Vector3(0, 5f, 0), Quaternion.identity);
                yield return wait;
            }
        }
    }
    IEnumerator active()
    {
        yield return new WaitUntil(() => Raser.Instance.gameObject.activeSelf);
        StartCoroutine(Dir.Instance.destory3());
        GameManager.instance.AttackRang[0].SetActive(false);
        Debug.Log("오류");
    }

    IEnumerator active2()
    {
        yield return new WaitUntil(() => Meteor.Instance.DESTORY == false);
        StartCoroutine(Dir.Instance.destory3());
        Destroy(gameObject);
        Meteor.Instance.DESTORY = true;
    }
}
