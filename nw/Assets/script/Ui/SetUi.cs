using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SetUi : Connection<SetUi>
{
    Button button;
    bool rue = true;


    public void OnClickButton()
    {
        if (Set.Instance.gameObject.activeSelf == false)
        {
            Set.Instance.gameObject.SetActive(true);
        }
        else if (Set.Instance.gameObject.activeSelf == true)
        {
            Set.Instance.gameObject.SetActive(false);
        }
    }


    // Start is called before the first frame update
    void Awake()
    {

        
        button = GetComponent<Button>();
        button.onClick.AddListener(OnClickButton);
    }
}
