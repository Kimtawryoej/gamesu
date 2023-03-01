using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class diamond : Connection<diamond>
{
    public static int score;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("player"))
        {
            score++;
            gameObject.SetActive(false);
        }
    }
}
