using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomBox : HeadBlock
{

    Rigidbody2D rid;
    SpriteRenderer sprite;
    public GameObject item;
    bool isExecute = false;
    void Start()
    {
        rid = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }
    public override void Execute()
    {
        if (isExecute)
            return;
        Instantiate(item, transform.position + Vector3.up, Quaternion.identity);
        isExecute = true;
    }





}
