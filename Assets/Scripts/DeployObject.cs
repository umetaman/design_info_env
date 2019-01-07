using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeployObject : MonoBehaviour {

    [SerializeField]
    private BoxCollider Collider;

    private BaseModel Model;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public BoxCollider GetCollider()
    {
        return Collider;
    }

    public void SetModelData(BaseModel baseModel)
    {
        Model = baseModel;
    }

    public BaseModel GetModelData()
    {
        return Model;
    }
}
