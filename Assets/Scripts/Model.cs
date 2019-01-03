using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseModel
{
    private static int _ID;

    private int ID;
    private string Name;
    private string Path;

    public BaseModel(string _Name, string _Path)
    {
        ID = _ID;
        Name = _Name;
        Path = _Path;
        _ID++;
    }

    public int GetID()
    {
        return ID;
    }

    public string GetName()
    {
        return Name;
    }

    public string GetPath()
    {
        return Path;
    }
}

public class Building : BaseModel
{
    private uint Height;
    private uint Area;

    public Building(string _Name, string _Path, uint _Height, uint _Area) : base(_Name, _Path)
    {
        Height = _Height;
        Area = _Area;
    }

    public uint GetHeight()
    {
        return Height;
    }

    public uint GetArea()
    {
        return Area;
    }
}

public class Field : BaseModel
{
    private ulong Area;

    public Field(string _Name, string _Path, ulong _Area) : base(_Name, _Path)
    {
        Area = _Area;
    }

    public ulong GetArea()
    {
        return Area;
    }
}

public class BasicObject : BaseModel
{
    private uint Height;
    private ulong Weight;

    public BasicObject(string _Name, string _Path, uint _Height, ulong _Weight) : base(_Name, _Path)
    {
        Height = _Height;
        Weight = _Weight;
    }

    public uint GetHeight()
    {
        return Height;
    }

    public ulong GetWeight()
    {
        return Weight;
    }
}

public class Model : MonoBehaviour {

    private List<BaseModel> Models = new List<BaseModel>();

	// Use this for initialization
	void Start () {
        Models = new List<BaseModel>()
        {
            new Building("東京ドーム", "TokyoDome", 6169, 46755),
            new Building("東京タワー", "TokyoTower", 33300, 4470),
            new Building("東京スカイツリー", "TokyoSkyTree", 63400, 31832),
            new Field("甲子園", "Koshien", 38500),
            new Field("宮城県", "Miyagi", 7282240000),
            new Field("仙台市", "Sendai", 786300000),
            new Field("宮城大学", "MYU", 35975),
            new Field("琵琶湖", "biwako", 669260000),
            new Field("バチカン市国", "bachikan", 440000),
            new BasicObject("りんご", "apple", 15, 520),
            //new BasicObject("地球", "earth", 1274200000, 5972600000000000018874368),
        };
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
