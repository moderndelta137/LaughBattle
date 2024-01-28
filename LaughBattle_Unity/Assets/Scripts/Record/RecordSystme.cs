using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecordSystme : MonoBehaviour
{
    public AudioRecorder_v1 recorder_player_1, recorder_player_2;
    public bool _done_rec_p1 = false, _done_rec_p2 = false;

    void Start()
    {
        
    }

    void Update()
    {
        if(recorder_player_1.isRecording == true)
        {

        }
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
