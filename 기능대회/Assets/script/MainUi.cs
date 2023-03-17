using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MainUi : MonoBehaviour
{
    public void OnclickButton()
    {
        string ButtonName = EventSystem.current.currentSelectedGameObject.name;
        if (ButtonName == "Start")
            SceneManager.LoadScene("SampleScene");
        if (ButtonName == "Ranking")
            SceneManager.LoadScene("Ranking");
    }
}
