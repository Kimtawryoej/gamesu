using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    Animator ani;
    // Start is called before the first frame update
    void Start()
    {
        ani = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Tab))
        { ani.SetBool("Up", true); ani.SetBool("Down", false); }

        if (Input.GetKeyUp(KeyCode.Tab))
        { ani.SetBool("Down", true); ani.SetBool("Up", false); }
    }
}
