using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Ui : MonoBehaviour
{
    public static Ui Instance;
    [SerializeField]
    private Slider slider;
    [SerializeField]
    private Slider slider2;
    Player player = new Player();
    Hit hit = new Hit();
    public Text countText;
    
    // Start is called before the first frame update
    void Start()
    {
       
        //player = Player.Instance;
      Instance = this;
        
    }

    // Update is called once per frame
    void Update()
    {
        
        
        slider.value = (float)Public.Instance.datas.hp / (float)15;
        slider2.value = (float)Public.Instance.datas.pain / (float)5;
        countText.text = "Count:" + Public.Instance.datas.score[0];
    }

     
}
