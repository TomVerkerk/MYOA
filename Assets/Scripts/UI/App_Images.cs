using UnityEngine;
using System.Collections;

public class App_Images : MonoBehaviour {

	public bool enabled = false;
	private Database data;
	private int buttonCount=1;
	private Images images;
	private Texture background;
	public Texture buttonBackground;
	public Texture white;
	public GUIStyle headerStyle;
	private float sliderIndex = 0;
	public GUIStyle style;
	private App_Image image;
	public bool pageSelected = false;
	
	void Start(){
		data = gameObject.GetComponent<Database> ();
		headerStyle.fontSize = (31*Screen.width)/1920;
		style.fontSize = (42*Screen.width)/1920;
		images = GetComponent<Images> ();
		foreach (Texture image in images.images) {
			if(image.name == "AppImages"){
				background = image;
			}
		}
	}
	
	void OnGUI(){
		if (enabled) {
			GUI.DrawTexture(new Rect(Screen.width* 0.6582f, 0, Screen.width*0.3418f, Screen.height),white);
			if (data.selectedPage == -1) {
				foreach (PageTemplate page in data.databaseObject.GetComponent<Database>().matchingPages.PageArray) {
					foreach (GameObject variables in page.objects) {
						if (variables.GetComponent<ItemVariables> ().image == true) {
							if (GUI.Button (new Rect (Screen.width * 0.723f, Screen.height * (0.17f +(0.17f * (buttonCount-1))-sliderIndex), Screen.width * 0.23f, Screen.height * 0.1f), buttonBackground, style)) {
								GetComponent<App_Menu> ().enabled = false;
								GetComponent<MainApp> ().enabled = false;
								GetComponent<App_Image>().enabled = false;
								GetComponent<AppChangeImage> ().enabled = false;
								GetComponent<AppChangeImage> ().item = variables.gameObject.GetComponent<ItemVariables> ();
								GetComponent<AppChangeImage> ().Reset ();
								GetComponent<AppChangeImage> ().enabled = true;
							}
							GUI.TextArea (new Rect (Screen.width * (0.835f - (variables.gameObject.GetComponent<ItemVariables> ().name.Length * 0.0065f)), Screen.height * (0.19f + (0.17f*( buttonCount-1))-sliderIndex), Screen.width * 0.23f, Screen.height * 0.1f), variables.gameObject.GetComponent<ItemVariables> ().itemName, style);
							buttonCount++;
						}
					}
				}
			} else {
				GUI.DrawTexture (new Rect (Screen.width * 0.72f, Screen.height * 0.16f + ((0.15f * buttonCount + 1)), Screen.width * 0.23f, Screen.height * 0.05f), buttonBackground);
				if (GUI.Button (new Rect (Screen.width * 0.775f,Screen.height*(0.165f-sliderIndex),Screen.width*0.1f,Screen.height*0.04f), "New Image", style)) {
					GetComponent<App_Image> ().enabled = true;
					GetComponent<AppChangeImage>().enabled = false;
					GetComponent<MainApp>().enabled = false;
					GetComponent<App_Menu>().enabled = false;
				}
				GUI.DrawTexture (new Rect (Screen.width * 0.72f, Screen.height * 0.23f + ((0.15f * buttonCount + 1)), Screen.width * 0.23f, Screen.height * 0.05f), buttonBackground);
				if (GUI.Button (new Rect (Screen.width * 0.775f,Screen.height*(0.235f-sliderIndex),Screen.width*0.1f,Screen.height*0.04f), "Image Library", style)) {
					GetComponent<AppChangeImage>().enabled = false;
					GetComponent<MainApp>().enabled = false;
					GetComponent<App_Menu>().enabled = false;
				}
				foreach (GameObject variables in data.matchingPages.PageArray[data.selectedPage].objects) {
					if (variables.GetComponent<ItemVariables> ().image == true) {
						if (GUI.Button (new Rect (Screen.width * 0.72f, Screen.height * (0.235f + (0.07f * buttonCount) - sliderIndex), Screen.width * 0.23f, Screen.height * 0.05f), buttonBackground, style)) {
							GetComponent<App_Menu> ().enabled = false;
							GetComponent<MainApp> ().enabled = false;
							GetComponent<App_Image>().enabled = false;
							GetComponent<AppChangeImage> ().enabled = false;
							GetComponent<AppChangeImage> ().item = variables.gameObject.GetComponent<ItemVariables> ();
							//GetComponent<AppChangeImage>().itemObject = variables;
							GetComponent<AppChangeImage> ().pageOpened = true;
							GetComponent<AppChangeImage> ().Reset ();
							GetComponent<AppChangeImage> ().enabled = true;
						}
						GUI.TextArea (new Rect (Screen.width * (0.824f - (variables.gameObject.GetComponent<ItemVariables>().name.Length * 0.0052f)), Screen.height * (0.235f + (0.07f * buttonCount) - sliderIndex), Screen.width * 0.001f, Screen.height * 0.1f), variables.gameObject.GetComponent<ItemVariables> ().itemName, style);
						buttonCount++;
					}
				}
		}
			GUI.DrawTexture (new Rect (Screen.width * 0.6582f, 0, Screen.width * 0.3418f, Screen.height), background);
			if((buttonCount+1)>12){
				sliderIndex = GUI.VerticalScrollbar(new Rect(Screen.width*0.97f,Screen.height*0.17f,Screen.width*0.03f,Screen.height*0.8f),sliderIndex,/*12/(buttonCount+1)*/0.01f,0,(buttonCount-12)*0.07f);
			}
			buttonCount = 1;
		}
	}
}
