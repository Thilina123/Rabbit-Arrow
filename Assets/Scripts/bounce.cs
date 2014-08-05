using UnityEngine;
using System.Collections;

public class bounce : MonoBehaviour {

	public float bounceFactor=8;
	public Vector3 bounceDir=Vector3.up;
	void Start () {
	}
	
	// Update is called once per frame
	void OnCollisionEnter (Collision col) {
//		Debug.Log("bounced");
		if(col.gameObject.tag=="ball")
		col.rigidbody.AddForce(bounceDir*bounceFactor);
	}
}
