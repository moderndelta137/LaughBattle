using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CounterBox : MonoBehaviour
{
    TextMeshProUGUI tmp;
    public float initialNum;
    void Start()
    {
        tmp = transform.GetChild(0).GetComponent<TextMeshProUGUI>();
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
