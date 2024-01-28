using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleSceneManager_Test : MonoBehaviour
{
    public BattleSystem battleSystem;
    public AudioRecorder_v1 recorder_player_1, recorder_player_2;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetKeyDown(KeyCode.Alpha1))
		{
            recorder_player_1.StartRecording();

        }
		if (Input.GetKeyDown(KeyCode.Alpha2))
		{
            recorder_player_2.StartRecording();
        }
        if (Input.GetKeyDown(KeyCode.Space))
		{
			battleSystem._Start_Battle();
            Debug.Log("StartBattle");
		}

	}
}
