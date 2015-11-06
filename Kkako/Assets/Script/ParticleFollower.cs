using UnityEngine;
using System.Collections;

public class ParticleFollower : MonoBehaviour {

	private ParticleSystemRenderer ps;

	private Transform tr;
	private Vector3 mousePos;

	private bool isPressed;

	void Start(){
		ps = this.GetComponent<ParticleSystemRenderer>();
		ps.material.renderQueue =3500;
		tr = this.GetComponent<Transform>();
		isPressed = false;
	}

	void Update(){
		mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		tr.position = mousePos;
	}

	// Update is called once per frame
}
