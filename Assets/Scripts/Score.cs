using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour {

	public static int score=0;
	UILabel lbl;
	void Start () {
		score=0;
		lbl=gameObject.GetComponent<UILabel>();
	}
	
	// Update is called once per frame
	void Update () {
		lbl.text="Score: "+score;
	}
}
