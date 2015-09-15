using UnityEngine;
using System.Collections;

public class CObj_Get : CObj {
    Vector2 LeftTop;
    Vector2 RightBot;
    GetType GType;

    public override void SetData(System.Xml.XmlNode node)
    {
        base.SetData(node);
        string[] Splitstr;

        Splitstr = node.ChildNodes[5].InnerText.Split(',');
        LeftBot = new Vector2(int.Parse(Splitstr[0]), int.Parse(Splitstr[1]));

        Splitstr = node.ChildNodes[6].InnerText.Split(',');
        RightTop = new Vector2(int.Parse(Splitstr[0]), int.Parse(Splitstr[1]));

        GType = (GetType)int.Parse(node.ChildNodes[4].InnerText);
    }
}
