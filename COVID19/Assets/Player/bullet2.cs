using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet2 : MonoBehaviour
{
    public static bullet2 Instance;
    public int speed = 3;
    public Vector3[] points;

    public Vector3[] bagiertransform(Vector3[] trans)
    {
        Vector3[] transform = new Vector3[trans.Length];
        for (int a = 0; a < trans.Length; a++)
        {
            transform[a] = trans[a];
        }
        return transform;
    }

    public IEnumerator bagiertramsform2()
    {
        while (true)
        {
            Vector3[] point = bagiertransform(points);
            for (int a = points.Length - 1; a >= 0; a++)
            {
                for (int j = 0; j < a; a++)
                {
                    point[j] = Vector3.Lerp(point[j], point[j + 1], 1 / 2);
                }
            }

            yield return null;
        }

    }
    public void Start()
    {
        Instance = this;

    }

    public IEnumerator Fire()
    {
        for (float i = 0; i < 3f; i += Time.deltaTime)
        {
            transform.Translate(*speed * Time.deltaTime);
            yield return null;
        }
        ObjectPool.Instance.ReturnObject(Player.Instance.prefab2);
    }

    private void OnEnable()
    {
        StartCoroutine(Fire());
    }
}
