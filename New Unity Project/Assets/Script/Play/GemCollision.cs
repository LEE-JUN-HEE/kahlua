using UnityEngine;
using System.Collections;

public class GemCollision : MonoBehaviour {

void OnTriggerEnter2D(Collider2D coll)
	{
		if(coll.tag.Equals("Player"))
		{
			ManagerOfGame.instance.ScoreController();
			Destroy(this.gameObject);
		}
	}
}
