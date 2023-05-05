using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object : MonoBehaviour
{
    public static Object Instance;
    LineRenderer lineRenderer;
    public bool Bool {get;set;}
    void Start()
    {
        Bool = false;
        Instance = this;
        lineRenderer = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
