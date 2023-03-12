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
        if (CompareTag("UI2"))
        {
            Debug.Log("√º¿Œ¡ˆ");
            InputManager.Instance.animator.SetBool("change", true);
        }
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
        if (CompareTag("UI"))
        {
            transform.position = Camera.main.WorldToScreenPoint(new Vector3(Player.Instance.transform.position.x + -0.9f, Player.Instance.transform.position.y + 5, Player.Instance.transform.position.z));
        }
        if (CompareTag("UI2"))
        {
            transform.position = Camera.main.WorldToScreenPoint(new Vector3(Player.Instance.transform.position.x + 0.5f, Player.Instance.transform.position.y + 5, Player.Instance.transform.position.z));
        }
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
