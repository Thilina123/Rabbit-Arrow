using UnityEngine;
using System.Collections;

public class EnableOnCollision : MonoBehaviour {

	public string colliderTag="bullet";
	public GameObject[] surprizePrefabs;
	public float probability=100f;
	public bool destroyOnCollision=true;
	void Start () {
	
	}
	
	// Update is called once per frame
	void OnCollisionEnter (Collision col) {
		if (col.gameObject.tag==colliderTag) {
			if(Random.Range(0,100)>probability)
				return;
			GameObject obj=(GameObject)Instantiate(surprizePrefabs[Random.Range(0,surprizePrefabs.Length)],col.contacts[0].point,Quaternion.identity);
			obj.SetActive(true);
			if(destroyOnCollision)
			Destroy(gameObject);
				}
	}
}
