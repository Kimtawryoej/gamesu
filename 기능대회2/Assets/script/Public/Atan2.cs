using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public static class Atan2
{
    public static void atan2(this Transform mine, Vector3 target)
    {
        Vector3 distance = target - mine.position ;
        float angle = Mathf.Atan2(distance.y, distance.x)*Mathf.Rad2Deg ;
        mine.eulerAngles = new Vector3(angle + 90, angle + 90, angle + 90);
    }
}
