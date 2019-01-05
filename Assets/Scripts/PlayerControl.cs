using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class PlayerControl : MonoBehaviour {

    [SerializeField]
    private Vector3 MoveVectorScale = new Vector3(0.03f, 0.03f, 0.03f);

	// Use this for initialization
	void Start () {
        UnityEngine.XR.XRSettings.enabled = false;
    }
	
	// Update is called once per frame
	void Update () {
        Vector3 InputAxis = GetJoyConAxis();

        //text.text = InputAxis.ToString();

        transform.position = new Vector3(
            transform.position.x + InputAxis.x * MoveVectorScale.x,
            transform.position.y + InputAxis.y * MoveVectorScale.y,
            transform.position.z + InputAxis.z * MoveVectorScale.z
        );
    }

    public float Map(float Value, float InputMin, float InputMax, float OutputMin, float OutputMax)
    {
        if(Value < InputMin)
        {
            Value = InputMin;
        }

        if(Value > InputMax)
        {
            Value = InputMax;
        }

        return ((Value - InputMin) / (InputMax - InputMin)) * (OutputMax - OutputMin) + OutputMin;
    }

    public Vector3 GetJoyConAxis()
    {
        float x = 0.0f;
        float y = 0.0f;
        float z = 0.0f;

        if (Input.GetKey(KeyCode.Joystick1Button13))
        {
            z = 1.0f;
        }

        if (Input.GetKey(KeyCode.Joystick1Button1))
        {
            z = -1.0f;
        }

        x = Input.GetAxis("Axis 6");
        y = Input.GetAxis("Axis 5");

        return new Vector3(x * -1, y * -1, z);
    }
}
