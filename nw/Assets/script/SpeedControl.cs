using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedControl : MonoBehaviour
{
    int stop = 0;
   public  LayerMask lay;
    float time = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.up, 1, lay);
            if (hit.collider && stop == 0)
        {
            time += Time.deltaTime;
            if(time < 5)
            {
                Player.Instance.speed = 0;
                Debug.Log("¸ØÃç");
            }
            else if(time >=5)
            {
                Player.Instance.speed = 5;
                time = 0;
                stop++;
            }
        }
        if (!hit.collider)
        {
            stop = 0;
        }
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("player"))
        {
            transform.localScale = new Vector3(6.4637f, 0.1f, 1);
        }
    }
    public void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("player"))
        {
            transform.localScale = new Vector3(6.4637f, 0.7685862f, 1);
        }
    }
}
