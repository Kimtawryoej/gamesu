using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ddong : MonoBehaviour
{
    public float speed = 4;
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(-1 * speed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(1 * speed * Time.deltaTime, 0, 0);
        }
    }
}
