
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    public static Map Instance;
    [SerializeField]
    GameObject gameObject;
    public List<Vector3> nodeposition = new List<Vector3>();
    
    
    void Start()
    {
        Instance = this;
        for (int i = 0; i < 9; i++)
        {
            StartCoroutine(wait(i));
            Object.Instance.Bool = false;
        }  
    }
    IEnumerator wait(int i)
    {
        yield return new WaitUntil(() => Object.Instance.Bool);
        for (int j = 1; j < Random.Range(2, 6); j++)
        {
            Vector3 v = gameObject.transform.position + new Vector3(4 * j, -8 * i, 0);
            Instantiate(gameObject, v, Quaternion.identity);
            nodeposition.Add(v);
        }
        
    }
    
}
