using UnityEngine;
using System.Collections;
using System.Xml;

public class IT_Obj_Build : MonoBehaviour 
{
    public CObj_Build data;
    public UISprite sp_square;
    public UISprite sp_circle;
    public UISprite sp_tri;
    public UIWidget wd_this;

    int width = 0;
    int height = 0;
    UISprite sp_Instant;

    public Vector2 local;

    void Start()
    {
        applydata(data);
    }

    void Update()
    {
    }

    public void SetData(CObj_Build setdata)
    {
        data = setdata;
    }

    void applydata(CObj_Build _data)
    {
        //모양
        switch (_data.BType)
        {
            case CObj.BuildType.square:
                sp_square.gameObject.SetActive(true);
                sp_circle.gameObject.SetActive(false);
                sp_tri.gameObject.SetActive(false);
                sp_Instant = sp_square;
                break;

            case CObj.BuildType.circle:
                sp_square.gameObject.SetActive(false);
                sp_circle.gameObject.SetActive(true);
                sp_tri.gameObject.SetActive(true);
                sp_Instant = sp_circle;
                break;

            case CObj.BuildType.tri:
                sp_square.gameObject.SetActive(false);
                sp_circle.gameObject.SetActive(false);
                sp_tri.gameObject.SetActive(true);
                sp_Instant = sp_tri;
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
