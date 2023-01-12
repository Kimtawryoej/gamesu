using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : json
{
    // Start is called before the first frame update
    void Start()
    {
        json.Instance.Save();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
