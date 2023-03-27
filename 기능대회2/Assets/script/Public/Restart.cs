using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Restart : MonoBehaviour
{
    public GameObject[] g; 
    void Start()
    {
        g = FindObjectsOfType<GameObject>();
        foreach (var item in g)
        {
            item.gameObject.SetActive(false);
            item.gameObject.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
