using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Bullet : MonoBehaviour
{
    int speed = 2;
   public  static Bullet Instance;
    public Vector3 position;
    Player player = new Player();
    public GameObject prefab;
    public Quaternion quaternion;
    private void Awake()
    {
        Instance = this;
        position = new Vector3(transform.position.x, transform.position.y, 0);
    }







    public IEnumerator Fire()
    {
        for (float i = 0; i < 3f; i += Time.deltaTime)
        {
            transform.Translate(new Vector3(0, 2, 0) * speed * Time.deltaTime);
            yield return null;
        }
        objectpool.Instance.ReturnObject(prefab);
    }

    private void OnEnable()
    {
        StartCoroutine(Fire());
    }
}

