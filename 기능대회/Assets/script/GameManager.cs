using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEditor.Experimental.GraphView.GraphView;
using static UnityEngine.ParticleSystem;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public static float score;
    public static float coin;
    public bool Bool = true;
    public float T;
    public bool COlor;
    public GameObject[] AttackRang = new GameObject[1];
    public ScriptableManager scriptableManager;
    private void OnApplicationQuit()
    {
        scriptableManager.Bool = false;
    }
    private void Awake()
    {
        instance = this;
        COlor = true;
    }
    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "SampleScene")
        {

            if (score == 100)
            {
                Boss.instance.gameObject.SetActive(true);
                Bool = true;
            }
            if (Boss.instance.gameObject.activeSelf)
                BossHpUi.instance.gameObject.SetActive(true);
            else
                BossHpUi.instance.gameObject.SetActive(false);
        }
        if (scriptableManager.gobject.Count == 0)
        {
            scriptableManager.gobject = ShopManager.instance.LoadScene;
            Debug.Log(scriptableManager.gobject.Count);
        }


    }
    public IEnumerator TI()
    {
        Player.Instance.animator.SetBool("Color", true);
        Player.Instance.StopTrigger = false;
        while (T > 0)
        {
            COlor = false;
            T -= Time.deltaTime;
            yield return null;
        }
        Player.Instance.StopTrigger = true;
        Player.Instance.animator.SetBool("Color", false);
        T = 0;
        COlor = true;
        yield return null;

    }

}
