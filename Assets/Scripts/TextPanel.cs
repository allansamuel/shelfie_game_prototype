using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextPanel : MonoBehaviour
{
	public GameObject PanelObject;
	public Text TextObject;
	public string TextString;

    // Start is called before the first frame update
    void Start()
    {
        PanelObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetText(string NewText)
    {
    	TextObject.text = NewText;
        PanelObject.SetActive(true);
    }
}
