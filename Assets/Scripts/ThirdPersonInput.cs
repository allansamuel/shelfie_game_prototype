using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

public class ThirdPersonInput : MonoBehaviour
{
    protected ThirdPersonUserControl Control;
	public FixedJoystick LeftJoystick;
	public FixedTouchField TouchField;
	public FixedButton Button;

    // Start is called before the first frame update
    void Start()
    {
        Control = GetComponent<ThirdPersonUserControl>();
    }

    // Update is called once per frame
    void Update()
    {
        Control.Hinput = LeftJoystick.input.x;
        Control.Vinput = LeftJoystick.input.y;
    }

}
