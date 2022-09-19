using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    public static move Instance;
    public float xMin, xMax, yMin, yMax;
    Vector3 dir;
    public float speed;
    [SerializeField] GameObject[] bulletPrefab;
    float curDelay;
    [SerializeField] string poolKey = "player";
    public int cnt = 0;
    Rigidbody2D rid;
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        rid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Block();
        ullet();
    }
     void Move()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        dir = new Vector3(h, v, 0);
        dir.Normalize();
        transform.position += dir * speed * Time.deltaTime;

    }

    void Block()
    {
        float x = Mathf.Clamp(transform.position.x, xMin, xMax);
        float y = Mathf.Clamp(transform.position.y, yMin, yMax);
        transform.position = new Vector3(x, y, transform.position.z);
    }

    private void ullet()
    {
        if(Input.GetMouseButtonUp(0) && curDelay > 0.1f)
        {
            
            Bullet bullet = PoolingManager.Instance.GetBullet(poolKey, bulletPrefab[0]);
            bullet.transform.position = transform.position;
            curDelay = 0;
        }
        
        if (Input.GetMouseButtonUp(1) /*&& curDelay > 10f*/)
        {
            Debug.Log("dd");
            Bullet bullet = PoolingManager.Instance.GetBullet(poolKey + "1", bulletPrefab[1]);
            bullet.transform.position = transform.position;
            curDelay = 0;
        }
        curDelay += Time.deltaTime;
    }




    



    public void hit() 
    { 
        cnt++; 
        if (cnt > 3) { gameObject.SetActive(false); }
    }
}