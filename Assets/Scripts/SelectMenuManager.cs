using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SelectMenuManager : MonoBehaviour {

    //[SerializeField]
    private BaseModel[] SelectedModels = new BaseModel[2];
    [SerializeField]
    private ModelSelectManager SelectManager;
    [SerializeField]
    private Button SubmitButton;

	// Use this for initialization
	void Start () {
        XRSettings.enabled = false;

        for(int i = 0; i < SelectedModels.Length; i++)
        {
            SelectedModels[i] = null;
        }
        CheckSelected();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void CallModelSelectMenu(GameObject _Object)
    {
        SelectManager.gameObject.SetActive(true);
        SelectManager.SetCurrentSelectObject(_Object);
    }

    public void CheckSelected()
    {
        if(SelectedModels[0] != null && SelectedModels[1] != null)
        {
            SubmitButton.interactable = true;
        }
        else
        {
            SubmitButton.interactable = false;
        }
    }

    public void SetSelectedModel(GameObject _Current, BaseModel _Model)
    {
        switch (_Current.name)
        {
            case "Object(A)":
                SelectedModels[0] = _Model;
                break;

            case "Object(B)":
                SelectedModels[1] = _Model;
                break;
        }
    }

    public void LoadModelView()
    {
        ModelManager.GetInstance().Clear();
        ModelManager.GetInstance().SetModels(SelectedModels);
        SceneManager.LoadScene("ModelView");
    }
}
