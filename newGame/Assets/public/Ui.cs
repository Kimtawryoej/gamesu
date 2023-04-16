using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Ui : MonoBehaviour
{
    void Start()
    {
    }
    void Update()
    {
    }
    public void ButtonClick()
    {
        GameObject Button = EventSystem.current.currentSelectedGameObject;
        if (Button.name == "StartBattle")
        {
            Debug.Log("Ω√¿€");
        }
    }
}
