using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class PlayerControl : MonoBehaviour {

    private int Width;
    private int Height;
    private Vector2Int ScreenSize;

    [SerializeField]
    private Vector3 MoveVectorScale = new Vector3(0.03f, 0.03f, 0.03f);

	// Use this for initialization
	void Start () {
        //スクリーンの大きさ取得
        Width = Screen.width;
        Height = Screen.height;

        ScreenSize = new Vector2Int(Width, Height);

        Debug.Log("ScreenSize: (" + Width + ", " + Height + ")");
	}
	
	// Update is called once per frame
	void Update () { 
        //マウスの座標
        Vector2 MousePosition = Input.mousePosition;

        Vector2 MappedVec = new Vector2(
            Map(MousePosition.x, 0, Width, -1, 1),
            Map(MousePosition.y, 0, Height, -1, 1)
        );

        if(MappedVec.x < 0)
        {
            MappedVec.x = -MoveVectorScale.x * (MappedVec.x * MappedVec.x);
        }
        else if(MappedVec.x > 0)
        {
            MappedVec.x = MoveVectorScale.x * (MappedVec.x * MappedVec.x);
        }

        if (MappedVec.y < 0)
        {
            MappedVec.y = -MoveVectorScale.y * (MappedVec.y * MappedVec.y);
        }
        else if (MappedVec.y > 0)
        {
            MappedVec.y = MoveVectorScale.y * (MappedVec.y * MappedVec.y);
        }

        Debug.Log("MappedVec: " + MappedVec);

        transform.position = new Vector3(
            transform.position.x + MappedVec.x,
            transform.position.y + MappedVec.y,
            -10
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
}
