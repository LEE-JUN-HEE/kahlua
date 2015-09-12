using UnityEngine;
using System.Collections;
using System.Xml;
using System;

public class Obj
{
    public enum MoveType
    {
        LiftDonw = 0,
        LiftUP,
        None
    }
    public enum TiledType
    {
        horizon =0,
        vertical,
        tiled
    }

    public TiledType tType;
    public MoveType mType;
    public Vector2 LeftBot;
    public Vector2 RightTop;

    public virtual void SetData(XmlNode node)
    {
        string[] Splitstr;
        tType = (TiledType)(int.Parse(node.ChildNodes[0].InnerText));
        mType = (MoveType)(int.Parse(node.ChildNodes[1].InnerText));

        Splitstr = node.ChildNodes[2].InnerText.Split(',');
        LeftBot = new Vector2(int.Parse(Splitstr[0]), int.Parse(Splitstr[1]));

        Splitstr = node.ChildNodes[3].InnerText.Split(',');
        RightTop = new Vector2(int.Parse(Splitstr[0]), int.Parse(Splitstr[1]));
    }
}
