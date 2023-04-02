using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Table table;
    public static GameManager Instance;
    public AllMonster[] ALLMonster;
    //public item[] ALLITEM;
    public Dictionary<Vector3, string> position = new Dictionary<Vector3, string>();
    public string Saveposition = "없음";
    public GameObject Boss;
    public List<GameObject> ITEMS;
    private void Awake()
    {
        Instance = this;
        table.Score = 0;
        table.Name = "";
    }
    private void Start()
    {
        StartCoroutine(Scne());
        Scrpt.Instance.gameObject.GetComponent<Animator>().enabled = false;
    }
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Q))
        {
            Debug.Log("눌렸다");

            if (ITEMS.Count >= 0)
            {
                foreach (GameObject item in ITEMS)
                {
                    item.gameObject.transform.position = Scrpt.Instance.transform.position;
                }
            }
        }

        
        if (Input.GetKey(KeyCode.F1))
        {
            Time.timeScale = 10;
            Scrpt.Instance.gameObject.GetComponent<BoxCollider>().enabled = false;
            Scrpt.Instance.Hp = 150;
            Scrpt.Instance.Fuel = 60;
        }
        else if (Input.GetKeyUp(KeyCode.F1))
        {
            Time.timeScale = 1;
            Scrpt.Instance.gameObject.GetComponent<BoxCollider>().enabled = true;
        }

      

        if (Input.GetKey(KeyCode.Tab) && !Bos.Instance.gameObject.activeSelf)
        {
            ALLMonster = FindObjectsOfType<AllMonster>();
            if (ALLMonster.Length != 0)
            {
                for (int i = 0; i < ALLMonster.Length; i++)
                {
                    position.Add(Scrpt.Instance.transform.position - ALLMonster[i].transform.position, ALLMonster[i].name);
                }
                var a = position.Min(x => x.Key.magnitude);
                var b = position.Where(x => x.Key.magnitude == a).Select(x => x.Value);
                foreach (var x in b)
                    Saveposition = x;
            }
        }

        if (Input.GetKeyUp(KeyCode.Tab))
        {
            ALLMonster = new AllMonster[0];
            position.Clear();
            Saveposition = "없음";

        }
    }
    IEnumerator Scne()
    {
        yield return new WaitUntil(() => Scrpt.Instance.gameObject.GetComponent<Animator>().enabled && Scrpt.Instance.ani.GetCurrentAnimatorStateInfo(0).IsName("Leave") && Scrpt.Instance.ani.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.8f || !Scrpt.Instance.gameObject.activeSelf);
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("ScoreScene");
    }
}
