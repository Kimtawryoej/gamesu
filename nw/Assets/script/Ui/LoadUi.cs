using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadUi :Connection<LoadUi>
{
    float number = 2f;
    Button button;
    bool rue = true;
    

    public void OnClickButton()
    {
        Public.load++;
        SceneManager.LoadScene("Main");
    }

   
    // Start is called before the first frame update
    void Awake()
    {
       
        DontDestroyOnLoad(gameObject);
        button = GetComponent<Button>();
        button.onClick.AddListener(OnClickButton);
    }

    private void Update()
    {
        RectTransform rectTransform = GetComponent<RectTransform>();
        rectTransform.anchoredPosition = Vector3.MoveTowards(rectTransform.anchoredPosition, new Vector2(646, -217), number);
    }
}
