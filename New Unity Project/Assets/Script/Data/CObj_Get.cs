using UnityEngine;
using System.Collections;

public class CObj_Get : CObj {
    public GetType GType;

    public override void SetData(System.Xml.XmlNode node)
    {
        base.SetData(node);

        GType = (GetType)int.Parse(node.ChildNodes[5].InnerText);
    }
}
