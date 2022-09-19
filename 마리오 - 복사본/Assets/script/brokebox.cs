 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class brokebox : HeadBlock
{
    SpriteRenderer sprite;
    public GameObject item;
    
    public override void Execute()
    {
        this.gameObject.SetActive(false);
    }

}

