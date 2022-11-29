using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet2 : MonoBehaviour
{
    public static bullet2 Instance;
    [SerializeField] private Transform[] points;
    public Vector3 circlePoint;

    public Vector3[] bagiertransform(Transform[] trans)
    {
        Vector3[] transform = new Vector3[trans.Length];
        for (int a = 0; a < trans.Length; a++)
        {
            transform[a] = trans[a].position;
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
            circlePoint = point[0];
            yield return null;
        }

    }
    public void Start()
    {
        Instance = this;
        ;
    }
}
