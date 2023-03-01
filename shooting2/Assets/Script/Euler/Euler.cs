using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Euler : Connection<Euler>
{
    void OnEnable()
    {
        StartCoroutine(eluer());
    }
    IEnumerator eluer()
    {
        for (float a = 0; a < 5; a += Time.deltaTime)
        {
            Vector2 dir = Player.Instance.transform.position - gameObject.transform.position;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            transform.eulerAngles = new Vector3(0, 0, angle + 90);
            yield return null;
        }
    }
}
