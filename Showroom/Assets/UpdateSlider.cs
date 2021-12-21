using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveSlider : MonoBehaviour
{
    public Slider slider;
    public Button buttonBack;
    public Button buttonForward;
    public float sliderStep = 5f;

    void Start()
    {
        buttonBack.onClick.AddListener(delegate { moveSliderBack(); });
        buttonForward.onClick.AddListener(delegate { moveSliderForward(); });
    }

    void moveSliderBack() 
    {
        slider.value -= sliderStep;
    }

    void moveSliderForward() 
    {
        slider.value += sliderStep;
    }
}
