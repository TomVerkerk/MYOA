using UnityEngine;
using System.Collections;

public class MainApp : MonoBehaviour {
	
	public bool enabled = false;
	private string appTitle;
	public bool templateOnly = false;
	public Texture background;
	public GUIStyle textStyle;
	private Database data;
	private Images images;
	//private Texture backgroundRight;
	private GameObject[] Buttons;
	private bool appOpen = true;
	private Texture white;
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
			if(image.name == "White"){
				white = image;
			}
		}
	}
	
	void OnGUI(){
		if (enabled) {
			GUI.DrawTexture(new Rect(0, 0, Screen.width * 0.3418f, Screen.height),white);
			GUI.DrawTexture(new Rect(0, 0, Screen.width * 0.3418f, Screen.height),background);
			appTitle = GetComponent<Database> ().AppTitle;
			GUI.TextArea (new Rect (Screen.width * 0.06f, Screen.height * 0.02f, Screen.width * 0.23f, Screen.height * 0.1f), appTitle, textStyle);
			GUI.color = Color.clear;
			if(GUI.Button(new Rect(0,0,Screen.width*0.06f,Screen.height*0.1f),"")){
				GetComponent<App_Pages>().enabled = false;
				GetComponent<App_Texts>().enabled = false;
				GetComponent<App_NewPage>().enabled = false;
				GetComponent<App_Menu>().enabled = false;
				GetComponent<App_Images>().enabled = false;
				GetComponent<AppChangeImage>().enabled = false;
				if(GetComponent<AppChangeButton>().item != null){
					GetComponent<AppChangeButton>().Reset();
				}
				GetComponent<AppChangeButton>().enabled = false;
				GetComponent<App_Templates>().enabled = false;
				GetComponent<App_Button>().Reset();
				GetComponent<App_Button>().enabled = false;
				GetComponent<App_Image>().Reset();
				GetComponent<App_Image>().enabled = false;
				GetComponent<Load_App>().enabled = true;
				GetComponent<Home>().enabled=true;
				enabled = false;
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
			}
			if (GUI.Button (new Rect (0, Screen.height * 0.1f, Screen.width * 0.11f, Screen.height * 0.1f), "Pages")&&templateOnly) {
				Destroy(GameObject.FindGameObjectWithTag("Scroller"));
				appOpen = false;
				GetComponent<App_Pages>().templateMenuOpened = false;
				if(!appOpen){
					//GameObject.FindGameObjectWithTag("Pages").GetComponent<Pages>().closePage(data.selectedPage);
					GameObject.FindGameObjectWithTag("Pages").GetComponent<Pages>().PageArray[data.selectedPage].templateOnly = false;
					GameObject.FindGameObjectWithTag("Pages").GetComponent<Pages>().openPage(data.selectedPage);
				}
				Buttons = GameObject.FindGameObjectsWithTag("Button");
				foreach(GameObject obj in Buttons){
					obj.GetComponent<ItemVariables>().selected = false;
				}
				templateOnly = false;
				Destroy(GameObject.FindGameObjectWithTag("ImagePlayer"));
			//	GetComponent<App_Pages>().enabled = true;
				GetComponent<NewApp>().enabled = false;
				GetComponent<ObjectLibrary>().enabled = true;
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


		if (GUI.Button (new Rect (Screen.width * 0.115f, Screen.height * 0.1f, Screen.width * 0.11f, Screen.height * 0.1f), "Template")&&!templateOnly) {
			/*	Buttons = GameObject.FindGameObjectsWithTag("Button");
				foreach(GameObject obj in Buttons){
					Debug.Log(""+obj);
					obj.GetComponent<ItemVariables>().selected = false;
					Destroy(obj);
				}*/
			//	Destroy(GameObject.FindGameObjectWithTag("Scroller"));
				appOpen = false;
				GetComponent<App_Pages>().templateMenuOpened = true;
				if(!appOpen){
					GameObject.FindGameObjectWithTag("Pages").GetComponent<Pages>().closePage(data.selectedPage);
					GameObject.FindGameObjectWithTag("Pages").GetComponent<Pages>().PageArray[data.selectedPage].templateOnly = true;
					GameObject.FindGameObjectWithTag("Pages").GetComponent<Pages>().openPage(data.selectedPage);
					appOpen = true;
				}
				Buttons = GameObject.FindGameObjectsWithTag("Button");
				foreach(GameObject obj in Buttons){
					obj.GetComponent<ItemVariables>().selected = false;
				}
				Destroy(GameObject.FindGameObjectWithTag("ImagePlayer"));
				templateOnly = true;
				GetComponent<App_TemplateEditor>().enabled = true;
				GetComponent<ObjectLibrary>().enabled = true;
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