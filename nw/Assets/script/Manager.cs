using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (Public.load != 0)
        {
            Debug.Log("!1");
            if (SceneManager.GetActiveScene().name == "Main")
            {
                json.Instance.playerData = json.Instance.LoadData<PlayerData>(Application.dataPath + "/test.json");
                Player.Instance.transform.position = json.Instance.playerData.position;
                Public.load = 0;
            }
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}
