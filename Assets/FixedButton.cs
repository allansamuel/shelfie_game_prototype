using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class FixedButton : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{

    [HideInInspector]
    public bool Pressed;
    [HideInInspector]
    private QuestAPI API;
    [HideInInspector]
    public string CurrentChildProfile;
    public Transform Player;
    public Transform ActionTarget;

    // Use this for initialization
    void Start()
    {
        API = new QuestAPI();
        CurrentChildProfile = API.getIntentData();
    }

    // Update is called once per frame
    void Update()
    {
        if(Pressed) {
            HandleCompleteQuestAction();
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Pressed = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Pressed = false;
    }

    public void HandleCompleteQuestAction()
    {
        float distance = Vector3.Distance(Player.position, ActionTarget.transform.position);
        if(distance <= 2f) {
            ActionTarget.transform.GetChild(0).GetComponent<Animator>().Play("Open");
            StartCoroutine(API.CompleteQuestRequest(CurrentChildProfile, ActionTarget.tag));
        }
    }
}