using UnityEngine;
using System.Collections;

public class App_Menu : MonoBehaviour {
	
	public bool enabled = false;
	public string pageName;
	private Texture background;
	public GUIStyle textStyle;
	private Images images;

	void Start(){
		images = gameObject.GetComponent<Images> ();
		foreach (Texture image in images.images) {
			if(image.name == "AppMenuEnglish"){
				background = image;
			}
		}
		textStyle.fontSize = (60*Screen.width)/1920;
	}
	
	void OnGUI(){
		if (enabled) {
			GUI.DrawTexture(new Rect(0, 0, Screen.width * 0.3418f, Screen.height),background);
			GUI.TextArea (new Rect (Screen.width * 0.06f, Screen.height * 0.02f, Screen.width * 0.23f, Screen.height * 0.1f), pageName, textStyle);
			GUI.color = Color.clear;
			if (GUI.Button (new Rect (Screen.width * 0.289f, 0, Screen.width * 0.05f, Screen.height * 0.1f), "")) {
				//close page
				//remove page from PageArray
				//open App_Pages
			}
			if(GUI.Button(new Rect(0,0,Screen.width*0.06f,Screen.height*0.1f),"")){
				GetComponent<App_Pages>().opened = false;
				GetComponent<App_Pages>().enabled = true;
				GetComponent<App_Images>().enabled = false;
				GetComponent<App_Buttons>().enabled = false;
				GetComponent<App_Texts>().enabled = false;
				GetComponent<App_PageSettings>().enabled = false;
				GetComponent<MainApp>().enabled = true;
				GetComponent<App_Images>().pageSelected = false;
				GetComponent<App_Images>().pageSelected = false;
				GetComponent<AppChangeImage>().pageOpened = false;
				GetComponent<App_Image>().pageOpened = false;
				GetComponent<Database>().selectedPage = -1;
				GetComponent<Database>().databaseObject.GetComponent<Database>().selectedPage = 0;
				enabled = false;
			}
			if (GUI.Button (new Rect (Screen.width * 0.06f, Screen.height * 0.178f, Screen.width * 0.23f, Screen.height * 0.1f), "Buttons")) {
				GetComponent<App_Buttons>().enabled = true;
				GetComponent<App_Pages>().enabled = false;
				GetComponent<App_Images>().enabled = false;
				GetComponent<App_Texts>().enabled = false;
				GetComponent<App_Templates>().enabled = false;
			}
			if (GUI.Button (new Rect (Screen.width * 0.06f, Screen.height * 0.39f, Screen.width * 0.23f, Screen.height * 0.1f), "Images")) {
				GetComponent<App_Buttons>().enabled = false;
				GetComponent<App_Pages>().enabled = false;
				GetComponent<App_Images>().enabled = true;
				GetComponent<App_Texts>().enabled = false;
				GetComponent<App_Templates>().enabled = false;
			}
			if (GUI.Button (new Rect (Screen.width * 0.06f, Screen.height * 0.595f, Screen.width * 0.23f, Screen.height * 0.1f), "Texts")) {
				GetComponent<App_Buttons>().enabled = false;
				GetComponent<App_Pages>().enabled = false;
				GetComponent<App_Images>().enabled = false;
				GetComponent<App_Texts>().enabled = true;
				GetComponent<App_Templates>().enabled = false;
			}
			if (GUI.Button (new Rect (Screen.width * 0.06f, Screen.height * 0.805f, Screen.width * 0.23f, Screen.height * 0.1f), "Templates")) {
				GetComponent<App_Buttons>().enabled = false;
				GetComponent<App_Pages>().enabled = false;
				GetComponent<App_Images>().enabled = false;
				GetComponent<App_Texts>().enabled = false;
				GetComponent<App_Templates>().enabled = true;
			}
		}
	}
}
