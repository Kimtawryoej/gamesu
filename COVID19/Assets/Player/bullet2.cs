using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class bullet2 : MonoBehaviour
{
    GameObject GameObject;
    public static bullet2 Instance;
    public int speed = 3;
    Vector3 point1;
    Vector3 point2;
    Vector3 point3;
    Vector3[] points;
    public Vector3 criclepoint;
    public GameObject prefab;
    Vector3 [] cricle;
    public float value;

    

    public IEnumerator  bagiertramsform2()
    {
        yield return null;
        point1 = transform.position;
        point2 = new Vector3(Player.Instance.transform.position.x + 5, Player.Instance.transform.position.y + 5, 0);
        point3 = new Vector3(Player.Instance.transform.position.x, Player.Instance.transform.position.y + 10, 0);
        points = new Vector3[] { point1, point2, point3 };

        Vector3[] point = points.ToArray(); // 복사 
       
        for (float t = 0; t < 1; t += Time.deltaTime*0.05f)
        {
            for (int j = 0; j < 2; j++)
            {
                point[j] = Vector3.Lerp(point[j], point[j + 1], t);
            }
            criclepoint = point[0];
            transform.position = criclepoint;
            Debug.Log("총알 위치 : " + transform.position);
            yield return null;
        }
    }


   

    public void Start()
    { 
        Instance = this;
    }

    private void Update()
    {
        
    }

    public IEnumerator Fire()
    {
        for (float i = 0; i < 0.7f; i += Time.deltaTime)
        {
            yield return null;
        }
        objectpool.Instance.ReturnObject(prefab);
    }

    private void OnEnable()
    {
       
        StartCoroutine(bagiertramsform2());
        StartCoroutine(Fire());
    }
}
