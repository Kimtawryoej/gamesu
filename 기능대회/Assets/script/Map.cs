using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    public static Map Instance;
    public static int speed = -6;
    public GameObject[] map = new GameObject[2]; 
    void Awake()
    {
        Instance = this;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(0, speed * Time.fixedDeltaTime, 0);
        if (transform.position.y < -10.23f)
            transform.position = new Vector3(-0.2f, 11.3f, 0);
    }
}
