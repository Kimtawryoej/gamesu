using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public int b;
    public int c = 0;
    public GameObject[] Key = new GameObject[4];
    public IEnumerator[] value = new IEnumerator[4];
    public static ItemManager Instance { get; private set; }
    public Dictionary<GameObject, IEnumerator> items = new Dictionary<GameObject, IEnumerator>();
    private void Start()
    {
        Instance = this;

        items = new Dictionary<GameObject, IEnumerator>
        {
            {GameObject.Find("BulletItem"),BulletItem()},
            {GameObject.Find("invincibilityITEM"),invincibility()},
            {GameObject.Find("수리item"),HPItem()},
            {GameObject.Find("GageITem"),fuel()}

        };
        foreach (var item in items)
        {
            Key[c] = item.Key;
            value[c] = item.Value;
            c++;
        }
    }
    public IEnumerator BulletItem()
    {
        yield return null;
        Player.Instance.LV++;
        Debug.Log("아이템총알");

    }
    public IEnumerator invincibility()
    {
        Debug.Log("무적");
        Player.Instance.gameObject.GetComponent<PolygonCollider2D>().enabled = false;
        yield return new WaitForSeconds(4);
        Player.Instance.gameObject.GetComponent<PolygonCollider2D>().enabled = true;
    }
    public IEnumerator HPItem()
    {
        yield return null;
        Debug.Log("회복");
        Player.Instance.HPMANAGER[0] += 3;

    }

    public IEnumerator fuel()
    {
        yield return null;
        Debug.Log("연료");
        Player.Instance.HPMANAGER[1] += 3;

    }

}
