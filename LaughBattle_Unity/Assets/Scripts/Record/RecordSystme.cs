using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecordSystme : MonoBehaviour
{
    public AudioRecorder_v1 recorder_player_1, recorder_player_2;

    void Start()
    {
        
    }

    void Update()
    {
        
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
