using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestory : MonoBehaviour
{
    public DontDestory[] gam; 
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        gam = GetComponentsInChildren<DontDestory>();
    }

    // Update is called once per frame
    void Update()
    {
    }
 
}
