using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class gUN : MonoBehaviour
{
    public ScriptableManager scriptableManager;
    public static gUN Instance;
    public Sprite launcher2;
    public static float SaveCoin;
    bool Bool;
    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(save());
    }

    // Update is called once per frame
    void Update()
    {

        if (SceneManager.GetActiveScene().name == "SampleScene" && scriptableManager.Bool)
        {
            for (int i = 0; i < scriptableManager.Sprites.Length; i++)
                if (scriptableManager.Sprites[i] != null)
                    scriptableManager.Sprites[i].sprite = launcher2;
            Debug.Log("º¯½Ã");
        }
    }


    public void Button()
    {

        SaveCoin = GameManager.coin;
        GameManager.coin -= 20;
        scriptableManager.Bool = true;
        Debug.Log(scriptableManager.Sprites.Length);
        for (int i = 0; i < scriptableManager.Sprites.Length; i++)
            if (scriptableManager.Sprites[i] != null)
                scriptableManager.Sprites[i].sprite = ShopManager.instance.launcher2;
    }
    IEnumerator save()
    {
        yield return new WaitUntil(() => Player.Instance.GUN2[0] != null);
        scriptableManager.Sprites[0] = Player.Instance.GUN2[0].GetComponent<SpriteRenderer>();
        yield return new WaitUntil(() => Player.Instance.GUN2[1] != null);
        scriptableManager.Sprites[1] = Player.Instance.GUN2[1].GetComponent<SpriteRenderer>();
    }
    private void OnApplicationQuit()
    {
        scriptableManager.Bool = false;
    }
}
