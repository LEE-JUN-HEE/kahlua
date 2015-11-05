using UnityEngine;
using System.Collections;

public class ParticleFollower : MonoBehaviour {

	private ParticleSystemRenderer ps;

	void Start(){
		ps = this.GetComponent<ParticleSystemRenderer>();
		ps.material.renderQueue =3500;
	}

	// Update is called once per frame
}
