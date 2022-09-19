using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monster : MonoBehaviour
{
    public float speed = 2.0f;
    public float pos = -1;
    public float pos2 = 1;
    [SerializeField] GameObject bulletPrefab;
    float curDelay;
    [SerializeField] string poolKey = "monster";
    public float xMin, xMax, yMin, yMax;
    public int cnt = 0;
    public static monster Instance;
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
        Block();
        id();
    }

    IEnumerator Move()
    {
        while (cnt < 3)
        {
            transform.Translate(0, pos2 * speed * Time.deltaTime, 0);
            if (transform.position.y > -1f)
            {
                if (curDelay > 1.5f)
                {
                    Bullet bullet = PoolingManager.Instance.GetBullet(poolKey, bulletPrefab);
                    bullet.transform.position = transform.position;
                    bullet.transform.rotation = transform.rotation;
                    curDelay = 0;
                }
                curDelay += Time.deltaTime;


                pos2 = 0;
                transform.Translate(pos * speed * Time.deltaTime, 0, 0);
                if (transform.position.x < -4.05)
                {
                    pos = -1;
                }
                else if (transform.position.x > 4.05)
                {
                    pos = 1;
                }
            }
        yield return null;
        }
    }
    private void OnEnable()
    {
        Debug.Log("E");
        StartCoroutine(Move());
    }

    public void Hit() { cnt++; if (cnt > 3) { gameObject.SetActive(false); } }

    public void Hit2() { cnt+= cnt+4; if (cnt > 3) { gameObject.SetActive(false); } }

    void Block()
    {
        float x = Mathf.Clamp(transform.position.x, xMin, xMax);
        float y = Mathf.Clamp(transform.position.y, yMin, yMax);
        transform.position = new Vector3(x, y, transform.position.z);
    }


    void id()
    {
        Vector3 dir = move.Instance.transform.position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90;   //위코드가 원점에서부터의 거리이기때문에 -90을 안해주면 위로 움직인다
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

}

