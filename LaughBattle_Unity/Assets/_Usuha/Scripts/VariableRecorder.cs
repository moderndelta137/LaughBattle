
using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class VariableRecorder : MonoBehaviour
{
    public float variable_Player1,variable_Player2; // これが記録する変数
    public float recordDuration = 3f; // 記録する秒数
    private List<VariableSnapshot> snapshots_1 = new List<VariableSnapshot>();
    private List<VariableSnapshot> snapshots_2 = new List<VariableSnapshot>();
    private bool isRecording = false;

    public AudioBar audioBar_1, audioBar_2;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            StartRecording_1();
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            StartRecording_2();
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            StartCoroutine(ReplayVariable_Player_1());
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            StartCoroutine(ReplayVariable_Player_2());
        }
    }

    public void StartRecording_1()
    {
        if (!isRecording)
        {
            isRecording = true;
            StartCoroutine(RecordVariable_Player_1());
        }
    }

    public void StartRecording_2()
    {
        if (!isRecording)
        {
            isRecording = true;
            StartCoroutine(RecordVariable_Player_2());
        }
    }

    float startTime;
    IEnumerator RecordVariable_Player_1()
    {
        startTime = Time.time;
        while (Time.time - startTime <= recordDuration)
        {
            float normalizedTime = (Time.time - startTime) / recordDuration;
            audioBar_1.changeBarValue(normalizedTime);

            snapshots_1.Add(new VariableSnapshot(Time.time - startTime, variable_Player1));
            Debug.Log("Recording_" + variable_Player1);
            //Debug.Log("normalizedTime" + normalizedTime);
            yield return null;
        }
        isRecording = false;
    }

    IEnumerator RecordVariable_Player_2()
    {
        startTime = Time.time;
        while (Time.time - startTime <= recordDuration)
        {
            float normalizedTime = (Time.time - startTime) / recordDuration;
            audioBar_2.changeBarValue(normalizedTime);

            snapshots_2.Add(new VariableSnapshot(Time.time - startTime, variable_Player2));
            Debug.Log("Recording_" + variable_Player2);
            yield return null;
        }
        isRecording = false;
    }



    public IEnumerator ReplayVariable_Player_1()
    {
        float startTime = Time.time;
        float totalDuration = snapshots_1[snapshots_1.Count - 1].time; // 最後のスナップショットの時間が全体の再生時間

        foreach (var snapshot in snapshots_1)
        {
            variable_Player1 = snapshot.value;

            // 現在の経過時間を全体の再生時間で割って正規化
            float normalizedTime = (Time.time - startTime) / totalDuration;
            normalizedTime = Mathf.Clamp(normalizedTime, 0, 1); // 値を0から1の範囲に制限
            audioBar_1.changeBarValue(normalizedTime);

            yield return new WaitForSeconds(snapshot.time - (Time.time - startTime));
        }
    }

    public IEnumerator ReplayVariable_Player_2()
    {
        float startTime = Time.time;
        float totalDuration = snapshots_2[snapshots_2.Count - 1].time; // 最後のスナップショットの時間が全体の再生時間

        foreach (var snapshot in snapshots_2)
        {
            variable_Player2 = snapshot.value;

            // 現在の経過時間を全体の再生時間で割って正規化
            float normalizedTime = (Time.time - startTime) / totalDuration;
            normalizedTime = Mathf.Clamp(normalizedTime, 0, 1); // 値を0から1の範囲に制限
            audioBar_2.changeBarValue(normalizedTime);

            yield return new WaitForSeconds(snapshot.time - (Time.time - startTime));
        }
    }

}
