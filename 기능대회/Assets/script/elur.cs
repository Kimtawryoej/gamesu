using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public static class elur 
{
    public static void ELUR(this Transform mine, Vector3 target)
    {
        Vector3 vector3 = target - mine.position;
        float a = Mathf.Atan2(vector3.y, vector3.x) * Mathf.Rad2Deg;
        mine.eulerAngles = new Vector3(0, 0, a + 90);
    }
}
