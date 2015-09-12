using UnityEngine;
using System.Collections;
using System.Xml;

public class MapBuilder : MonoBehaviour {

    public XmlDocument parser = new XmlDocument();
    
    void Awake()
    {
        MapLoading();
    }

	void Update () {
	
	}


    void MapLoading()
    {
        parser.Load(Application.persistentDataPath + "/hi.xml");

        Debug.Log(parser.ChildNodes[0].ChildNodes[0].Name + parser.ChildNodes[0].ChildNodes[0].ChildNodes[0].InnerText);
    }
}
