using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : Unit
{
    public static Monster Instance { get; private set; }
    [SerializeField]
    GameObject Mon;
    public int SaveCount2;
    string[] Tag = new string[2] { "Monster2", "Monster3" };
    ParticleAni particle = new ParticleAni();
    [SerializeField]
    GameObject Charging;
    [SerializeField]
    GameObject Boom;
    Bullet Manager =new Bullet();
    public GameObject BoomGet { get => Boom; }
    public override void DieManager()
    {
        int random = Random.Range(0, 4);
        Instantiate(Item.Instance.ObjectITEMs[random], transform.position, Quaternion.identity);
        base.DieManager();
        Destroy(gameObject);
    }
    // Update is called once per frame
    public void Awake()
    {
        Instance = this;
        for (int i = 0; i < Tag.Length; i++)
        {
            if (gameObject.tag == Tag[i])
            {
                Manager.PatternChange = i;
                break;
            }
        }
        Hp = 10;
        Attack = -3f;
        Manager.Ins();
        StartCoroutine(Shot());
        SaveCount2 = Manager.SaveCount;
    }
    private void Start()
    {
        Manager.SpeedGet = 12;
        StartCoroutine(Stop());
        transform.LookAt(Player.Instance.transform);
    }
    private void Update()
    {
        Manager.Lookattransform(transform);
    }
    IEnumerator Shot()
    {
        while (gameObject.tag != "Monster")
        {
            yield return new WaitForSeconds(1);
            Manager.Bulletshot(Manager.SaveCount, Manager.SaveAngle[Manager.SaveCount], gameObject.transform, Mon);
        }
    }
    IEnumerator Stop()
    {
        yield return new WaitUntil(() => gameObject.tag == "Monster");
        yield return new WaitForSeconds(Random.Range(1.0f, 2.0f));
        Manager.SpeedGet = 0;
        StartCoroutine(particle.Charging(1.5f, gameObject.transform.position, Charging,90));
        yield return new WaitForSeconds(1.6f);
        StartCoroutine(particle.Charging(2.8f, gameObject.transform.position, Boom,90));
        yield return new WaitForSeconds(2.9f);
        Destroy(gameObject);

    }
    private void OnTriggerEnter(Collider other)
    {
        TriggerManager.Instance.CheackGameObject(gameObject);
        if (!other.gameObject.CompareTag("PlayerBullet"))
            TriggerManager.Instance.OnTriggerEnter(other);
    }
}
