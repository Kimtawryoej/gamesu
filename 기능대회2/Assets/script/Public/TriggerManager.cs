using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerManager : Unit
{
    private void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.layer == 6)
        {
            Player.Instance.HpManager(1);
        }
    }
}
