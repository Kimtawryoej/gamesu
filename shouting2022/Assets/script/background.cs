using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class background : MonoBehaviour
{
    public float speed = 2.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, -1*speed*Time.deltaTime, 0);
        if(transform.position.y < -9.95)
        {
            transform.position = new Vector2(0, 10.082f);
        }
    }
}
