using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBullet : Bullet
{
    // Start is called before the first frame update
    void Start()
    {
        SpeedGet = 15;
    }

    // Update is called once per frame
    void Update()
    {
        Lookattransform(transform);
    }
}
