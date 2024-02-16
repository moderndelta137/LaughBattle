using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class BattleSystem : MonoBehaviour
{
	public static BattleSystem instance;
    public BulletGenerator bulletGenerator;
    public AudioRecorder_v1 recorder_player_1, recorder_player_2;
    public HealthBar healthBar_player_1, healthBar_player_2;
    public SpriteRenderer playButton;
    public float Player_1_HP, Player_2_HP;
    public float vol_player_1, freq_player_1, vol_player_2, freq_player_2;
    bool enableShot_p1 = true, enableShot_p2 = true;
    float battleTimeDuration;
    public Animator CameraAnimator;
    public Animator P1HPBarAnimator;
    public Animator P2HPBarAnimator;
    public GameObject PlayerHitVFX;
    public GameObject BulletHitVFX;

    void Awake()
    {
        instance = this;
        Player_1_HP = 10f;
        Player_2_HP = 10f;
        battleTimeDuration = recorder_player_1.lengthInSeconds;
    }

    private void OnEnable()
    {
        playButton.enabled = true;

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

        healthBarFunction();
        checkingHP();
    }

    void healthBarFunction()
    {
        healthBar_player_1._changingBarState(Player_1_HP);
        healthBar_player_2._changingBarState(Player_2_HP);
    }

    void checkingHP()
    {
        if(Player_1_HP <= 0)
        {

        }

        if (Player_2_HP <= 0)
        {

        }
    }

    void runningBulletShooting_player_1()
    {
        vol_player_1 = recorder_player_1.volume;
        freq_player_1 = recorder_player_1.freq;


        if(enableShot_p1 == true)
        {
            if (vol_player_1 > 0.2f)
            {
                bulletGenerator._emit_bullet_player_1(freq_player_1,vol_player_1*2f);
				enableShot_p1 = false;
                Debug.Log(freq_player_1);
			}
		}
        else
        {
            if (vol_player_1 < 0.1f)
            {
                enableShot_p1 = true;

            }
		}
	}

	void runningBulletShooting_player_2()
	{
		vol_player_2 = recorder_player_2.volume;
		freq_player_2 = recorder_player_2.freq;

        if (enableShot_p2 == true)
        {
            if (vol_player_2 > 0.2f)
            {
                bulletGenerator._emit_bullet_player_2(freq_player_2, vol_player_2*2f);
				enableShot_p2 = false;
                Debug.Log(freq_player_2);
            }
		}
        else
        {
            if (vol_player_2 < 0.1f)
            {
                enableShot_p2 = true;

            }
        }
    }

	public void _playAudio_Player_1()
    {
        recorder_player_1.PlayRecording();
    }

    public void _playAudio_Player_2()
    {
        recorder_player_2.PlayRecording();
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

    public void _push_startBattleButton()
    {
        //SE.instance._playOneShot(2);
        playButton.enabled = false;
        _Start_Battle();
        Invoke("_checkResult", battleTimeDuration + 1);
    }

    void _checkResult()
    {
        if(Player_1_HP > Player_2_HP)
        {
            TransitionManager.instance.WinPlayerIndex = 1;

        } else if (Player_1_HP < Player_2_HP)
        {
            TransitionManager.instance.WinPlayerIndex = 2;

        }
        else
        {
            //本来は引き分け
            TransitionManager.instance.WinPlayerIndex = 1;
        }

        Invoke("transition", 3f);
    }

    void transition()
    {
        if(Player_1_HP<=0 ||Player_2_HP<=0)
            TransitionManager.instance.TransitionToResult();
        else
            TransitionManager.instance.TransitionToRecord();
    }

    public void CameraShakeR()
    {
        CameraAnimator.SetTrigger("CameraShake_r");
    }
    public void CameraShakeL()
    {
        CameraAnimator.SetTrigger("CameraShake_l");
    }
    public void P1HPBarAnimation()
    {
        P1HPBarAnimator.SetTrigger("HPDamage");
    }
    public void P2HPBarAnimation()
    {
        P2HPBarAnimator.SetTrigger("HPDamage");
    }

    public void PlayPlayerHitVFX(Vector2 Loc)
    {
        Vector3 loc3 = new Vector3(Loc.x,Loc.y, -3f);
        Instantiate(PlayerHitVFX,loc3,quaternion.Euler(0,0,0));

    }
    public void PlayBulletHitVFX(Vector2 Loc)
    {
        Vector3 loc3 = new Vector3(Loc.x,Loc.y, -3f);
        Instantiate(BulletHitVFX,Loc,quaternion.Euler(0,0,0));

    }

}
