using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GageMonster : Connection<GageMonster>
{
    public GameObject prefab;
    public float time = 0;
    int chance = 0;
    public LayerMask layerMask;
    public int bullet = 0;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        gage.Instance.transform.position = Camera.main.WorldToScreenPoint(transform.position + new Vector3(0, 0.8f, 0));
        RaycastHit2D ray = Physics2D.CircleCast(transform.position, 7, Vector2.left, 0, layerMask);
        if (ray.collider && bullet == 0)
        {
            chance++;
            if (time > 5)
            {
                chance = 0;

                Debug.Log("½ÇÇà");
                objectpool.Instance.creat(prefab, transform.position);

                bullet = 1;

                time = 0;

            }
        }
        if (chance != 0)
        {
            time += Time.deltaTime;
        }
    }
    IEnumerator disapper()
    {

        yield return new WaitForSeconds(3f);
        objectpool.Instance.creat2(prefab);
        bullet = 0;
    }
}
