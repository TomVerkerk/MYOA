using UnityEngine;
using System.Collections;

public class MainApp : MonoBehaviour {
	
	public bool enabled = false;
	private string appTitle;
	private bool templateOnly = false;
	public Texture background;
	public GUIStyle textStyle;
	private Database data;
	private Images images;
	//private Texture backgroundRight;
	private GameObject[] Buttons;
	private bool appOpen = true;
	//private GameObject[] objects;

	void Start(){
		textStyle.fontSize = (70*Screen.width)/1920;
		images = gameObject.GetComponent<Images> ();
		data = gameObject.GetComponent<Database> ();
		foreach (Texture image in images.images) {
			if (data.taal == Database.language.English) {
				if(image.name == "MainAppEnglish"){
					background = image;
				}
			}
			if(data.taal == Database.language.Nederlands){
				if(image.name == "MainApp"){
					background = image;
				}
			}
		/*	if(image.name == "backgroundRight"){
				backgroundRight = image;
			}*/
		}
	}
	
	void OnGUI(){
		if (enabled) {
			GUI.DrawTexture(new Rect(0, 0, Screen.width * 0.3418f, Screen.height),background);
		/*	if(GetComponent<AppChangeImage>().enabled == false && GetComponent<AppChangeButton>().enabled == false){
				GUI.DrawTexture(new Rect(Screen.width* 0.6582f, 0, Screen.width * 0.3418f, Screen.height), backgroundRight);
			}*/
			appTitle = GetComponent<Database> ().AppTitle;
			GUI.TextArea (new Rect (Screen.width * 0.06f, Screen.height * 0.02f, Screen.width * 0.23f, Screen.height * 0.1f), appTitle, textStyle);
			GUI.color = Color.clear;
			if(GUI.Button(new Rect(0,0,Screen.width*0.06f,Screen.height*0.1f),"")){
				Debug.Log("1");
		//		if(GetComponent<Load_App>().enabled == false){
					GetComponent<App_Pages>().enabled = false;
					GetComponent<App_Texts>().enabled = false;
					GetComponent<App_NewPage>().enabled = false;
					GetComponent<App_Menu>().enabled = false;
					GetComponent<App_Images>().enabled = false;
					GetComponent<AppChangeImage>().enabled = false;
					//GetComponent<AppChangeImage>().Reset();
				if(GetComponent<AppChangeButton>().item != null){
					GetComponent<AppChangeButton>().Reset();
				}
					GetComponent<AppChangeButton>().enabled = false;
					Debug.Log("0");
					//GetComponent<AppChangeButton>().Reset();
					GetComponent<App_Templates>().enabled = false;
					GetComponent<App_Button>().Reset();
					GetComponent<App_Button>().enabled = false;
					GetComponent<App_Image>().Reset();
					GetComponent<App_Image>().enabled = false;
					GetComponent<Load_App>().enabled = true;
					GetComponent<Home>().enabled=true;
					enabled = false;
					Debug.Log("Check");
					foreach(GameObject element in GameObject.FindGameObjectsWithTag("Button")){
						if(element.gameObject!=null){
							Destroy(element);
						}
					}
					Destroy(GameObject.FindGameObjectWithTag("Pages"));
					Destroy(GameObject.FindGameObjectWithTag("ImagePlayer"));
					if(GameObject.FindGameObjectWithTag("Scroller")!=null){
						Destroy(GameObject.FindGameObjectWithTag("Scroller"));
					}
		//		}
				/*else{
					gameObject.GetComponent<Home>().enabled = true;
					foreach(GameObject element in GameObject.FindGameObjectsWithTag("Button")){
						if(element.gameObject!=null){
							Destroy(element);
						}
					}
					Destroy(GameObject.FindGameObjectWithTag("Pages"));
					Destroy(GameObject.FindGameObjectWithTag("ImagePlayer"));
					if(GameObject.FindGameObjectWithTag("Scroller")!=null){
						Destroy(GameObject.FindGameObjectWithTag("Scroller"));
					}
					gameObject.GetComponent<App_Pages>().enabled = false;
					gameObject.GetComponent<App_Images>().enabled = false;
					gameObject.GetComponent<App_Texts>().enabled = false;
					gameObject.GetComponent<App_Templates>().enabled = false;
					if(gameObject.GetComponent<Load_App>().appLoaded == true){
						gameObject.GetComponent<Load_App>().enabled = true;
					}
					else{
						gameObject.GetComponent<NewApp>().enabled = true;
					}
					gameObject.GetComponent<Load_App>().appLoaded = false;
					gameObject.GetComponent<NewApp>().created = false;
					enabled = false;
				}*/
			}
			if (GUI.Button (new Rect (0, Screen.height * 0.1f, Screen.width * 0.11f, Screen.height * 0.1f), "Pages")) {
				Buttons = GameObject.FindGameObjectsWithTag("Button");
				foreach(GameObject obj in Buttons){
					obj.GetComponent<ItemVariables>().selected = false;
					Destroy(obj);
				}
				Destroy(GameObject.FindGameObjectWithTag("Scroller"));
				appOpen = false;
				GetComponent<App_Pages>().templateMenuOpened = false;
				if(!appOpen){
					GameObject.FindGameObjectWithTag("Pages").GetComponent<Pages>().PageArray[data.selectedPage].templateOnly = false;
					GameObject.FindGameObjectWithTag("Pages").GetComponent<Pages>().openPage(data.selectedPage);
				}
				Buttons = GameObject.FindGameObjectsWithTag("Button");
				foreach(GameObject obj in Buttons){
					obj.GetComponent<ItemVariables>().selected = false;
				}
				templateOnly = false;
			//	GetComponent<App_Pages>().enabled = true;
				GetComponent<NewApp>().enabled = false;
				GetComponent<Load_App>().enabled = false;
				GetComponent<App_TemplateEditor>().enabled = false;
				GetComponent<App_Images>().enabled = false;
				GetComponent<App_Texts>().enabled = false;
				GetComponent<AppChangeImage>().enabled = false;
				GetComponent<App_Image>().enabled=false;
				GetComponent<App_Button>().enabled=false;
				GetComponent<AppChangeButton>().enabled = false;
				GetComponent<App_Templates>().enabled = false;
			}
		/*	if (GUI.Button (new Rect (0, Screen.height * 0.9f, Screen.width * 0.17f, Screen.height * 0.1f), "New Button")) {
				if(!templateOnly){
				}
					Buttons = GameObject.FindGameObjectsWithTag("Button");
					foreach(GameObject obj in Buttons){
						obj.GetComponent<ItemVariables>().selected = false;
					}
					GetComponent<AppChangeButton>().enabled = false;
					GetComponent<AppChangeImage>().enabled = false;
					GetComponent<App_TemplateEditor>().enabled = false;
					GetComponent<App_Image>().enabled = false;
					GetComponent<App_Button>().enabled = true;
			}

			if (GUI.Button (new Rect (Screen.width * 0.17f, Screen.height * 0.9f, Screen.width * 0.17f, Screen.height * 0.1f), "New Image")) {
				if(!templateOnly){
				}
					Buttons = GameObject.FindGameObjectsWithTag("Button");
					foreach(GameObject obj in Buttons){
						obj.GetComponent<ItemVariables>().selected = false;
					}
					GetComponent<App_Image> ().enabled = true;
					GetComponent<AppChangeImage>().enabled = false;
					GetComponent<App_TemplateEditor>().enabled = false;
					GetComponent<App_Button>().enabled = false;
					GetComponent<AppChangeButton>().enabled = false;
					GetComponent<App_Menu>().enabled = false;
			}*/


		if (GUI.Button (new Rect (Screen.width * 0.115f, Screen.height * 0.1f, Screen.width * 0.11f, Screen.height * 0.1f), "Template")) {
				Buttons = GameObject.FindGameObjectsWithTag("Button");
				foreach(GameObject obj in Buttons){
					obj.GetComponent<ItemVariables>().selected = false;
					Destroy(obj);
				}
				Destroy(GameObject.FindGameObjectWithTag("Scroller"));
				appOpen = false;
				GetComponent<App_Pages>().templateMenuOpened = true;
				if(!appOpen){
					GameObject.FindGameObjectWithTag("Pages").GetComponent<Pages>().PageArray[data.selectedPage].templateOnly = true;
					GameObject.FindGameObjectWithTag("Pages").GetComponent<Pages>().openPage(data.selectedPage);
					appOpen = true;
				}
				templateOnly = true;
				GetComponent<App_TemplateEditor>().enabled = true;
			//	GetComponent<App_Pages>().enabled = false;
				GetComponent<NewApp>().enabled = false;
				GetComponent<Load_App>().enabled = false;
				GetComponent<App_Images>().enabled = false;
				GetComponent<AppChangeImage>().enabled = false;
				GetComponent<AppChangeButton>().enabled = false;
				GetComponent<App_Templates>().enabled = false;
			}
			if (GUI.Button (new Rect (Screen.width * 0.23f, Screen.height * 0.1f, Screen.width * 0.11f, Screen.height * 0.1f), "Settings")) {
			/*	GetComponent<App_Pages>().enabled = false;
				GetComponent<NewApp>().enabled = false;
				GetComponent<Load_App>().enabled = false;
				GetComponent<App_Images>().enabled = false;
				GetComponent<App_Texts>().enabled = false;
				GetComponent<App_Templates>().enabled = true;*/
			}
		}
	}
}