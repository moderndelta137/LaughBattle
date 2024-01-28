using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TransitionManager : MonoBehaviour
{
    public static TransitionManager instance;
    public GameObject TitleScene;

    public GameObject RecordScene;
    float RecordingTimer;
    public TextMeshProUGUI TimerText;
    public float RecordingTimerDefault;
    bool IsRecroding;
    bool Player1Recorded;
    bool Player2Recorded;

    public GameObject BattleScene;
    public GameObject ResultScene;
    public GameObject CreditScene;
    public int WinPlayerIndex;
    public enum SceneState
    {
        Title,
        Record,
        Battle,
        Result,
        Credit,
    }
    public SceneState CurrentState;
    // Start is called before the first frame update

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        CurrentState = SceneState.Title;
        TransitionToTitle();
    }

    // Update is called once per frame
    void Update()
    {
        switch (CurrentState)
        {
            case SceneState.Title:
            if(Input.GetButtonDown("Submit"))
                {
                    TransitionToRecord();
                }
            break;
            case SceneState.Record:
            if(Input.GetButtonDown("Submit"))
                {
                    if(Player1Recorded==true&&Player2Recorded==true)
                    {
                    TransitionToBattle();
                    }
                    else
                    {
                    StartRecording();
                    }
                }
            break;
            case SceneState.Battle:
            if(Input.GetButtonDown("Submit"))
                {
                    //If player's HP is zero
                    TransitionToResult();
                    //If player's HP is not zero
                    //TransitionToRecord();
                }
            break;
            case SceneState.Result:
            if(Input.GetButtonDown("Submit"))
                {
                    TransitionToTitle();
                }
            break;
            case SceneState.Credit:
            if(Input.GetButtonDown("Submit"))
                {
                    TransitionToTitle();
                }
            break;
        }
        if(IsRecroding)
        {
            RecordingTimer -= Time.deltaTime; 
            TimerText.text = RecordingTimer.ToString();
            if(RecordingTimer<=0)
            {
                StopRecording();
            }
        }
    }

    public void TransitionToTitle()
    {
        TitleScene.SetActive(true);
        RecordScene.SetActive(false);
        BattleScene.SetActive(false);
        ResultScene.SetActive(false);
        CreditScene.SetActive(false);
        CurrentState = SceneState.Title;
    }
    public void TransitionToRecord()
    {
        TitleScene.SetActive(false);
        RecordScene.SetActive(true);
        BattleScene.SetActive(false);
        ResultScene.SetActive(false);
        CreditScene.SetActive(false);
        CurrentState = SceneState.Record;
        IsRecroding = false;
        Player1Recorded = false;
        Player2Recorded = false;
    }
    public void StartRecording()
    {
        RecordingTimer = RecordingTimerDefault;
        IsRecroding=true;
    }
    public void StopRecording()
    {
        Player1Recorded = true;
        Player2Recorded = true;
        IsRecroding=false;
    }
    public void TransitionToBattle()
    {
        TitleScene.SetActive(false);
        RecordScene.SetActive(false);
        BattleScene.SetActive(true);
        ResultScene.SetActive(false);
        CreditScene.SetActive(false);
        CurrentState = SceneState.Battle;
    }
    public void TransitionToResult()
    {
        TitleScene.SetActive(false);
        RecordScene.SetActive(false);
        BattleScene.SetActive(false);
        ResultScene.SetActive(true);
        CreditScene.SetActive(false);
        CurrentState = SceneState.Result;
    }
    public void TransitionToCredit()
    {
        TitleScene.SetActive(false);
        RecordScene.SetActive(false);
        BattleScene.SetActive(false);
        ResultScene.SetActive(false);
        CreditScene.SetActive(true);
        CurrentState = SceneState.Credit;
    }
}
