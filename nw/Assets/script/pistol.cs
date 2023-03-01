using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pistol : Connection<pistol>
{
    float our = 1;
    Vector3 position;
    public List<Transform> points;
    float speed = -0.001f;
    float Times = 0;
    Vector3 targetPos;
    Vector3 startPos;
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
                startPos = transform.position;
                targetPos = tr.position;
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
        //if(startPos.y > transform.position.y && !Input.GetButtonDown("Jump") && collision.gameObject.CompareTag("player"))
        //{
        //    while(Player.Instance.transform.localScale.y > 0.1)
        //    {
        //        our -= 0.1f;
        //        Player.Instance.transform.localScale = new Vector3(1.044f,our , 1);
        //    }
        //}
        if (collision.gameObject.CompareTag("player") && targetPos.y+2.5f >= transform.position.y)
        {
            json.Instance.playerData = json.Instance.LoadData<PlayerData>(Application.dataPath + "/test.json");
            Player.hp--;
            Debug.Log(Player.hp);
            savepoint.siv = 0;
            SceneManager.LoadScene("Main");

        }
    }
}
