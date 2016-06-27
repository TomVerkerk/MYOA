using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif
using System.IO;
using System.Collections;

public class NewApp : MonoBehaviour {

	public bool enabled = false;
	public GameObject blankApp;
	private GameObject blankAppObject;
	//public Database database;
	private string Apptitle = "Apptitle";
	private Images images;
	private Texture background;
	public GUIStyle textStyle;
	public Texture2D grey;
	private int choise = 0;
	private Database data;
	public bool created = false;
	private string OS;
	private bool imagePlayerSpawned = false;
	//private GameObject UI;
	//public Load_App uiLoadApp;

	void Start(){
		images = gameObject.GetComponent<Images> ();
		data = this.gameObject.GetComponent<Database> ();
		//uiLoadApp = UI.GetComponent<Load_App> ();
		//Debug.Log (uiLoadApp);
		textStyle.fontSize = 24;
		foreach (Texture image in images.images) {
			if(data.taal == Database.language.Nederlands){
				if(image.name == "NewAppPage"){
					background = image;
				}
			}
			if(data.taal == Database.language.English){
				if(image.name == "NewAppPageEnglish"){
					background = image;
				}
			}
		}
		textStyle.fontSize = Mathf.RoundToInt(Screen.height * 0.0526315789473684f);
	}

	void OnGUI(){
		if (enabled) {
			GUI.DrawTexture(new Rect(Screen.width * 0.6582f, 0, Screen.width * 0.3418f, Screen.height),background);
			Apptitle = GUI.TextArea (new Rect (Screen.width * 0.735f, Screen.height * 0.20f, Screen.width * 0.23f, Screen.height * 0.1f), Apptitle, textStyle);
			data.AppTitle = Apptitle;
			blankApp.GetComponent<Database>().AppTitle = Apptitle;
			if(choise==1){
				GUI.DrawTexture(new Rect(Screen.width*0.796666666f, Screen.height*0.389f, Screen.width*0.1522222f, Screen.height* 0.095f),grey);
			}
			if(choise==2){
				GUI.DrawTexture(new Rect (Screen.width * 0.72f, Screen.height * 0.389f, Screen.width * 0.0766666f, Screen.height * 0.095f),grey);
				GUI.DrawTexture(new Rect (Screen.width * 0.87333333f, Screen.height * 0.389f, Screen.width * 0.0766666f, Screen.height * 0.095f),grey);
			}
			if(choise==3){
				GUI.DrawTexture(new Rect(Screen.width*0.72f, Screen.height*0.389f, Screen.width*0.1522222f, Screen.height* 0.095f),grey);
			}
			GUI.color = Color.clear;
			if(GUI.Button(new Rect (Screen.width * 0.72f, Screen.height * 0.385f, Screen.width * 0.0766666f, Screen.height * 0.1f),"")){
				choise = 1;
				OS = "Android";
			}
			if(GUI.Button(new Rect (Screen.width * 0.79666666f, Screen.height * 0.385f, Screen.width * 0.0766666f, Screen.height * 0.1f),"")){
				choise=2;
				OS = "WindowsPhone8";
			}
			if(GUI.Button(new Rect (Screen.width * 0.87333333f, Screen.height * 0.385f, Screen.width * 0.0766666f, Screen.height * 0.1f),"")){
				choise=3;
				OS = "Ios";
			}
			if(GUI.Button(new Rect (Screen.width * 0.72f, Screen.height * 0.78f, Screen.width * 0.23f, Screen.height * 0.1f),"")){
				if(!created){
					gameObject.GetComponent<Home>().enabled = false;
					gameObject.GetComponent<App_SelectTemplate>().enabled = true;
					enabled=false;
					blankAppObject = Instantiate(blankApp) as GameObject;
					if(!imagePlayerSpawned){
						Instantiate(Resources.Load ("ImagePlayer") as GameObject);
					}
					blankAppObject.name = Apptitle;
					data.OS = OS;
					data.selectedPage = 0;
					created = true;
					GameObject save = PrefabUtility.CreatePrefab("Assets/Apps/"+Apptitle+".prefab",blankAppObject);
					save.GetComponent<Database>().databaseObject = save;
					save.GetComponent<Database>().matchingPages = save.GetComponent<Pages>();
					blankAppObject.GetComponent<Database>().matchingPages = save.GetComponent<Pages>();
					gameObject.GetComponent<Load_App>().databases.Add(save);
					data.databaseObject = save;
					data.matchingPages = save.GetComponent<Pages>();
					GameObject saveUI = PrefabUtility.CreatePrefab("Assets/Resources/UI.prefab",this.gameObject as GameObject);
					Directory.CreateDirectory("Assets/Pages/"+Apptitle);
					Directory.CreateDirectory("Assets/Elements/"+Apptitle);
				}
				else{
					data.OS = OS;
				}
			}
		}
	}
}
