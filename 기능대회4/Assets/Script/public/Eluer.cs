using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Eluer
{
    public static void Lookat(this Transform myposition, Vector3 targetPosition)
    {
        Vector3 length = targetPosition - myposition.position;
        float angle = Mathf.Atan2(length.y, length.x) * Mathf.Rad2Deg;
        myposition.eulerAngles = new Vector3(0, angle+90, 0);
    }
}
