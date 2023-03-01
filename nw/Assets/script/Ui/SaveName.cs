using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SaveName : Connection<SaveName>
{
    public Button button;
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnClickButton);
    }
    public void OnClickButton()
    {
        NameUi.Instance.gameObject.SetActive(false);
        Ranking.Instance.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
