using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    Button button;
   public  ScriptableManager scriptableManager;

    public void OnClickButton()
    {
        scriptableManager.UpdateGameObjectList();
        SceneManager.LoadScene("Shop", LoadSceneMode.Additive);
    }


    // Start is called before the first frame update
    void Awake()
    {

        DontDestroyOnLoad(gameObject);
        button = GetComponent<Button>();
        button.onClick.AddListener(OnClickButton);
    }


}
