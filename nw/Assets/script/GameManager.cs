using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : json
{
    
    private void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    // Start is called before the first frame update



    // 체인을 걸어서 이 함수는 매 씬마다 호출된다.
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
       
        if (savepoint.position != 0 && SceneManager.GetActiveScene().name == "Main" && savepoint.siv == 0)
        {
            json.Instance.playerData = LoadData<PlayerData>(Application.dataPath + "/test.json");
            Player.Instance.transform.position = playerData.position;
           savepoint.siv++;
        }
    }
    // Update is called once per frame
    void Update()
    {
        DisapperMap.Instance.Time3 += Time.deltaTime;
        if (DisapperMap.Instance.Time3 > 3)
        {
            DisapperMap.Instance.Time3 = 0;
            if(DisapperMap.Instance.gameObject.activeSelf == true)
            {
                DisapperMap.Instance.gameObject.SetActive(false);
            }
            else if (DisapperMap.Instance.gameObject.activeSelf == false)
            {
                DisapperMap.Instance.gameObject.SetActive(true);
            }
        }
    }


    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("player"))
        {
            json.Instance.playerData = LoadData<PlayerData>(Application.dataPath + "/test.json");
            Save();
            savepoint.position++;
            savepoint.siv =0;
            savepoint.Instance.save++; // 이게 값이 올갔을때만 설정창에서 세이브지점 시작 눌렀을떄 버튼이 실행되게 만듦
        }
    }
}
