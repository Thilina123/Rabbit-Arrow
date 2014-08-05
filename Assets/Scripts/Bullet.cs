using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	public float speed=0.5f;	
	void Start () {
		Rabit.bulletCount++;
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(Vector3.up*speed);
		if (transform.position.y>39) {
			DestroyBullet();
				}
	}
	public void DestroyBullet(){
		
		Rabit.bulletCount--;
		Destroy(gameObject);
	}

}
