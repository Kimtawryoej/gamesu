using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Ui : MonoBehaviour, IPointerEnterHandler
{
    public static Ui Instance;
    public Button Lbutton;
    Image Image;
    public Sprite changeIMG;
    public Sprite NowIMG;
    Button button;
    public void OnClickButton()
    {

    }
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        Image = GetComponent<Image>();
        button = GetComponent<Button>();
        button.onClick.AddListener(OnClickButton);
    }
    private void Update()
    {
        if (!EventSystem.current.IsPointerOverGameObject())
        {
            Image.sprite = NowIMG;

        }
    }
    public void OnPointerEnter(PointerEventData eventData)
    {


        Image.sprite = changeIMG;

    }
}
