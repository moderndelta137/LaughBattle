using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecordSystme : MonoBehaviour
{
    public AudioRecorder_v1 recorder_player_1, recorder_player_2;
    bool finished_p1_once = true, finished_p2_once = true;
    void Start()
    {
        
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
                _finish_allRecording();
                //Invoke("_finish_allRecording()", 1f);
                finished_p2_once = false;
            }
        }
    }

    void _moveCam()
    {
        MainCamera_Record.instance._move_to_Player2Pos();

    }

    void _finish_allRecording()
    {
        Debug.Log("finish all recording");
    }

    public void _startRecording_Player_1()
    {
        recorder_player_1.StartRecording();
    }

    public void _startRecording_Player_2()
    {
        recorder_player_2.StartRecording();
    }


}
