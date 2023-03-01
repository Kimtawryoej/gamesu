using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Ui2 : MonoBehaviour
{
    float number = 2f;
    Button button;
    bool rue = true;
    Vector3 position2 = new Vector3(646, 137, 0);

    public void OnClickButton()
    {
        SceneManager.LoadScene("Main");
    }
    // Start is called before the first frame update
    void Start()
    {



        button = GetComponent<Button>();
        button.onClick.AddListener(OnClickButton);
    }

    // Update is called once per frame
    void Update()
    {
        RectTransform rectTransform = GetComponent<RectTransform>();
        rectTransform.anchoredPosition = Vector3.MoveTowards(rectTransform.anchoredPosition, new Vector2(646, 137), number);
    }
}
