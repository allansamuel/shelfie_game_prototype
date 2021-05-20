using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCamera : MonoBehaviour
{
    public FixedTouchField TouchField;
	public float Yaxis;
	public float Xaxis;
	public Transform target;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Yaxis += TouchField.TouchDist.x * 0.2f;
        Xaxis -= TouchField.TouchDist.y * 0.2f;

		Vector3 targetRotarion = new Vector3(Xaxis, Yaxis);
		transform.eulerAngles = targetRotarion;
		transform.position = target.position - transform.forward * 4f + transform.up * 1f;

    }	

}
