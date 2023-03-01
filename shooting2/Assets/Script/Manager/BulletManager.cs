using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : Connection<BulletManager>
{
    public List<GameObject> list;// [0] 플레이어 불렛1 , [1] 플레이어 불렛2 , [2] 몬스터 불렛
    public float[] bullePower = new float[2] { 0.5f, 1.3f };
    public float elur;
    bool change = true;
    bool change2 = true;
    float time;
    public float speed = 3;
    int i;
    GameObject[] obj3;
    public void Start()
    {
    }
    public void Update()
    {
        time += Time.deltaTime;
        if (Input.GetMouseButtonDown(1) && time >= speed)
        {
            if (change)
            {
                Player.Instance.transform.Launch(2, list[0], 0);
                time = 0;
            }
            else if (!change)
            {
                Player.Instance.transform.Launch(0, list[1], 0);
                time = 0;
            }
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (change)
            {
                change = false;
            }
            else if (!change)
            {
                change = true;
            }
        }
    }
}
