using UnityEngine;
using System.Collections;
using System.Xml;

public class IT_Obj_Build : MonoBehaviour 
{
    public CObj_Build data;
    public UISprite sp_square;
    public UISprite sp_circle;
    public UISprite sp_tri;

    public void SetData(CObj_Build setdata)
    {
        data = setdata;

        switch (data.BType)
        {
            case CObj.BuildType.square:
                sp_square.gameObject.SetActive(true);
                sp_circle.gameObject.SetActive(false);
                sp_tri.gameObject.SetActive(false);
                break;

            case CObj.BuildType.circle:
                sp_square.gameObject.SetActive(false);
                sp_circle.gameObject.SetActive(true);
                sp_tri.gameObject.SetActive(true);
                break;

            case CObj.BuildType.tri:
                sp_square.gameObject.SetActive(false);
                sp_circle.gameObject.SetActive(false);
                sp_tri.gameObject.SetActive(true);
                break;
        }//모양

        
    }
}
