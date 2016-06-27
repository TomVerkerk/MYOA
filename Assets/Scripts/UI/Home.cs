using UnityEngine;
using System.Collections;

public class Home : MonoBehaviour {

	public bool enabled = true;
	private Texture new_app;
	private Texture load_app;
	private Texture background;
	private Texture backgroundRight;
	private Images images;
	private GUIStyle style;

	public void ResetUI(){
		GetComponent<App_Button> ().enabled = false;
		GetComponent<App_Buttons> ().enabled = false;
		GetComponent<App_Image> ().enabled = false;
		GetComponent<App_Images> ().enabled = false;
		GetComponent<App_Menu> ().enabled = false;
		GetComponent<App_NewPage> ().enabled = false;
		GetComponent<ObjectLibrary> ().enabled = false;
		GetComponent<App_Pages> ().enabled = false;
		GetComponent<App_PageSettings> ().enabled = false;
		GetComponent<App_Templates> ().enabled = false;
		GetComponent<App_Texts> ().enabled = false;
		GetComponent<Database> ().enabled = false;
		GetComponent<Load_App> ().enabled = false;
		GetComponent<MainApp> ().enabled = false;
		GetComponent<NewApp> ().enabled = false;
		GetComponent<NewApp> ().created = false;
		enabled = true;
	}

	void Start(){
		images = gameObject.GetComponent<Images> ();
		foreach (Texture image in images.images) {
			if(gameObject.GetComponent<Database>().taal == Database.language.Nederlands){
				if(image.name == "NieuweApp"){	
					new_app = image;
				}
				if(image.name == "OpenApp"){
					load_app = image;
				}
			}
			if(gameObject.GetComponent<Database>().taal == Database.language.English){
				if(image.name == "NewApp"){	
					new_app = image;
				}
				if(image.name == "LoadApp"){
					load_app = image;
				}
			}
			if(image.name == "Home Background"){
				background = image;
			}
			if(image.name == "backgroundRight"){
				backgroundRight = image;
			}
		}
		style = new GUIStyle ();
		ResetUI ();
	}


	void OnGUI(){
		if (enabled) {
			GUI.DrawTexture(new Rect(0, 0, Screen.width * 0.3418f, Screen.height),background);
			if (GUI.Button (new Rect (Screen.width * 0.06f, Screen.height * 0.16f, Screen.width * 0.23f, Screen.height * 0.1f), new_app ,style)) {
				this.gameObject.GetComponent<Load_App> ().enabled = false;
				this.gameObject.GetComponent<NewApp>().enabled=true;
			}
			if (GUI.Button (new Rect (Screen.width * 0.06f, Screen.height * 0.31f, Screen.width * 0.23f, Screen.height * 0.1f), load_app ,style)) {
				this.gameObject.GetComponent<NewApp> ().enabled = false;
				this.gameObject.GetComponent<Load_App> ().enabled = true;
			}
		}
	}
}
