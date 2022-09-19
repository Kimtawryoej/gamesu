using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SerializeField]
public class pool : MonoBehaviour
{
    public static pool Instance;
    // Start is called before the first frame update
    void Awake()
    {

        Instance = this;
    }
    [SerializeField] GameObject bulletPrefab;
    Queue<Bullet> bulletpool = new Queue<Bullet>();
    // Update is called once per frame
    public Bullet GetBulllet()
    {
        Bullet bullet = null;
        if(bulletpool.Count > 0)
        {
            bullet = bulletpool.Dequeue();
            bullet.gameObject.SetActive(true);
        }
        else
        {
            bullet = Instantiate(bulletPrefab).GetComponent<Bullet>();
            bullet.transform.SetParent(transform); 
        }
        return bullet;
    }

    public void ReturnBullet(Bullet bullet)
    {

        bullet.gameObject.SetActive(false);
        bulletpool.Enqueue(bullet);
    }
}
