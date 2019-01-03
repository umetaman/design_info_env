using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ParamView : MonoBehaviour {

    [SerializeField]
    private Text text;

	// Use this for initialization
	void Start () {
        SetParamText(new BasicObject("りんご", "aaa", 500, 54654));
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetParamText(BaseModel _Model)
    {
        string DisplayText = null;

        if(_Model is BasicObject)
        {
            BasicObject basicObject = (BasicObject)_Model;

            DisplayText += "高さ(Height): " + basicObject.GetHeight() / 100 + " m\n";
            DisplayText += "重さ(Weight): " + basicObject.GetWeight() + " g\n";
        }
        else if(_Model is Building)
        {
            Building building = (Building)_Model;

            DisplayText += "高さ(Height): " + building.GetHeight() / 100 + " m\n";
            DisplayText += "面積(Area)  : " + building.GetArea() + " ㎡\n";
        }
        else if(_Model is Field)
        {
            Field field = (Field)_Model;

            DisplayText += "面積(Area)  : " + field.GetArea() + " ㎡\n";
        }
        else
        {
            DisplayText += "error";
        }

        text.text = DisplayText;

    }
}
