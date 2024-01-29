using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CounterBox : MonoBehaviour
{
    TextMeshProUGUI tmp;
    public float initialNum;
    public AudioRecorder_v1 recorder;
    void Start()
    {
        tmp = transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        tmp.text = recorder.lengthInSeconds.ToString();
    }

    public void _updateCountNum(float num)
    {
        float calculatedNum = initialNum - num;
        tmp.text = calculatedNum.ToString("F1");
    }

    void Update()
    {
        
    }
}
