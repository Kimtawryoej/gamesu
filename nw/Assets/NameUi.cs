using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NameUi : Connection<NameUi>
{
    public int a = 5;
    // Start is called before the first frame update
    protected override void Awake()
    {
        base.Awake();
       gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
