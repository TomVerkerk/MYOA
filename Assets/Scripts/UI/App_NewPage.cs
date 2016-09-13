using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif
using System.Collections;

public class App_NewPage : MonoBehaviour {

	public bool enabled = false;
	private Texture background;
	private Images images;
	private string pageName = "New Page";
	private GUIStyle textStyle;
	private PageTemplate newPageTemplate;
	private Database data;
	private GameObject[] Buttons;

	void Start(){
		data = gameObject.GetComponent<Database> ();
		images = gameObject.GetComponent<Images> ();
		foreach (Texture image in images.images) {
			if(image.name == "NewPagePage"){
				background = image;
			}
		}
		textStyle = new GUIStyle ();
	}

	void OnGUI(){
		if (enabled) {
			GetComponent<AppChangeImage>().enabled = false;
			GetComponent<AppChangeButton>().enabled = false;
			GUI.DrawTexture(new Rect(Screen.width* 0.6582f, 0, Screen.width * 0.3418f, Screen.height),background);
			textStyle.fontSize = 18;
			pageName = GUI.TextArea (new Rect (Screen.width* 0.6782f, Screen.height * 0.20f, Screen.width * 0.23f, Screen.height * 0.1f), pageName, textStyle);
			textStyle.fontSize = 24;
			GUI.TextField(new Rect(Screen.width * 0.7182f, Screen.height * 0.02f, Screen.width * 0.23f, Screen.height * 0.1f), pageName, textStyle);
			GUI.color = Color.clear;
			if(GUI.Button(new Rect(Screen.width*0.6582f,0,Screen.width*0.06f,Screen.height*0.1f),"")){
				enabled = false;
				gameObject.GetComponent<MainApp>().enabled = true;
			}
			if(GUI.Button(new Rect(Screen.width*0.7182f,Screen.height*0.783f,Screen.width*0.233f,Screen.height*0.1f),"")){
				GameObject prefabObj = new GameObject();
				prefabObj = Resources.Load("BlankPage") as GameObject;
				PageTemplate prefab = prefabObj.GetComponent<PageTemplate>();
				prefab.gameObject.name = pageName;
				prefab.pageName = pageName;
				prefab.template = true;
				prefab.index = data.matchingPages.PageArray.Count;
				prefab.templateObjects = GameObject.FindGameObjectWithTag("Pages").GetComponent<Pages>().templateObjects;
				data.selectedPage = data.matchingPages.PageArray.Count;
				prefab.gameObject.tag = "Button";
				GameObject save = PrefabUtility.CreatePrefab("Assets/Pages/"+data.AppTitle+"/"+pageName+".prefab",prefabObj);
				PageTemplate savePage = save.GetComponent<PageTemplate>();
				GameObject.FindGameObjectWithTag("Pages").GetComponent<Pages>().PageArray.Add(savePage);
				data.databaseObject.GetComponent<Pages>().PageArray.Add(savePage);
				gameObject.GetComponent<App_Menu>().pageName = pageName;
				Buttons = GameObject.FindGameObjectsWithTag("Button");
				Destroy(GameObject.FindGameObjectWithTag("Scroller"));
				foreach(GameObject obj in Buttons){
					Destroy(obj);
				}
				GameObject.FindGameObjectWithTag("Pages").GetComponent<Pages>().openPage(prefab.index);
				//gameObject.GetComponent<App_Menu>().enabled = true;
				enabled = false;
				pageName = "New Page";
			}

		}
	}
}
