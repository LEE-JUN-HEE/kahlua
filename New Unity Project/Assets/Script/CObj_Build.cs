using UnityEngine;
using System.Collections;

public class CObj_Build : CObj
{

    public Vector2 LeftTop;
    public Vector2 RightBot;
    public BuildType BType;

    public override void SetData(System.Xml.XmlNode node)
    {
        base.SetData(node);
        string[] Splitstr;

        Splitstr = node.ChildNodes[5].InnerText.Split(',');
        LeftBot = new Vector2(int.Parse(Splitstr[0]), int.Parse(Splitstr[1]));

        Splitstr = node.ChildNodes[6].InnerText.Split(',');
        RightTop = new Vector2(int.Parse(Splitstr[0]), int.Parse(Splitstr[1]));

        BType = (BuildType)int.Parse(node.ChildNodes[6].InnerText);

        //기울기, 각 꼭지점 좌표  위치 정하는거 결정하고 코딩작업할것
        //현재 타입에 따른 모양 출력까지 완료
    }
}
