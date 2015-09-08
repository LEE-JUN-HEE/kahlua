using UnityEngine;
using System.Collections;


public class TimeSleep : MonoBehaviour {

	public void SlowMotion(){
		StartCoroutine(WaitTime());
	}
	
	IEnumerator WaitTime() {
		Move.instance.speed = 0.05f;
		yield return new WaitForSeconds(2.0f);
		Move.instance.speed = 0.2f;
	}
}
