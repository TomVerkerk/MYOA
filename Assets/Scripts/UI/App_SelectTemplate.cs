using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif
using System.Collections;
using System.Collections.Generic;

public class App_SelectTemplate : MonoBehaviour {

	public bool enabled = false;
	public GameObject[] templates;
	private Vector2 templateOffset = new Vector2 (0.24f, 0.55f);
	private Images images;
	private int count =0;
	private int selected = -1;
	private bool templateSelected = false;
	private Texture explainImage;
	private Texture background;
	private Texture backButton;
	private GUIStyle style;
	private GameObject[] Buttons;

	void Start(){
		enabled = false;
		style = new GUIStyle ();
		images = GetComponent<Images> ();
		foreach (Texture tex in images.images) {
			if(tex.name == "SelectTemplate"){
				background = tex;
			}
			if(tex.name == "BackButton"){
				backButton = tex;
			}
		}
	}

	void OnGUI(){
		if (enabled) {
			GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), background);
			if(templateSelected){
				GUI.DrawTexture(new Rect(0,Screen.height*0.12f,Screen.width,Screen.height),explainImage);
				if(GUI.Button(new Rect(0,0,Screen.width*0.095f,Screen.height*0.095f),backButton,style)){
					templateSelected = false;
				}
				int index = 0;
				if(GUI.Button(new Rect(Screen.width*0.74f,Screen.height*0.71f,Screen.width*0.22f,Screen.height*0.1f),"",style)){
					GameObject.FindGameObjectWithTag ("Pages").GetComponent<Database> ().matchingPages.templateObjects.Clear();
					GameObject.FindGameObjectWithTag ("Pages").GetComponent<Pages> ().templateObjects.Clear ();
					GameObject.FindGameObjectWithTag ("Pages").GetComponent<Database> ().matchingPages.PageArray.Clear();
					GameObject.FindGameObjectWithTag ("Pages").GetComponent<Pages> ().PageArray.Clear ();
					foreach(PageTemplate templ in templates[selected].GetComponent<Pages>().PageArray){
						AddPage(templ.pageName,index,templ.template,templ.objects);
						index++;
					}
					index = 0;
					if(templates[selected].GetComponent<Pages>().template){
						foreach(GameObject templObj in templates[selected].GetComponent<Pages>().templateObjects){
							AddTemplObj(templObj);
						}
					}
					Instantiate(Resources.Load ("Scroller") as GameObject);
					GameObject.FindGameObjectWithTag("Pages").GetComponent<Pages>().PageArray[0].templateOnly = false;
					GameObject.FindGameObjectWithTag("Pages").GetComponent<Pages>().openPage(0);
					GetComponent<Database>().selectedPage = 0;
					enabled = false;
					GetComponent<MainApp>().enabled = true;
					GetComponent<ObjectLibrary>().enabled = true;
					GetComponent<Selecter>().enabled = true;
					GetComponent<App_Pages>().enabled=true;
				}
			}
			else{
				count = 0;
				foreach (GameObject template in templates) {
					if (GUI.Button (new Rect (Screen.width * (0.07f + (templateOffset.x * (count % 4))), Screen.height * (0.15f + (templateOffset.y * (Mathf.RoundToInt (count / 4)))), Screen.width * 0.15f, Screen.width * (0.15f*1.7778f)), template.GetComponent<Pages> ().templateImage,style)) {
						explainImage = template.GetComponent<Pages>().explainImage;
						selected = count;
						templateSelected=true;
					}
					count++;
				}
				count = 0;
			}
		}
	}

	void AddTemplObj(GameObject Obj){
		GameObject templObj;
		templObj = Resources.Load ("BlankElement") as GameObject;
		ItemVariables templVar = Obj.GetComponent<ItemVariables> ();
		ItemVariables targetVar = templObj.GetComponent<ItemVariables> ();
		targetVar.itemName = templVar.itemName;
		targetVar.position = templVar.position;
		targetVar.currentPage = templVar.currentPage;
		targetVar.scale = templVar.scale;
		targetVar.button = templVar.button;
		targetVar.buttonVisable = templVar.buttonVisable;
		targetVar.attachedToCam = templVar.attachedToCam;
		targetVar.moveButton = templVar.moveButton;
		targetVar.place = templVar.place;
		targetVar.toTopButton = templVar.toTopButton;
		targetVar.dialButton = templVar.dialButton;
		targetVar.phoneNumber = templVar.phoneNumber;
		targetVar.menuBar = templVar.menuBar;
		targetVar.image = templVar.image;
		targetVar.imageOverlaying = templVar.imageOverlaying;
		targetVar.imageTapple = templVar.imageTapple;
		targetVar.slider = templVar.slider;
		targetVar.site = templVar.site;
		targetVar.siteURL = templVar.siteURL;
		targetVar.crisischeck = templVar.crisischeck;
		targetVar.exit = templVar.exit;
		targetVar.imageMaterial = templVar.imageMaterial;
		targetVar.buttonTexture = templVar.buttonTexture;
		targetVar.buttonLeft = templVar.buttonLeft;
		targetVar.buttonTop = templVar.buttonTop;
		targetVar.buttonTopStart = templVar.buttonTopStart;
		targetVar.buttonWidth = templVar.buttonWidth;
		targetVar.buttonHeight = templVar.buttonHeight;
		targetVar.buttonGoesToPage = templVar.buttonGoesToPage;
		targetVar.backGoesToPage = templVar.backGoesToPage;
		targetVar.templateItem = true;
		GameObject save = PrefabUtility.CreatePrefab("Assets/Elements/"+GetComponent<Database>().AppTitle+"/"+Obj.GetComponent<ItemVariables> ().itemName+".prefab",templObj);
		GameObject.FindGameObjectWithTag ("Pages").GetComponent<Database> ().matchingPages.templateObjects.Add (save);
		GameObject.FindGameObjectWithTag ("Pages").GetComponent<Pages> ().templateObjects.Add (save);
	}

	void AddPage(string name, int pageIndex, bool template,List<GameObject> objs){
		GameObject prefabObj;
		prefabObj = Resources.Load("BlankPage") as GameObject;
		PageTemplate prefab = prefabObj.GetComponent<PageTemplate>();
		prefab.gameObject.name = name+"(Clone)";
		prefab.pageName = name;
		prefab.template = template;
		prefab.index = pageIndex;
		prefab.gameObject.tag = "Button";
		prefab.objects.Clear ();
		foreach (GameObject obj in objs) {
			GameObject templObj;
			templObj = Resources.Load ("BlankElement") as GameObject;
			ItemVariables targetVar = templObj.GetComponent<ItemVariables> ();
			ItemVariables templVar = obj.GetComponent<ItemVariables> ();
			targetVar.itemName = templVar.itemName;
			targetVar.position = templVar.position;
			targetVar.currentPage = templVar.currentPage;
			targetVar.scale = templVar.scale;
			targetVar.button = templVar.button;
			targetVar.buttonVisable = templVar.buttonVisable;
			targetVar.attachedToCam = templVar.attachedToCam;
			targetVar.moveButton = templVar.moveButton;
			targetVar.place = templVar.place;
			targetVar.toTopButton = templVar.toTopButton;
			targetVar.dialButton = templVar.dialButton;
			targetVar.phoneNumber = templVar.phoneNumber;
			targetVar.menuBar = templVar.menuBar;
			targetVar.image = templVar.image;
			targetVar.imageOverlaying = templVar.imageOverlaying;
			targetVar.imageTapple = templVar.imageTapple;
			targetVar.slider = templVar.slider;
			targetVar.site = templVar.site;
			targetVar.siteURL = templVar.siteURL;
			targetVar.crisischeck = templVar.crisischeck;
			targetVar.exit = templVar.exit;
			targetVar.imageMaterial = templVar.imageMaterial;
			targetVar.buttonTexture = templVar.buttonTexture;
			targetVar.buttonLeft = templVar.buttonLeft;
			targetVar.buttonTop = templVar.buttonTop;
			targetVar.buttonTopStart = templVar.buttonTopStart;
			targetVar.buttonWidth = templVar.buttonWidth;
			targetVar.buttonHeight = templVar.buttonHeight;
			targetVar.buttonGoesToPage = templVar.buttonGoesToPage;
			targetVar.backGoesToPage = templVar.backGoesToPage;
			targetVar.templateItem = false;
			GameObject saveObj = PrefabUtility.CreatePrefab("Assets/Elements/"+GetComponent<Database>().AppTitle+"/"+targetVar.itemName+".prefab",templObj);
			prefab.objects.Add(saveObj);
		}
		GameObject save = PrefabUtility.CreatePrefab("Assets/Pages/"+GetComponent<Database>().AppTitle+"/"+name+".prefab",prefabObj);
		GetComponent<Database> ().matchingPages.PageArray.Add (save.GetComponent<PageTemplate> ());
		GameObject.FindGameObjectWithTag("Pages").GetComponent<Pages>().PageArray.Add(save.GetComponent<PageTemplate>());
		enabled = false;
	}
}
