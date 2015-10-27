using UnityEngine;
using System.Collections;

public class TestTool : MonoBehaviour {
    public GameObject mCamera = null;
    public GameObject mMoveObj;
    public float scrollspeed = .1f;

    void Awake()
    {
        mCamera = Camera.main.gameObject;
    }
	void Update ()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            mCamera.transform.position += new Vector3(0, scrollspeed, 0);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            mCamera.transform.position += new Vector3(0, -scrollspeed, 0);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            mCamera.transform.position += new Vector3(scrollspeed, 0, 0);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            mCamera.transform.position += new Vector3(-scrollspeed, 0, 0);
        }


        if (Input.GetKey(KeyCode.W))
        {
            mMoveObj.transform.position += new Vector3(0, scrollspeed, 0);
        }
        if (Input.GetKey(KeyCode.S))
        {
            mMoveObj.transform.position += new Vector3(0, -scrollspeed, 0);
        }
        if (Input.GetKey(KeyCode.A))
        {
            mMoveObj.transform.position += new Vector3(-scrollspeed,0, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            mMoveObj.transform.position += new Vector3(scrollspeed,0, 0);
        }
	}
}
