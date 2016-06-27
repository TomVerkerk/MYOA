using UnityEngine;
using System.Collections;

public class TestImage : MonoBehaviour {

	public Texture background;
	private bool visable = false;


	void OnGUI(){
		if (visable) {
			GUI.DrawTexture (new Rect (/*Screen.width * 0.3418f*/0, 0, Screen.width/* * 0.3164f*/, Screen.height), background);
		}
		if (Input.touchCount>0){
			visable = !visable;
		}
	}
}
