using UnityEngine;
using System.Collections;

public class App_Templates : MonoBehaviour {

	public bool enabled = false;
	private Texture background;
	private Images images;
	
	void Start(){
		images = gameObject.GetComponent<Images> ();
		foreach (Texture image in images.images) {
			if(image.name == "AppTemplates"){
				background = image;
			}
		}
	}
	
	void OnGUI(){
		if (enabled) {
			GUI.DrawTexture(new Rect(Screen.width * 0.6582f, 0, Screen.width * 0.3418f, Screen.height),background);
		}
	}
}
