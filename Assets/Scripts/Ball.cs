using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	public int devider=0;
	public static bool frozen=false;
	public GameObject ball;
	void Start () {
		
		rigidbody.AddForce(Vector3.right*3);
	
	}
	void Update(){
		if (Input.GetKeyDown (KeyCode.A)) {
			Devide();
		}
		if (frozen && rigidbody.constraints!=RigidbodyConstraints.FreezeAll) {
			//			rigidbody.isKinematic=true;
			rigidbody.constraints=RigidbodyConstraints.FreezeAll;
			//			Debug.Log("freezed");
		}
		if (!frozen && rigidbody.constraints==RigidbodyConstraints.FreezeAll) {
			//			rigidbody.isKinematic=false;
			rigidbody.constraints=RigidbodyConstraints.FreezePositionZ;
			Debug.Log("unfreezed");
		}
	}
	
	// Update is called once per frame
	void OnCollisionEnter (Collision col) {
//		Debug.Log(col.gameObject.tag);
		if (col.gameObject.tag=="bullet") {
			Devide();
			col.gameObject.GetComponent<Bullet>().DestroyBullet();
		}
		if (col.gameObject.tag=="rabbit") {
			col.gameObject.GetComponent<Rabit>().HitRabbit();
		}
	}
	public static void Freeze(){
		frozen = true;
	}
	public static void UnFreeze(){
		frozen = false;
	}
	void Devide(){
		Debug.Log ("devide "+devider);
		devider++;
		if (devider>2) {
			Destroy(gameObject);
			return;
				}
		GameObject b1=(GameObject)Instantiate(ball,transform.position,transform.rotation);
		b1.transform.Translate (Vector3.right);
//		GameObject b2=(GameObject)Instantiate(ball,transform.position,transform.rotation);

		b1.GetComponent<Ball>().devider=devider;
		b1.GetComponent<Ball>().ball=ball;
		b1.rigidbody.AddForce(Vector3.right*3);
		rigidbody.AddForce(Vector3.left*3);

		b1.transform.localScale=Vector3.one*(1.5f-.4f*devider);
		transform.localScale=Vector3.one*(1.5f-.4f*devider);
		Score.score+=5;
//		b2.GetComponent<Ball>().devider=devider;
//		b2.GetComponent<Ball>().ball=ball;

	}
}
