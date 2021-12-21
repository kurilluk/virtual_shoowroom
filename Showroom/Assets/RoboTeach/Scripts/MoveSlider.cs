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

    public TextMeshProUGUI sliderText;

    // Start is called before the first frame update
    void Start()
    {
        //string name = sliderText.text;
        //sliderText = FindObjectOfType<TextMeshProUGUI>();
        slider.onValueChanged.AddListener(delegate { DisplaySliderText(); });

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
    void DisplaySliderText() 
    {
        
        string text = Mathf.Round(slider.value).ToString();
        sliderText.text = text;
    }
}
