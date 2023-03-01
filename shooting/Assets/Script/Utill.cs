using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utill
{
    public static void LookAt2D(this Transform mine, Vector3 target)
    {
        Vector2 dir = target - mine.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        mine.eulerAngles = new Vector3(0, 0, angle + 90);
    }
}
