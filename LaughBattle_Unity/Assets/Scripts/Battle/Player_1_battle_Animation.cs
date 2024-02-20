using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_1_battle_Animation : MonoBehaviour
{
    public static Player_1_battle_Animation instance;
    Animator anim;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }



    public void _playHitAnim()
    {
        anim.Play("Hit_P1");
    }

    public void _playAttackAnim()
    {
        anim.Play("Attack_P1");
    }


}
