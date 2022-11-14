using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ui : MonoBehaviour
{
    [SerializeField]
    private Slider slider;
    [SerializeField]
    private Slider slider2;
    Player player = new Player();
    Hit hit = new Hit();
    // Start is called before the first frame update
    void Start()
    {
        //player = Player.Instance;
      
        
    }

    // Update is called once per frame
    void Update()
    {
        
        
        slider.value = (float)Player.Instance.hp / (float)3;
        slider2.value = (float)Player.Instance.pain / (float)5;
    }

     
}
