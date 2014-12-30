using UnityEngine;
using System.Collections;

public class Zoom : MonoBehaviour {

	public float logoSpeed;
	public float startSize;
	public float stopSize;
	private bool move = true;

	void Start(){
		transform.localScale = new Vector3 (startSize, startSize*0.561555f, startSize);
		}

	// Update is called once per frame
	void Update () {
		if (move == true) {
			transform.localScale = transform.localScale + (new Vector3 (0.01f, 0.01f*0.561555f, 0.01f) * logoSpeed);
			if (transform.localScale.y >= stopSize) {
				move = false;
			}
		}
		if(Input.GetKeyDown(KeyCode.Space)||Input.touchCount>0){
			GameObject.FindGameObjectWithTag("Pages").GetComponent<Pages>().openPage(1);
			Destroy(GameObject.FindGameObjectWithTag("Logo").gameObject);
		}
	}
}
