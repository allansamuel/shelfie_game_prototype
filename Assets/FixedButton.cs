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
    public Transform Player;
    public Transform ActionTarget;

    // Use this for initialization
    void Start()
    {
        API = new QuestAPI();
    }

    // Update is called once per frame
    void Update()
    {
        if(Pressed) {
            HandleAction();
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

    public void HandleAction()
    {
        float distance = Vector3.Distance(Player.position, ActionTarget.transform.position);
        if(distance <= 2f) {
            ActionTarget.transform.GetChild(0).GetComponent<Animator>().Play("All");
            StartCoroutine(API.CompleteQuestRequest(int.Parse(ActionTarget.tag)));
        }
    }

}