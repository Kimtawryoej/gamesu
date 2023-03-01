using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RunMonster : MonoBehaviour
{
    [SerializeField] LayerMask layerMask;
    float monster = -1;
    public SpriteRenderer sprite;
    public List<Transform> points;
    IEnumerator bagier()
    {
        while (true)
        {
            foreach (Transform tr in points)
            {
                Vector3 startPos = transform.position;
                Vector3 targetPos = tr.position;
                for (float t = 0; t < 1; t += Time.deltaTime * 0.3f)
                {
                    transform.position = Vector3.Lerp(startPos, targetPos, t);
                    yield return null;
                }
                if (sprite.flipX == false && targetPos.x >= transform.position.x)
                {
                    sprite.flipX = true;
                }
                else if (sprite.flipX == true && targetPos.x <= transform.position.x)
                {
                    sprite.flipX = false;
                }
            }
            yield return null;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        StartCoroutine(bagier());
        StartCoroutine(color());
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
        }
    }
    // Update is called once per frame
    void Update()
    {
        sprite.material.color = Color.red;

    }
    IEnumerator color()
    {
        while (true)
        {
            if(gameObject.CompareTag("magnetMonster"))
            {
                yield return new WaitForSeconds(4f);
                sprite.material.color = Color.red;
                yield return new WaitForSeconds(2f);
                sprite.material.color = Color.white;
            }
            yield return null;
        }
    }
}
