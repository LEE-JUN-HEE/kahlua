using UnityEngine;
using System.Collections;

public class ShowParticle : MonoBehaviour {
	private ParticleSystem particleSys;
	private ParticleRenderer particleRen;

	void Awake(){
		particleSys = gameObject.AddComponent<ParticleSystem>();
		particleRen = gameObject.AddComponent<ParticleRenderer>();

		//particleRen.gameObject.SetActive(false);

	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
