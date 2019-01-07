using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ModelViewCameraControl : MonoBehaviour {

    [SerializeField]
    private GameObject Camera;
    [SerializeField]
    private RawImage RenderTexture;

    // Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void MoveToObject(GameObject _TargetObject)
    {
        Camera.transform.position = new Vector3(
            _TargetObject.transform.position.x,
            Camera.transform.position.y,
            Camera.transform.position.z);
    }

    public RawImage GetRenderTexture()
    {
        return RenderTexture;
    }
}
