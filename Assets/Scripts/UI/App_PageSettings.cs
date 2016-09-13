using UnityEngine;
using System.Collections;

public class App_PageSettings : MonoBehaviour {

	public bool enabled = false;
	private Texture background;
	private Images images;
	
	void Start(){
		images = gameObject.GetComponent<Images> ();
		foreach (Texture image in images.images) {
			if(image.name == "backgroundLeft"){
				background = image;
			}
		}
	}
	
	void OnGUI(){
		if (enabled) {
			GUI.DrawTexture(new Rect(0, 0, Screen.width * 0.3418f, Screen.height),background);
		}
	}
}