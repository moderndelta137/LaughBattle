using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioBar : MonoBehaviour
{

    Slider mySlider;

    void Start()
    {
        mySlider = GetComponent<Slider>();
    }

    public void changeBarValue(float v)
    {
        mySlider.value = v;
    }


    void Update()
    {
        
    }
}
