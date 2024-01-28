using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleSystem : MonoBehaviour
{
    public static BattleSystem instance;

    public float Player_1_HP, Player_2_HP;

    void Awake()
    {
        instance = this;
        Player_1_HP = 10f;
        Player_2_HP = 10f;
    }

    void Update()
    {
        
    }

    public void _startRecording_Player_1()
    {

    }

    public void _startRecording_Player_2()
    {

    }

    public void _Start_Battle()
    {

    }

    public void _calculateDamage(int Player,int damage)
    {
        if(Player == 1)
        {
            Player_1_HP -= 1;
        }
        else if (Player == 2)
        {
            Player_2_HP -= 1;

        }
    }

}
