using UnityEngine;
using System.Collections;
using System.Xml;
using System;

public class CObj
{

    public enum TiledType
    {
        none = 0,
        horizon, 
        vertical,
        tiled
    }

    public enum MoveType
    {
        None = 0,
        LiftDonw,
        LiftUP,
    }

    public enum BuildType
    {
        square = 0,
        circle,
        tri,
    }

    public enum GetType
    {
        buff = 0,
        jelly,
    }

    public TiledType tType;
    public MoveType mType;
    public Vector2 LeftBot;
    public Vector2 RightTop;
    public float tilt;

    public virtual void SetData(XmlNode node)
    {
        string[] Splitstr;
        Debug.Log(node.ChildNodes[0].InnerText);
        tType = (TiledType)(int.Parse(node.ChildNodes[0].InnerText));
        mType = (MoveType)(int.Parse(node.ChildNodes[1].InnerText));
        tilt = float.Parse(node.ChildNodes[2].InnerText);

        Splitstr = node.ChildNodes[3].InnerText.Split(',');
        LeftBot = new Vector2(int.Parse(Splitstr[0]), int.Parse(Splitstr[1]));

        Splitstr = node.ChildNodes[4].InnerText.Split(',');
        RightTop = new Vector2(int.Parse(Splitstr[0]), int.Parse(Splitstr[1]));
    }
}
