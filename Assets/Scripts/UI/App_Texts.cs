using UnityEngine;
using System.Collections;

public class App_Texts : MonoBehaviour {

	public bool enabled = false;
	private Texture background;
	private Images images;
	private Database data;
	
	void Start(){
		data = gameObject.GetComponent<Database> ();
		images = gameObject.GetComponent<Images> ();
		foreach (Texture image in images.images) {
			if(data.taal == Database.language.English){
				if(image.name == "AppTextsEnglish"){
					background = image;
				}
			}
			if(data.taal == Database.language.Nederlands){
				if(image.name == "AppTexts"){
					background = image;
				}
			}
		}
	}
	
	void OnGUI(){
		if (enabled) {
			GUI.DrawTexture(new Rect(Screen.width * 0.6582f, 0, Screen.width * 0.3418f, Screen.height),background);
		}
	}
}
