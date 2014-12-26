using UnityEngine;
using System.Collections;

public class ElementVariables : MonoBehaviour {

	public Vector3 position;
	public bool enabled;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log (Screen.width + "/" + Screen.height);
	}
}
