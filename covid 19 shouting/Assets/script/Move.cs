using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    Vector3 dir;
    float speed = 5f;
    public Vector2 moveLimit;
    [SerializeField] GameObject bulletPrefab;
    float curDelay = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        move();
        tang();
        transform.localPosition = ClamPositionX(transform.localPosition);
        transform.localPosition = ClamPositionX(transform.localPosition);
    }

    void move()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        dir = new Vector3(h, v, 0);
       

        transform.position += dir * speed * Time.deltaTime;

    }
    public Vector3 ClamPositionX(Vector3 position)
    {
        return new Vector4
           (
              Mathf.Clamp(position.x, -moveLimit.x, moveLimit.x),
               Mathf.Clamp(position.y, -moveLimit.y, moveLimit.y),
              -0.1f,
              0
           );
    }

    public void tang()
    {
        if(Input.GetButtonUp("Fire1") && curDelay > 0.1f)
        {
            Bullet bullet = pool.Instance.GetBulllet();
            bullet.transform.position = transform.position;
            curDelay = 0;
        }
        curDelay += Time.deltaTime;
    }
}
