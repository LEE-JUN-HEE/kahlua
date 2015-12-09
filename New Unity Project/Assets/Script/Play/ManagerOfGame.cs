using UnityEngine;
using System.Collections;

public class ManagerOfGame : MonoBehaviour {
	public float charSpeed;
	public float charSlowSpeed;
	public float charOriginSpeed;
	public float charUpforce;
	public float charHp;
	public float charMp;
	public float camSize;
	public float destroyPtime;
	public float playTime;

	public int portalNum;
	public int gemPoint;

	public UIProgressBar sp_HP;
	public UIProgressBar sp_MP;
	public UILabel 		 gemScore;

	public static ManagerOfGame instance;
	
	void Awake () {
		if(instance != null)  //  DontDestroyOnLoad(this.gameObject); 인해 해당 오브젝트가 계속 쌓이는 것을 방지
		{
			//Destroy(this); // 해당 스크립트를 삭제
			Destroy(this.gameObject); // 해당 오브젝트를 삭제
			return;
		}
		
		instance = this;
		//DontDestroyOnLoad(this);
		DontDestroyOnLoad(this.gameObject);
	}

	void Update(){
		playTime +=Time.deltaTime;
	}
	
	public void CharSpeedUpdate(){
		charSpeed = UIScrollBar.current.value;
	}
	public void CamSizeUpdate(){
		Camera.main.orthographicSize = UIScrollBar.current.value*10;
	}

	public void MpController(){
		charMp -= 10;
		sp_MP.value = charMp/100;
	}

	public void ScoreController(){
		gemPoint += 10;
		gemScore.text = gemPoint.ToString("000");
	}
}
