using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaserMonster : Singleton<RaserMonster>
{
    public GameObject Raser;
    
    void Start()
    {
        Instantiate(Raser, transform.position, Quaternion.identity);
        Instantiate(Raser, transform.position, Quaternion.Euler(0, 0, 90));
    }
}
