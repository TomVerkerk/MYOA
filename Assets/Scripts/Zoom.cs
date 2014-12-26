using UnityEngine;
using System.Collections;

public class Zoom : MonoBehaviour {

	public float logoSpeed;
	public float stopSize;
	private bool move = true;
	private Pages pages;
	
	// Update is called once per frame
	void Update () {
		if (move == true) {
			transform.localScale = transform.localScale + (new Vector3 (0.01f, 0.01f, 0.01f) * logoSpeed);
			if (transform.localScale == new Vector3 (stopSize, stopSize, stopSize)) {
				move = false;
			}
		}
		else if(Input.GetKeyDown(KeyCode.Space)||Input.touchCount>0){
			pages = GameObject.FindGameObjectWithTag("Pages").GetComponent<Pages>();
			pages.openPage(0);
			Destroy(this.gameObject);
		}
	}
}
