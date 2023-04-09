using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeBar : SingleTone<TimeBar>
{
    [SerializeField]
    Slider TimeSlider;
   public  float  TimeSliderSet { get => TimeSlider.value; }
    float SliderValue;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SliderValue = TimeSlider.value;
    }
}
