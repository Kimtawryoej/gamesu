using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeziorDrawer : MonoBehaviour
{
    [SerializeField] private Transform[] pointArr;
    Vector3 circlePoint;

    private IEnumerator Start()
    {
        while (true)
        {
            for (float t = 0; t < 1; t += Time.deltaTime * 0.2f)
            {
                for (int i = 0; i < pointArr.Length - 1; i++)
                    Debug.DrawLine(pointArr[i].position, pointArr[i + 1].position);
                Vector3[] points = Transform2VectorArr(pointArr);

                for (int i = points.Length - 1; i >= 0; i--)
                {
                    for (int j = 0; j < i; j++)
                    {
                        Debug.DrawLine(points[j], points[j + 1]);
                    }
                    for (int j = 0; j < i; j++)
                    {
                        points[j] = Vector3.Lerp(points[j], points[j + 1], t);
                    }
                }
                circlePoint = points[0];

                yield return null;
            }

            //List<Vector3> points = new List<Vector3>();
            //for (float t = 0; t < 1; t += 0.01f)
            //{
            //    points.Add(GetBezior(pointArr, t));
            //}
            //for (int i = 0; i < points.Count - 1; i++)
            //{
            //    yield return null;
            //    Debug.DrawLine(points[i], points[i+1], Color.red, 0.3f);
            //}
            //yield return new WaitForSeconds(0.1f);
        }
    }

    private Vector3 GetBezior(Transform[] transforms, float lerpTime)
    {
        Vector3[] points = Transform2VectorArr(transforms);

        for (int i = points.Length - 1; i >= 0 ; i--)
        {
            for (int j = 0; j < i; j++)
            {
                points[j] = Vector3.Lerp(points[j], points[j + 1], lerpTime);
            }
        }
        return points[0];
    }

    private Vector3[] Transform2VectorArr(Transform[] transforms)
    {
        Vector3[] vector3Arr = new Vector3[transforms.Length];
        for (int i = 0; i < transforms.Length; i++)
        {
            vector3Arr[i] = transforms[i].position;
        }
        return vector3Arr;
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(circlePoint,0.1f);
    }
}
