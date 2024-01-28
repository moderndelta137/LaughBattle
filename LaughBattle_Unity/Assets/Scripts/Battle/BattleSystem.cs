using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleSystem : MonoBehaviour
{
    public static BattleSystem instance;
    public AudioRecorder_v1 recorder_player_1, recorder_player_2;

    public float Player_1_HP, Player_2_HP;
    float vol_player_1, freq_player_1, vol_player_2, freq_player_2;
    bool enableShot_p1 = true, enableShot_p2 = true;
    void Awake()
    {
        instance = this;
        Player_1_HP = 10f;
        Player_2_HP = 10f;
    }

    void Update()
    {
        if(recorder_player_1.isPlaying == true)
        {
            runningBulletShooting_player_1();
        }

        if (recorder_player_2.isPlaying == true)
        {
            runningBulletShooting_player_2();
        }
    }

    void runningBulletShooting_player_1()
    {
        vol_player_1 = recorder_player_1.volume;
        freq_player_1 = recorder_player_1.freq;


        if(enableShot_p1 == true)
        {
            if (vol_player_1 > 0.1f)
            {
                //発射
                enableShot_p1 = false;
            }

        }
        else
        {
            if (vol_player_1 < 0.01f)
            {
                enableShot_p1 = true;

            }

        }
    }

    void runningBulletShooting_player_2()
    {
        vol_player_2 = recorder_player_2.volume;
        freq_player_2 = recorder_player_2.freq;
    }

    public void _playAudio_Player_1()
    {



    }

    public void _playAudio_Player_2()
    {

    }

    public void _Start_Battle()
    {
        _playAudio_Player_1();
        _playAudio_Player_2();
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
