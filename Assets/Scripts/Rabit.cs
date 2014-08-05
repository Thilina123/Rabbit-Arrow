using UnityEngine;
using System.Collections;

public class Rabit : MonoBehaviour {

	public GameObject idle,left,right,bullet,retry;
	public Animator killAnim;
	public float range=6.5f;
	public float speed=.1f;
	public static int bulletCount=0,maxBullets=1;
	bool hit=false;
	GameObject obj;
	void Start () {
		bulletCount = 0;
		maxBullets = 1;
	}
	
	// Update is called once per frame
	void Update () {
		if(!hit){
		if (Input.GetKey(KeyCode.LeftArrow)) {
			WalkLeft();
			return;
		}
		if (Input.GetKey(KeyCode.RightArrow)) {
			WalkRight();
			return;
		}
		if (Input.GetKeyDown(KeyCode.Space)) {
			Shoot();
				}
		}
		StandIdle();
		if (hit) {
			Vector3.MoveTowards(transform.position,new Vector3(-5,0,-10),.5f);
				}
		
	}
	void WalkLeft(){
//		Debug.Log("left");
		if(transform.position.x>-range)
		transform.Translate(Vector3.left*speed);
		left.SetActive(true);
		right.SetActive(false);
		idle.SetActive(false);
	}
	void WalkRight(){
		if(transform.position.x<range)
		transform.Translate(Vector3.right*speed);
		left.SetActive(false);
		right.SetActive(true);
		idle.SetActive(false);		
	}
	void StandIdle(){
		left.SetActive(false);
		right.SetActive(false);
		idle.SetActive(true);		
	}
	void Shoot(){
		Debug.Log (bulletCount+ ":" +maxBullets);
		if (bulletCount >= maxBullets) {
			return;
				}
		if (maxBullets>1) {
			maxBullets--;			
				}
		obj =(GameObject)Instantiate(bullet,transform.position,Quaternion.identity);
	}
	public void HitRabbit(){
		hit=true;
		Debug.Log("killed");
		killAnim.SetTrigger("killed");
		retry.SetActive(true);
	}
	void OnCollisionEnter (Collision col) {
		if (col.gameObject.tag=="double arrow") {
			Rabit.maxBullets=3;
			Destroy(col.gameObject);
		}
	}
	
}
