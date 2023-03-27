using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Earth : MonoBehaviour
{
   

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.Euler(Time.time*30,0,0);
    }
}
