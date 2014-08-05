using UnityEngine;
using System.Collections;

public class EnableOnCollision : MonoBehaviour {

	public string colliderTag="bullet";
	public GameObject[] surprizePrefabs;
	void Start () {
	
	}
	
	// Update is called once per frame
	void OnCollisionEnter (Collision col) {
		if (col.gameObject.tag==colliderTag) {
			GameObject obj=(GameObject)Instantiate(surprizePrefabs[Random.Range(0,surprizePrefabs.Length)],col.contacts[0].point,Quaternion.identity);
			obj.SetActive(true);
			Destroy(gameObject);
				}
	}
}
