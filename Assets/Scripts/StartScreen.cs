using UnityEngine;
using System.Collections;

public class StartScreen : MonoBehaviour {

	public GameObject logo;
	public Vector3 startPos;
	public float startSize;
	public float stopSize;

	// Use this for initialization
	void Start () {
		PlaceLogo ();
	}

	void PlaceLogo(){
		logo.GetComponent<Zoom>().stopSize = stopSize;
		logo.transform.localScale = new Vector3 (startSize*2, startSize, startSize);
		Instantiate (logo, startPos, transform.rotation);
	}
}
