using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    CapsuleCollider2D co;

    // Start is called before the first frame update
    void Start()
    {
        co = GetComponent<CapsuleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "mushroom")
        {
            this.gameObject.SetActive(false);
            Invoke("stop", 0.1f);
        }
        else if (collision.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
        }
    }

    void stop()
    {
        this.gameObject.SetActive(true);
    }
}
