using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class ModelViewManager : MonoBehaviour {

    [SerializeField]
    private List<GameObject> ModelPrefabs = new List<GameObject>();

	// Use this for initialization
	void Start () {

        var ViewModels = new List<DeployObject>();

        foreach(var Model in ModelManager.GetInstance().GetModels())
        {
            Debug.Log(Model.GetName());

            foreach(var pref in ModelPrefabs)
            {
                if(pref.gameObject.name == Model.GetPath())
                {
                    pref.gameObject.SetActive(true);
                    pref.gameObject.transform.position = new Vector3(0, 0, 0);
                    pref.gameObject.transform.localRotation = new Quaternion(0, 0, 0, 0);
                    pref.gameObject.GetComponent<DeployObject>().SetModelData(Model);

                    ViewModels.Add(pref.gameObject.GetComponent<DeployObject>());

                    break;
                }
            }
        }

        if(ViewModels[0].GetModelData().GetScale() > ViewModels[1].GetModelData().GetScale())
        {
            float Ratio = (float)ViewModels[0].GetModelData().GetScale() / (float)ViewModels[1].GetModelData().GetScale();

            Debug.Log(Ratio);

            Vector3 s = ViewModels[0].gameObject.transform.localScale;
            s = new Vector3(s.x / Ratio, s.y / Ratio, s.z / Ratio);
            ViewModels[0].gameObject.transform.localScale = s;
        }
        else if (ViewModels[0].GetModelData().GetScale() < ViewModels[1].GetModelData().GetScale())
        {
            float Ratio = (float)ViewModels[1].GetModelData().GetScale() / (float)ViewModels[0].GetModelData().GetScale();

            Vector3 s = ViewModels[1].gameObject.transform.localScale;
            s = new Vector3(s.x / Ratio, s.y / Ratio, s.z / Ratio);
            Debug.Log(Ratio);
            ViewModels[1].gameObject.transform.localScale = s;
        }

        Vector3 SumDiff = new Vector3(0,0,0);

        for(int i = 0; i < 2; i++)
        {
            var Bounds = ViewModels[i].GetCollider().bounds;
            var Diff = Bounds.max - Bounds.min;

            SumDiff += Diff;

            Debug.Log("Diff: " + Diff);

            switch (i)
            {
                case 0:
                    ViewModels[0].gameObject.transform.position += Diff;
                    break;

                case 1:
                    ViewModels[1].gameObject.transform.position -= Diff;
                    break;
            }

            var p = ViewModels[i].gameObject.transform.position;
            p.y = 0;
            p.z = 0;
            ViewModels[i].gameObject.transform.position = p;
        }

        SumDiff /= 2;
        float Dist = SumDiff.magnitude;

        if(Dist < 500)
        {
            float Ratio = 500 / Dist;
            this.gameObject.transform.localScale *= Ratio;
        }
        else if(Dist > 450)
        {
            float Ratio = Dist / 450;
            this.gameObject.transform.localScale /= Ratio;
        }

        Debug.Log("Dist: " + Dist);
    }
	
	// Update is called once per frame
	void Update () {
		if(XRSettings.enabled == false)
        {
            XRSettings.enabled = true;
        }
	}
}
