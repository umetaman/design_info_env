using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelManager : MonoBehaviour
{

    private static ModelManager mInstance;
    private void Awake()
    {

        if (mInstance == null)
        {
            mInstance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public static ModelManager GetInstance()
    {
        return mInstance;
    }

    private BaseModel[] Models;

    public void SetModels(BaseModel[] _Models)
    {
        Models = _Models;

        foreach(var m in _Models)
        {
            Debug.Log(m.GetName());
        }
    }

    public void Clear()
    {
        Models = new BaseModel[2];
    }

    public BaseModel[] GetModels()
    {
        return Models;
    }
}
