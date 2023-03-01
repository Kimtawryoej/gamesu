using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
public class sawblade : json
{
    public LayerMask mask;
   public int z = -1;
    int w = 1;
    public int speed = 100;
    public List<Transform> points;
    public Vector3 criclepoint;

    Rigidbody2D Rigidbody;
   public float a = 0.01f;
    IEnumerator bagier()
    {
        while (true)
        {
            foreach (Transform tr in points)
            {
                Vector3 startPos = transform.position;
                Vector3 targetPos = tr.position;
                for (float t = 0; t < 1; t += Time.deltaTime * 0.7f)
                {
                    transform.position = Vector3.Lerp(startPos, targetPos, t);
                    yield return null;
                }
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody = GetComponent<Rigidbody2D>();
        StartCoroutine(bagier());
    }

    void Update()
    {

        transform.Rotate(new Vector3(0,0,1)*speed * Time.deltaTime);



    }


    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("player"))
        {
            json.Instance.playerData = json.Instance.LoadData<PlayerData>(Application.dataPath + "/test.json");
            Player.hp--;
            Debug.Log(Player.hp);
            savepoint.siv = 0;
            SceneManager.LoadScene("Main");
            //Player.Instance.move = json.Instance.playerData.Move;
            //Player.Instance.jump = json.Instance.playerData.Jump;
            //Player.Instance.jumpPower = json.Instance.playerData.JumpPower;
            //Player.Instance.jumpPower2 = json.Instance.playerData.JumpPower2;
            //Player.Instance.speed2 = json.Instance.playerData.Speed2;
        }
    }
}
