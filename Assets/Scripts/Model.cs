using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class BaseModel
{
    private static int _ID;

    private int ID;
    private string Name;
    private string Path;
    private double Scale;

    public BaseModel(string _Name, string _Path, double _Scale)
    {
        ID = _ID;
        Name = _Name;
        Path = _Path;
        Scale = _Scale;
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

    public double GetScale()
    {
        return Scale;
    }
}

public class Building : BaseModel
{
    private uint Height;
    private uint Area;

    public Building(string _Name, string _Path, uint _Height, uint _Area, double _Scale) : base(_Name, _Path, _Scale)
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

    public Field(string _Name, string _Path, ulong _Area, double _Scale) : base(_Name, _Path, _Scale)
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

    public BasicObject(string _Name, string _Path, uint _Height, ulong _Weight, double _Scale) : base(_Name, _Path, _Scale)
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

