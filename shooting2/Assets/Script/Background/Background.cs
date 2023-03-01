using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    void FixedUpdate()
    {
        if (!Midboss.Instance.sinho)
        {
            transform.Translate(0, -0.1f, 0);
            if (transform.position.y <= -14f)
            {
                transform.position = new Vector3(0, 23f, 0);
            }
        }
    }
}
