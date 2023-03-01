using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Public : Connection<Public>
{
    public static int load = 0;
    // Start is called before the first frame update
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
