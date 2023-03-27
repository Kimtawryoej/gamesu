using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class GameManager : SingleTone<GameManager>
{
    public GameObject find;
    public Monster[] Monsters;
    public Dictionary<Vector3, GameObject> Length = new Dictionary<Vector3, GameObject>();
    float tim;
    private void OnEnable()
    {
        tim = 0;
        StartCoroutine(TRUE());
    }
    // Update is called once per frame
    void Update()
    {
        tim += Time.deltaTime;
        if (Input.GetKey(KeyCode.E))
        {
            Time.timeScale = 8;
            Player.instance.gameObject.GetComponent<BoxCollider>().enabled = false;
            Player.instance.Fuel = 60;
        }
        else if (Input.GetKeyUp(KeyCode.E))
        {
            Player.instance.gameObject.GetComponent<BoxCollider>().enabled = true;
            Time.timeScale = 1;
        }

        if (Input.GetKeyDown(KeyCode.Tab))
        {

            Debug.Log("´­·¶´Ù");

            Monsters = FindObjectsOfType<Monster>();
            if (Monsters.Length != 0)
            {
                for (int i = 0; i < Monsters.Length; i++)
                {
                    Length.Add(Monsters[i].transform.position - Player.instance.transform.position, Monsters[i].gameObject);
                }
                if (Length != null && Monsters != null)
                {
                    var MinValue = Length.Min(x => x.Key.magnitude);
                    var Value = Length.Where(x => x.Key.magnitude == MinValue).FirstOrDefault();
                    find = Value.Value;
                }
            }

        }
        else if (Input.GetKeyUp(KeyCode.Tab))
        {
            Monsters = new Monster[0];
            Length.Clear();
            find = null;
        }
    }
    IEnumerator TRUE()
    {
        yield return new WaitUntil(() => tim >= 60);
        Boss.instance.gameObject.SetActive(true);

    }
}
