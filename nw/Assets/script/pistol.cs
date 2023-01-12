using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class pistol : Connection<pistol>
{
    Vector3 position;
    public List<Transform> points;
    float speed = -0.001f;
    float Times =0;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(bagier());
       
    }

    // Update is called once per frame
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
