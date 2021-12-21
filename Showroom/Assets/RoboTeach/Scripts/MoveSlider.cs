using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MoveSlider : MonoBehaviour
{
    public Slider slider;
    public Button buttonMinus;
    public Button buttonPlus;
    public float sliderStep = 5f;

    public TextMeshPro sliderText;

    // Start is called before the first frame update
    void Start()
    {
        sliderText = FindObjectOfType<TextMeshPro>();

        buttonMinus.onClick.AddListener(delegate { DecreaseSlider(); });
        buttonPlus.onClick.AddListener(delegate { IncreaseSlider(); });
    }

    void DecreaseSlider() 
    {
        slider.value -= sliderStep;
    }
    void IncreaseSlider() 
    {
        slider.value += sliderStep;
    }
}
