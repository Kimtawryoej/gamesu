using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : Connection<Bullet>
{
    //Vector3 traget = new Vector3(Player.Instance.transform.position.x, Player.Instance.transform.position.y, Player.Instance.transform.position.z+8);
    public GameObject targetPosition;
    public GameObject prefab;
    IEnumerator disapper()
    {
        for (float t = 0; t < 1; t += Time.deltaTime)
        {
           //transform.position += Vector3.forward*1.2f;
            transform.position = Vector3.Slerp(Player.Instance.transform.position+ new Vector3(1, 1, 1), Player.Instance.transform.position+ new Vector3(0,0,10), t*0.9999f);
            yield return null;
        }
        ObjectPool.Instance.disappear(prefab);
    }
    private void OnEnable()
    {
        StartCoroutine(disapper());
    }
}
