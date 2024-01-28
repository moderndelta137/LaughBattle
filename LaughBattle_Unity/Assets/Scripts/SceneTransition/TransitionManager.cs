using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionManager : MonoBehaviour
{
    public GameObject TitleScene;
    public GameObject RecordScene;
    public GameObject BattleScene;
    public GameObject ResultScene;
    public GameObject CreditScene;
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
                    TransitionToBattle();
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
    }

    void TransitionToTitle()
    {
        TitleScene.SetActive(true);
        RecordScene.SetActive(false);
        BattleScene.SetActive(false);
        ResultScene.SetActive(false);
        CreditScene.SetActive(false);
        CurrentState = SceneState.Title;
    }
    void TransitionToRecord()
    {
        TitleScene.SetActive(false);
        RecordScene.SetActive(true);
        BattleScene.SetActive(false);
        ResultScene.SetActive(false);
        CreditScene.SetActive(false);
        CurrentState = SceneState.Record;
    }
    void TransitionToBattle()
    {
        TitleScene.SetActive(false);
        RecordScene.SetActive(false);
        BattleScene.SetActive(true);
        ResultScene.SetActive(false);
        CreditScene.SetActive(false);
        CurrentState = SceneState.Battle;
    }
    void TransitionToResult()
    {
        TitleScene.SetActive(false);
        RecordScene.SetActive(false);
        BattleScene.SetActive(false);
        ResultScene.SetActive(true);
        CreditScene.SetActive(false);
        CurrentState = SceneState.Result;
    }
    void TransitionToCredit()
    {
        TitleScene.SetActive(false);
        RecordScene.SetActive(false);
        BattleScene.SetActive(false);
        ResultScene.SetActive(false);
        CreditScene.SetActive(true);
        CurrentState = SceneState.Credit;
    }
}
