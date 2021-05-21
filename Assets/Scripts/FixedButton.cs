using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityStandardAssets.Characters.ThirdPerson;

public class FixedButton : MonoBehaviour
{

    [HideInInspector]
    public bool Pressed;
    [HideInInspector]
    private QuestAPI API;
    [HideInInspector]
    public string CurrentChildProfile;
    public Transform Player;
    public Transform ActionTarget;
    public TextPanel TextPanelHandler;

    // Use this for initialization
    void Start()
    {
        API = new QuestAPI();
        CurrentChildProfile = API.getIntentData();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void HandleCompleteQuestAction()
    {
    	float distance = Vector3.Distance(Player.position, ActionTarget.transform.position);
    	if(distance <= 2f)
    	{
        	ActionTarget.transform.GetChild(0).GetComponent<Animator>().Play("Open");
        	StartCoroutine(API.CompleteQuestRequest(CurrentChildProfile, ActionTarget.tag));
        	TextPanelHandler.SetText("Assim que Naiá abriu a misteriosa caixa na floresta, seu espírito se preencheu com determinação... Parabéns! Você concluiu com sucesso a missão ");
    	}
    }
}