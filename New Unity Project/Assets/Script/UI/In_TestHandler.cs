using UnityEngine;
using System.Collections;

public class In_TestHandler : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
    public void OnClick_Quit()
    {
        Application.LoadLevel(0);
    }
}
