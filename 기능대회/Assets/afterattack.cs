using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class afterattack : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    public static afterattack Instance;
    private void Awake()
    {
        Instance = this;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    // Start is called before the first frame update
    void Start()
    {
        //gameObject.SetActive(false);
    
    }
    private void OnEnable()
    {
    }
    // Update is called once per frame
    
}
