using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporting :Connection<Teleporting>
{ 
    Vector3 position;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
