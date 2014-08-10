using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	public float speed=0.5f;	
	public bool chain=false;
	bool moving =true;
	void Start () {
		Rabit.bulletCount++;
	}
	
	// Update is called once per frame
	void Update () {
		if(moving)
		transform.Translate(Vector3.up*speed);
		if (transform.position.y>35) {
			DestroyBullet();
				}
	}
	public void DestroyBullet(){
		if (chain) {
			StartCoroutine(WaitAndDestroy());
			return;
				}
		Rabit.bulletCount--;
		Destroy(gameObject);
	}
	IEnumerator WaitAndDestroy(){
		Debug.Log ("waiting");
		moving = false;
		yield return new WaitForSeconds(5);
		
		Rabit.bulletCount--;
		Destroy (gameObject);
	}

}
