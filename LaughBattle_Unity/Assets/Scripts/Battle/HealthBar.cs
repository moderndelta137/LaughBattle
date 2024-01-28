using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    Transform bar_inside_tf;
    float normarizedHP;
    // Start is called before the first frame update
    void Start()
    {
        bar_inside_tf = transform.GetChild(0);
    }


    void Update()
    {
    }

    public void _changingBarState(float currentHP)
    {
        normarizedHP = currentHP.Map(0, 10, 0, 1);
        //current_HP = 
        bar_inside_tf.localScale = new Vector3(normarizedHP, 1, 1);

    }

}
