using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class RecordSystme : MonoBehaviour
{
    public AudioRecorder_v1 recorder_player_1, recorder_player_2;
    public CounterBox countBox_p1, countBox_p2;
    public Slider audioBar_p1, audioBar_p2;
    bool finished_p1_once = true, finished_p2_once = true;
    public Animator anim_p1, anim_p2;
    void OnEnable()
    {
        finished_p1_once = true;
        finished_p2_once = true;
        countBox_p1.initialNum = recorder_player_1.lengthInSeconds;
        countBox_p2.initialNum = recorder_player_2.lengthInSeconds;
        audioBar_p1.value = 0;
        audioBar_p2.value = 0;
    }


    void Update()
    {
        if(recorder_player_1.finished_recording == true)
        {
            if(finished_p1_once == true)
            {
                Invoke("_moveCam", 1f);
                finished_p1_once = false;
            }
        }

        if (recorder_player_2.finished_recording == true)
        {
            if (finished_p2_once == true)
            {
                //_finish_allRecording();
                Invoke("_finish_allRecording", 1f);
                finished_p2_once = false;
            }
        }

        if (recorder_player_1.isRecording == true)
        {
            audioBar_p1.value = recorder_player_1.count;
            countBox_p1._updateCountNum(recorder_player_1._count);
        }

        if (recorder_player_2.isRecording == true)
        {
            audioBar_p2.value = recorder_player_2.count;
            countBox_p2._updateCountNum(recorder_player_2._count);

        }

    }

    void _moveCam()
    {
        MainCamera_Record.instance._move_to_Player2Pos();

    }

    void _finish_allRecording()
    {
        Debug.Log("finish all recording");
        TransitionManager.instance.TransitionToBattle();
    }

    public void _startRecording_Player_1()
    {
        recorder_player_1.StartRecording();
        anim_p1.Play("Recording_P1");
    }

    public void _startRecording_Player_2()
    {
        recorder_player_2.StartRecording();
        anim_p2.Play("Recording_P2");

    }


}
