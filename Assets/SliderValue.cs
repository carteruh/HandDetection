using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderValue : MonoBehaviour
{
    public Slider mySlider;
    public static float moveSpeedVal = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        mySlider.onValueChanged.AddListener(delegate { UpdateSlideValue(); });
    }

    // Update is called once per frame
    void UpdateSlideValue()
    {
        Debug.Log(mySlider.value);
        moveSpeedVal = mySlider.value;
    }
}
