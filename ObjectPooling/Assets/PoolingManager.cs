using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolingManager : MonoBehaviour
{
    //싱글톤 패턴
    public static PoolingManager Instance;
    private void Awake()
    {
        Instance = this;
    }

    [SerializeField] GameObject bulletPrefab;
    Queue<Bullet> bulletPool = new Queue<Bullet>(); //비활성화 상태의 총알을 보관할 오브젝트 풀
    public Bullet GetBullet()
    {
        //로컬변수는 값 초기화안하면 더미 값이 들어가서 오류남
        Bullet bullet = null; //반환 할 총알
        if (bulletPool.Count > 0) //bulletPool에 들어있는 총알이 0개 이상이면 = 오브젝트 풀에 총알이 들어있으면
        {
            bullet = bulletPool.Dequeue(); //풀에서 꺼내옴
            bullet.gameObject.SetActive(true);
        }
        else //오브젝트 풀에 총알이 없으면
        {
            bullet = Instantiate(bulletPrefab).GetComponent<Bullet>(); //새로 생성
            bullet.transform.SetParent(transform);
        }
        return bullet; //총알 반환
    }
    public void ReturnBullet(Bullet bullet)
    {
        bullet.gameObject.SetActive(false); //다 쓴 총알은 비활성화
        bulletPool.Enqueue(bullet); //다시 풀에 넣기
    }
}