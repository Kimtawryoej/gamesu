using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    public Sprite launcher2;
    public static ShopManager instance;
    public ScriptableManager scriptableManager;
    public GameObject clickButton;
    public List<GameObject> LoadScene = new List<GameObject>();
    Dictionary<GameObject, Action> shop = new Dictionary<GameObject, Action>();

    public void OnClickButton()
    {
        clickButton = EventSystem.current.currentSelectedGameObject;
        if (clickButton.name == "X")
        {
            LoadScene = scriptableManager.gobject;
            Debug.Log(LoadScene.Count);
            scriptableManager.gobject.Clear();
            SceneManager.LoadScene("SampleScene");

        }

        if (clickButton.name == "구매")
        {
            gUN.Instance.Button();
        }
    }

    private void OnSceneChanged(Scene currentScene, Scene nextScene)
    {
        scriptableManager = Resources.Load<ScriptableManager>("ScriptableManager"); // ScriptableObject 재로드
    }
    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
    }

}
