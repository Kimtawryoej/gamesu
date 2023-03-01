using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ReturnUi : MonoBehaviour
{
    Button button;
    bool rue = true;


    public void OnClickButton()
    {
        SceneManager.LoadScene("Main");
        Player.time = 0;
        Player.hp = 3;
        SceneManager.LoadScene("MainScreen");
    }


    // Start is called before the first frame update
    void Awake()
    {


        button = GetComponent<Button>();
        button.onClick.AddListener(OnClickButton);
    }
}
