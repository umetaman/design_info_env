using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreviewModel : MonoBehaviour {

    [SerializeField]
    private static Vector3 Rotation = new Vector3(0, 0.4f, 0);

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.Rotate(Rotation);
	}
}
