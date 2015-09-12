using UnityEngine;
using System.Collections;

public class Obj_Build : Obj
{
    public enum BuildType
    {
        square = 0,
        circle,
        sphere
    }

    Vector2 LeftTop;
    Vector2 RightBot;
    BuildType BType;

    public override void SetData(System.Xml.XmlNode node)
    {
        base.SetData(node);
        string[] Splitstr;

        Splitstr = node.ChildNodes[4].InnerText.Split(',');
        LeftBot = new Vector2(int.Parse(Splitstr[0]), int.Parse(Splitstr[1]));

        Splitstr = node.ChildNodes[5].InnerText.Split(',');
        RightTop = new Vector2(int.Parse(Splitstr[0]), int.Parse(Splitstr[1]));

        BType = (BuildType)int.Parse(node.ChildNodes[4].InnerText);
    }
}
