using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laser : Connection<laser>
{
    int a = 0;
    public int h = -1;
    public int v = 0;
    public float distance = 50;
    public LayerMask layerMask;
    void Start()
    {
        
        StartCoroutine(Laser());
      
    }

    // Update is called once per frame
    void Update()
    {
        LaserObject.Instance.transform.position = transform.position + new Vector3(-3,0,0);
        RaycastHit2D ray2 = Physics2D.Raycast(transform.position, new Vector2(h, v), distance,layerMask);
        Debug.DrawRay(transform.position, new Vector2(h,v),Color.blue, distance);
        if (ray2.collider &&a== 0)
        {
            Debug.Log(ray2.distance);
            LaserObject.Instance.transform .localScale = new Vector3 (ray2.distance,2f,0);
            a = 1;
        }
    }
    IEnumerator Laser()
    {
        while (true)
        {
            yield return new WaitForSeconds(3f);
            LaserObject.Instance.gameObject.SetActive(true);
           
            yield return new WaitForSeconds(2f);
            LaserObject.Instance.gameObject.SetActive(false);
        }
    }

    
}
