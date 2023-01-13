using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserObject :Connection<LaserObject>
{

    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("player"))
        {
            json.Instance.playerData = json.Instance.LoadData<PlayerData>(Application.dataPath + "/test.json");
            Player.Instance.transform.position = json.Instance.playerData.position;
            Player.Instance.move = json.Instance.playerData.Move;
            Player.Instance.jump = json.Instance.playerData.Jump;
            Player.Instance.jumpPower = json.Instance.playerData.JumpPower;
            Player.Instance.jumpPower2 = json.Instance.playerData.JumpPower2;
            Player.Instance.speed2 = json.Instance.playerData.Speed2;
            Player.Instance.hp--;
        }
    }
}
