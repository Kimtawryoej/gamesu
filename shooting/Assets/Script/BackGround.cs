using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{
    void Update()
    {
        transform.Translate(new Vector2(0, -0.01f));
        if(transform.position.y < -14.6f)
        {
            transform.position = new Vector2(0.2f, 14.7f);
        }
    }
}
