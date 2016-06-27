using UnityEngine;
using System.Collections;

public class App_SelectImage : MonoBehaviour {

	public bool enabled = false;
	private Texture background;

	void Start(){
		foreach(Texture image in gameObject.GetComponent<Images>().images){
			if(image.name == "AppSelectImage"){
				background = image;
			}
		}
	}

	void OnGUI(){
		if (enabled) {
			GUI.DrawTexture (new Rect (Screen.width * 0.6582f, 0, Screen.width * 0.3418f, Screen.height), background);
		}
	}

}