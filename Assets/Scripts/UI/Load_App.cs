using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Load_App : MonoBehaviour {

	public bool enabled = false;
	public Texture background;
	public List<GameObject> databases;
	public GUIStyle style;
	private Database database;
	private int buttonCount = 0;
	private Texture buttonBackground;
	private Texture buttonBackgroundGrey;
	public Pages selectedPages;
	public Database selectedDatabase = null;
	private Pages opened;
	public bool appLoaded = false;
	private GameObject[] Buttons;
	private GameObject App;
	private Images images;
	private bool imagePlayerSpawned = false;
	private float sliderIndex = 0;

	// Use this for initialization
	void Start () {
		images = gameObject.GetComponent<Images> ();
		foreach (Texture image in images.images) {
			if(image.name == "buttonBackground 1"){
				buttonBackground = image;
			}
			if(image.name == "buttonBackgroundGrey 1"){
				buttonBackgroundGrey = image;
			}
		}
		database = gameObject.GetComponent<Database> ();
		style.fontSize = (55*Screen.width)/1920;
		selectedDatabase  = null;
	}

	void OnGUI () {
		if (enabled) {
			GUI.DrawTexture (new Rect (Screen.width * 0.6582f, 0, Screen.width * 0.3418f, Screen.height), background);
			foreach(GameObject obj in databases){
				if(obj != null){
					Database data = obj.GetComponent<Database>();
					if(data == selectedDatabase){
						if (GUI.Button (new Rect (Screen.width * 0.723f, Screen.height * (0.16f + (0.07f * (buttonCount))), Screen.width * 0.23f, Screen.height * 0.05f), buttonBackground, style)) {
						}
					}
					else{
						if (GUI.Button (new Rect (Screen.width * 0.723f, Screen.height * (0.16f + (0.07f * (buttonCount))), Screen.width * 0.23f, Screen.height * 0.05f), buttonBackgroundGrey, style)) {
							selectedDatabase = data;
							selectedPages = selectedDatabase.matchingPages;
						}
					}
					GUI.TextArea(new Rect (Screen.width * (0.823f - (data.AppTitle.Length * 0.0052f)), Screen.height * (0.16f + (0.07f * (buttonCount))), Screen.width * 0.23f, Screen.height * 0.05f), data.AppTitle, style);
					buttonCount++;
				}
			}

			buttonCount = 0;
			if (GUI.Button (new Rect (Screen.width * 0.723f, Screen.height * 0.9f, Screen.width * 0.23f, Screen.height * 0.05f), buttonBackground, style)) {
				if(selectedPages != null && selectedDatabase != null){
					if(appLoaded){
						Buttons = GameObject.FindGameObjectsWithTag("Button");
						foreach(GameObject buttonObject in Buttons){
							if(buttonObject!=null){
								Destroy(buttonObject);
							}
						}
						Destroy(GameObject.FindGameObjectWithTag("Pages"));
						if(GameObject.FindGameObjectWithTag("Scroller")!=null){
							Destroy(GameObject.FindGameObjectWithTag("Scroller"));
						}
					}
					App = Instantiate(selectedPages) as GameObject;
					if(selectedPages.PageArray.Count != 0){
						selectedPages.openPage(selectedPages.startPage);
					}
					if(GameObject.FindGameObjectWithTag("ImagePlayer")==null){
						Instantiate(Resources.Load ("ImagePlayer") as GameObject);
					}
					database.AppTitle = selectedDatabase.AppTitle;
					database.databaseObject = selectedDatabase.databaseObject;
					database.matchingPages = selectedPages;
					database.OS = selectedDatabase.OS;
					database.selectedPage = 0;
					appLoaded = true;
					GetComponent<Home>().enabled = false;
					GetComponent<MainApp>().enabled = true;
					GetComponent<Selecter>().enabled = true;
					GetComponent<ObjectLibrary>().enabled = true;
					GetComponent<App_Pages>().enabled=true;
					GetComponent<App_TemplateEditor>().enabled = false;
					GetComponent<App_Pages>().templateMenuOpened = false;
					enabled = false;
				}
			}
			GUI.TextArea(new Rect (Screen.width * 0.785f, Screen.height * 0.9f, Screen.width * 0.23f, Screen.height * 0.06f),"Load", style);
		}
	}
}
