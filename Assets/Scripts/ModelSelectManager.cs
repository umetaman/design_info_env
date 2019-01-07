using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ModelSelectManager : MonoBehaviour {

    private List<BaseModel> Models;

    [SerializeField]
    private GameObject ItemPrefab;

    [SerializeField]
    private Text NameText;
    [SerializeField]
    private Text ParamText;
    [SerializeField]
    private GameObject ScrollViewContent;
    [SerializeField]
    private GameObject ModelHolder;
    [SerializeField]
    private GameObject PreviewCamera;
    [SerializeField]
    private GameObject CurrentSelectObject;
    [SerializeField]
    private BaseModel CurrentModel;
    [SerializeField]
    private SelectMenuManager MenuManager;

    public void SetCurrentModel(BaseModel _Model)
    {
        CurrentModel = _Model;
    }

    public void SetCurrentSelectObject(GameObject _Object)
    {
        CurrentSelectObject = _Object;
    }

    public GameObject GetCurrentSelectObject()
    {
        return CurrentSelectObject;
    }

    public void DecideModel()
    {
        var RenderTex = CurrentSelectObject.GetComponent<ModelViewCameraControl>().GetRenderTexture();
        RenderTex.gameObject.SetActive(true);

        MenuManager.SetSelectedModel(CurrentSelectObject, CurrentModel);

        CurrentSelectObject = null;
        this.gameObject.SetActive(false);
    }

	// Use this for initialization
	void Start () {
        Models = new List<BaseModel>()
        {
            new Building("東京ドーム", "TokyoDome", 6169, 46755, 0.0004),
            new Building("東京タワー", "TokyoTower", 33300, 4470, 0.0004),
            new Building("東京スカイツリー", "TokyoSkyTree", 63400, 31832, 0.0004),
            new Field("甲子園", "Koshien", 38500, 0.0004),
            new Field("宮城県", "Miyagi", 7282240000, 0.0004),
            new Field("仙台市", "Sendai", 786300000, 0.0004),
            new Field("琵琶湖", "Biwako", 669260000, 0.0004),
            new Field("バチカン市国", "Vatican", 440000, 0.0006),
            new BasicObject("りんご", "Apple", 15, 520, 0.3333),
        };

        var PreviewModels = ModelHolder.GetComponentsInChildren<PreviewModel>();

        foreach(var Model in Models)
        {
            GameObject ItemObject = Instantiate(ItemPrefab, ScrollViewContent.transform);
            ItemObject.GetComponent<ModelItem>().SetModelData(Model);
            ItemObject.GetComponent<ModelItem>().SetTextObject(NameText, ParamText);
            ItemObject.GetComponent<ModelItem>().SetPreviewCamera(PreviewCamera);
            ItemObject.GetComponent<ModelItem>().SetSelectManager(this);

            foreach(var m in PreviewModels)
            {
                if(m.gameObject.name == Model.GetPath())
                {
                    ItemObject.GetComponent<ModelItem>().SetModel(m.gameObject);
                    break;
                }
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    
}
