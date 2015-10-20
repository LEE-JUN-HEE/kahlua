using UnityEngine;
using System.Collections;

public class CObj_Build : CObj
{
    public BuildType BType;

    public override void SetData(System.Xml.XmlNode node)
    {
        base.SetData(node);

        BType = (BuildType)int.Parse(node.ChildNodes[5].InnerText);
    }
}
