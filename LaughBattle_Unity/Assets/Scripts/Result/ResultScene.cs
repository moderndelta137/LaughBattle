using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultScene : MonoBehaviour
{
    public GameObject win_1, win_2;
    public Animator win_1_p1, win_1_p2, win_2_p1, win_2_p2;
    void Start()
    {
        
    }

    private void OnEnable()
    {
        if(TransitionManager.instance.WinPlayerIndex == 1)
        {
            win_1.SetActive(true);
            win_2.SetActive(false);
            win_1_p1.Play("Win_P");
            win_1_p2.Play("Hit_P2_loop");

        }
        else
        {
            win_1.SetActive(false);
            win_2.SetActive(true);
            win_2_p2.Play("Win_P");
            win_2_p1.Play("Hit_P1_loop");

        }
    }

    //// Update is called once per frame
    //void Update()
    //{
        
    //}
}
