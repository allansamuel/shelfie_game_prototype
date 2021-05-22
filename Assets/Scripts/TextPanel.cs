using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextPanel : MonoBehaviour
{
	[HideInInspector]
	public string TextString;
	public Text TextObject;
	public GameObject PanelObject;
	public GameObject LeftJoystick;
	public GameObject TouchField;
	public GameObject ActionButton;
	public GameObject PanelButton;
	public GameObject CloseButton;

    // Start is called before the first frame update
    void Start()
    {
        PanelObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        ToggleControllers();
    }

    public void SetText(string NewText)
    {
    	TextObject.text = NewText;
        PanelObject.SetActive(true);
    }

	public void HidePanel()
    {
        PanelObject.SetActive(false);
        ToggleControllers();
    }

    public void ToggleControllers()
    {
    	if(PanelObject.activeSelf)
    	{
        	LeftJoystick.SetActive(false);
        	TouchField.SetActive(false);
        	ActionButton.SetActive(false);
        	CloseButton.SetActive(false);
    	}
    	else
    	{
        	LeftJoystick.SetActive(true);
        	TouchField.SetActive(true);
        	ActionButton.SetActive(true);
        	CloseButton.SetActive(true);
    	}
    }
}
