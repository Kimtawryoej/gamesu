using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GageAttack : Connection<GageAttack>
{
    public GameObject prefab;
    Rigidbody2D rid;
    // Start is called before the first frame update
    void Start()
    {
        rid = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Player.Instance.transform.position.x > GageMonster.Instance.transform.position.x)
        {
            GageAttack.Instance.rid.velocity = new Vector2(7, 0);
            StartCoroutine(disapper());

        }
        else if (Player.Instance.transform.position.x < GageMonster.Instance.transform.position.x)
        {
            GageAttack.Instance.rid.velocity = new Vector2(-7, 0);
            StartCoroutine(disapper());

        }
    }


    IEnumerator disapper()
    {

        yield return new WaitForSeconds(3f);
        objectpool.Instance.creat2(prefab);
        GageMonster.Instance.bullet = 0;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("player"))
        {
            json.Instance.playerData = json.Instance.LoadData<PlayerData>(Application.dataPath + "/test.json");
            Player.hp--;
            Debug.Log(Player.hp);
            SceneManager.LoadScene("Main");
            //Player.Instance.move = json.Instance.playerData.Move;
            //Player.Instance.jump = json.Instance.playerData.Jump;
            //Player.Instance.jumpPower = json.Instance.playerData.JumpPower;
            //Player.Instance.jumpPower2 = json.Instance.playerData.JumpPower2;
            //Player.Instance.speed2 = json.Instance.playerData.Speed2;
        }
    }
}
