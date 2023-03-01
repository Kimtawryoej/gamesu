using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public class Player : Connection<Player>
{
    Vector3 position;
    Vector3 position2;
    int chance = 0;
    float time;
    public float frame;
    public GameObject prefab;
    public int speed = 5;
    LayerMask layerMask;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //움직이는 코드 
        //float h = Input.GetAxis("Horizontal");
        //Vector3 dir = new Vector3(h, 0, 0);
        //float v = Input.GetAxis("Vertical");
        //Vector3 dir2 = new Vector3(0, 0, v);
        //transform.position += dir * speed * Time.deltaTime;
        //transform.position += dir2 * speed * Time.deltaTime;
        time += Time.deltaTime;
        ////if (Input.GetMouseButtonDown(0))
        ////{
        ////}
        //총 쏘는 코드
        //if (Input.GetMouseButton(0) && time > 0.8f)
        //{
        //    ObjectPool.Instance.shot(prefab, transform.position+new Vector3(1,1,1), Quaternion.Euler(50, 50, 50));
        //    prefab.SetActive(true);
        //    time = 0;
        //}
        //박스 생성 코드
        if (Input.GetMouseButtonDown(1) && time > 0.8f && chance == 0)
        {
            position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,
                Input.mousePosition.y, Input.mousePosition.z+2));
            ObjectPool.Instance.shot(gameObject,position, Quaternion.Euler(50, 50, 50));
            chance = 1;
            time = 0;
        }
        if(Input.GetMouseButtonDown(0))
        {
            Ray position = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(position, out hit, Mathf.Infinity))
            {
                Debug.Log("발견");
            }
        }
    }

}

