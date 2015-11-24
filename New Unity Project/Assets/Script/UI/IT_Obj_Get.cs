using UnityEngine;
using System.Collections;
using System.Xml;

public class IT_Obj_Get : MonoBehaviour 
{
    public UISprite sp_Buff;
    public UISprite sp_Jelly;
    public UIWidget wd_this;

    int width = 0;
    int height = 0;

    CObj_Get data;

    void Start()
    {
        applydata(data);
    }

    void Update()
    {
    }
    public void SetData(CObj_Get setdata)
    {
        data = setdata;
    }

    void applydata(CObj_Get _data)
    {
        //모양
        switch (_data.GType)
        {
            case CObj.GetType.buff:
                sp_Buff.gameObject.SetActive(true);
                sp_Jelly.gameObject.SetActive(false);
                break;

            case CObj.GetType.jelly:
                sp_Buff.gameObject.SetActive(false);
                sp_Jelly.gameObject.SetActive(true);
                break;

        }

        //반복타입
        width = (int)(_data.RightTop.x - _data.LeftBot.x);
        height = (int)(_data.RightTop.y - _data.LeftBot.y);

        switch (_data.tType)
        {
            //case CObj.TiledType.none:
            //    wd_this.width = (int)width;
            //    wd_this.height = (int)height;
            //    //지금은 크기에 따라 위젯조절만 하지만 플레이어 기준 크기 정해지면 플레이어 크기 대비 scale 조정으로 수정. square 이외에 collider 조정 불가 이슈떄문
            //    break;

            //case CObj.TiledType.horizon:
            //    int instCount = width / (int)Common.Common.PlayerSize.x;
            //    sp_Instant.height = height;
            //    for(int i = 0; )
            //    break;

            //case CObj.TiledType.vertical:

            //    break;

            //case CObj.TiledType.tiled:

            //    break;

            default:
                wd_this.width = (int)width;
                wd_this.height = (int)height;
                break;
        }

        //위치
        gameObject.transform.localPosition = (Vector3)_data.LeftBot;

        //기울기
        transform.Rotate(new Vector3(0, 0, _data.tilt));

    }

    void tileCalculate(CObj.TiledType type)
    {
        switch (type)
        {
            case CObj.TiledType.horizon:

                break;

            case CObj.TiledType.vertical:

                break;

            case CObj.TiledType.tiled:

                break;
        }
    }
}
