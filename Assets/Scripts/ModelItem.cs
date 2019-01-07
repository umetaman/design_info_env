using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ModelItem : MonoBehaviour {

    private BaseModel ModelData;

    [SerializeField]
    private GameObject PreviewCamera;

    [SerializeField]
    private Text ButtonName;
    [SerializeField]
    private GameObject Model;

    [SerializeField]
    private Text NameText;
    [SerializeField]
    private Text ParamText;

    [SerializeField]
    private ModelSelectManager SelectManager;

    public void SetSelectManager(ModelSelectManager _Manager)
    {
        SelectManager = _Manager;
    }

    public void SetModel(GameObject _Model)
    {
        Model = _Model;
    }

    public void SetModelData(BaseModel _Data)
    {
        ModelData = _Data;
        ButtonName.text = _Data.GetName();
    }

    public void SetPreviewCamera(GameObject _Camera)
    {
        PreviewCamera = _Camera;
    }

    public void SetTextObject(Text _Name, Text _Param)
    {
        NameText = _Name;
        ParamText = _Param;
    }

    public BaseModel GetModelData()
    {
        return ModelData;
    }

    private void MoveToModel()
    {
        Hashtable hash = new Hashtable();
        hash.Add("x", Model.transform.position.x);
        hash.Add("time", 0.3f);

        iTween.MoveTo(PreviewCamera, hash);
    }

    public void SetParamText()
    {
        string Param = null;
        string ObjName = null;

        if(ModelData is Building)
        {
            var building = (Building)ModelData;

            ObjName = building.GetName();
            Param += "高さ(Height) : " + building.GetHeight() / 100 + " m\n";
            Param += "面積(Area)   : " + building.GetArea() + " ㎡\n";

        }
        else if(ModelData is Field)
        {
            var field = (Field)ModelData;

            ObjName = field.GetName();
            Param += "面積(Area)   : " + field.GetArea() + " ㎡\n";
        }
        else if(ModelData is BasicObject)
        {
            var basicObj = (BasicObject)ModelData;

            ObjName = basicObj.GetName();
            Param += "高さ(Height) : " + (double)basicObj.GetHeight() / 100 + " m\n";
            Param += "重さ(Weight) : " + basicObj.GetWeight() + " g\n";
        }
        else
        {
            ObjName = "Null";
            Param = "ERROR!!";
        }

        ParamText.text = Param;
        NameText.text = ObjName;
        MoveToModel();
        SelectManager.SetCurrentModel(ModelData);

        var Camera = SelectManager.GetCurrentSelectObject().GetComponent<ModelViewCameraControl>();
        Camera.MoveToObject(Model);
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
