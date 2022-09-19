using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    public float speed;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, -1 * Time.deltaTime * speed, 0);
        if(transform.position.y < 0)
        {
            transform.position = new Vector3(0, 20f, 0);
        }
    }
}
