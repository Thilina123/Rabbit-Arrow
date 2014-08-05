using UnityEngine;
using System.Collections;

public class Surprise_DoubleArrow : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void OnCollisionEnter (Collision col) {
		if (col.gameObject.tag=="rabbit") {
			Rabit.maxBullets=2;
			Destroy(gameObject);
				}
	}
}
