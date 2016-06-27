using UnityEngine;
using System.Collections;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class ObjectLibrary : MonoBehaviour {

	public bool enabled = false;
	private Texture background;
	private Images images;
	[SerializeField] GameObject[] buttonObjects;
	[SerializeField] GameObject[] imageObjects;
	[SerializeField] GameObject[] otherObjects;
	private bool button = true;
	private bool image = false;
	private bool other = false;
	[SerializeField] Texture frame;
	private Vector2 buttonOffset;
	private float count = 0;
	private GUIStyle style;
	private Database data;
	private Pages pages;

	void Start(){
		style = new GUIStyle ();
		style.alignment = TextAnchor.MiddleCenter;
		data = GetComponent<Database> ();
		images = GameObject.FindGameObjectWithTag ("UI").GetComponent<Images> ();
		foreach (Texture img in images.images) {
			if(img.name == "ObjectLibrary"){
				background = img;
			}
		}
	}

	void OnGUI(){
		if (enabled) {
			GUI.DrawTexture(new Rect(Screen.width* 0.6582f, 0, Screen.width * 0.3418f, Screen.height), background);
			if (GUI.Button (new Rect (Screen.width* 0.6582f, Screen.height * 0.1f, Screen.width * 0.115f, Screen.height * 0.1f), "",style)) {
				button = true;
				image = false;
				other = false;
			}
			else if (GUI.Button (new Rect (Screen.width* 0.7732f, Screen.height * 0.1f, Screen.width * 0.11f, Screen.height * 0.1f), "",style)) {
				button = false;
				image = true;
				other = false;
			}
			else if (GUI.Button (new Rect (Screen.width* 0.8832f, Screen.height * 0.1f, Screen.width * 0.11f, Screen.height * 0.1f), "",style)) {
				button=false;
				image=false;
				other=true;
			}
			count = 0;
			if(button){
				foreach(GameObject buttonobj in buttonObjects){
					buttonOffset.x=(count%3)*0.11f;
					buttonOffset.y=(Mathf.Floor(count/3))*0.2f;
					if(GUI.Button(new Rect(Screen.width*(0.67f+buttonOffset.x),Screen.height*(0.25f+buttonOffset.y),Screen.width*0.1f,Screen.width*0.1f),buttonobj.GetComponent<ItemVariables>().buttonTexture,style)){
						GameObject prefab = Instantiate(buttonobj) as GameObject;
						buttonobj.GetComponent<ItemVariables>().itemName = buttonobj.GetComponent<ItemVariables>().itemName+GameObject.FindGameObjectWithTag("Pages").GetComponent<Pages>().PageArray[data.selectedPage].objects.Count.ToString();
						GameObject save = PrefabUtility.CreatePrefab("Assets/Elements/"+data.AppTitle+"/"+buttonobj.GetComponent<ItemVariables>().itemName+".prefab",buttonobj);
						data.databaseObject.GetComponent<Pages>().PageArray[data.selectedPage].objects.Add(save);
						if(GameObject.FindGameObjectWithTag("Scroller")!=null){
							GameObject.FindGameObjectWithTag("Scroller").GetComponent<Scroller>().attached.Add(prefab);
						}
						GameObject[] Buttons = GameObject.FindGameObjectsWithTag("Button");
						foreach(GameObject buttonObject in Buttons){
							if(buttonObject.gameObject!=null){
								Destroy(buttonObject);
							}
						}
						if(GameObject.FindGameObjectWithTag("Scroller")!=null){
							GameObject.FindGameObjectWithTag("Scroller").GetComponent<Scroller>().Reset();
							Destroy(GameObject.FindGameObjectWithTag("Scroller"));
						}
						GameObject.FindGameObjectWithTag("ImagePlayer").GetComponent<ImagePlayer>().closeImage();
						pages = GameObject.FindGameObjectWithTag ("Pages").GetComponent<Pages> ();
						if(GetComponent<App_Pages>().templateMenuOpened){
							pages.PageArray[data.selectedPage].templateOnly = true;
						}
						else{
							pages.PageArray[data.selectedPage].templateOnly = false;
						}
						pages.openPage(data.selectedPage);
					}
					GUI.DrawTexture(new Rect(Screen.width*(0.67f+buttonOffset.x),Screen.height*(0.25f+buttonOffset.y),Screen.width*0.1f,Screen.width*0.1f),frame);
					count++;
				}
			}
			else if(image){
				foreach(GameObject buttonobj in imageObjects){
					buttonOffset.x=(count%3)*0.11f;
					buttonOffset.y=(Mathf.Floor(count/3))*0.2f;
					if(GUI.Button(new Rect(Screen.width*(0.67f+buttonOffset.x),Screen.height*(0.25f+buttonOffset.y),Screen.width*0.1f,Screen.width*0.1f),buttonobj.GetComponent<ItemVariables>().imageMaterial,style)){
						GameObject prefab = Instantiate(buttonobj) as GameObject;
						buttonobj.GetComponent<ItemVariables>().itemName = buttonobj.GetComponent<ItemVariables>().itemName+GameObject.FindGameObjectWithTag("Pages").GetComponent<Pages>().PageArray[data.selectedPage].objects.Count.ToString();
						GameObject save = PrefabUtility.CreatePrefab("Assets/Elements/"+data.AppTitle+"/"+buttonobj.GetComponent<ItemVariables>().itemName+".prefab",buttonobj);
						data.databaseObject.GetComponent<Pages>().PageArray[data.selectedPage].objects.Add(save);
						if(GameObject.FindGameObjectWithTag("Scroller")!=null){
							GameObject.FindGameObjectWithTag("Scroller").GetComponent<Scroller>().attached.Add(prefab);
						}
						GameObject[] Buttons = GameObject.FindGameObjectsWithTag("Button");
						foreach(GameObject buttonObject in Buttons){
							if(buttonObject.gameObject!=null){
								Destroy(buttonObject);
							}
						}
						if(GameObject.FindGameObjectWithTag("Scroller")!=null){
							GameObject.FindGameObjectWithTag("Scroller").GetComponent<Scroller>().Reset();
							Destroy(GameObject.FindGameObjectWithTag("Scroller"));
						}
						GameObject.FindGameObjectWithTag("ImagePlayer").GetComponent<ImagePlayer>().closeImage();
						pages = GameObject.FindGameObjectWithTag ("Pages").GetComponent<Pages> ();
						if(GetComponent<App_Pages>().templateMenuOpened){
							pages.PageArray[data.selectedPage].templateOnly = true;
						}
						else{
							pages.PageArray[data.selectedPage].templateOnly = false;
						}
						pages.openPage(data.selectedPage);
						Debug.Log("saved");
					}
					GUI.DrawTexture(new Rect(Screen.width*(0.67f+buttonOffset.x),Screen.height*(0.25f+buttonOffset.y),Screen.width*0.1f,Screen.width*0.1f),frame);
					count++;
				}
			}
			else if(other){
				foreach(GameObject buttonobj in otherObjects){
					buttonOffset.x=(count%3)*0.11f;
					buttonOffset.y=(Mathf.Floor(count/3))*0.2f;
					if(GUI.Button(new Rect(Screen.width*(0.67f+buttonOffset.x),Screen.height*(0.25f+buttonOffset.y),Screen.width*0.1f,Screen.width*0.1f),buttonobj.GetComponent<ItemVariables>().imageMaterial,style)){
						GameObject prefab = Instantiate(buttonobj) as GameObject;
						buttonobj.GetComponent<ItemVariables>().itemName = buttonobj.GetComponent<ItemVariables>().itemName+GameObject.FindGameObjectWithTag("Pages").GetComponent<Pages>().PageArray[data.selectedPage].objects.Count.ToString();
						GameObject save = PrefabUtility.CreatePrefab("Assets/Elements/"+data.AppTitle+"/"+buttonobj.GetComponent<ItemVariables>().itemName+".prefab",buttonobj);
						data.databaseObject.GetComponent<Pages>().PageArray[data.selectedPage].objects.Add(save);
						if(GameObject.FindGameObjectWithTag("Scroller")!=null){
							GameObject.FindGameObjectWithTag("Scroller").GetComponent<Scroller>().attached.Add(prefab);
						}
						GameObject[] Buttons = GameObject.FindGameObjectsWithTag("Button");
						foreach(GameObject buttonObject in Buttons){
							if(buttonObject.gameObject!=null){
								Destroy(buttonObject);
							}
						}
						if(GameObject.FindGameObjectWithTag("Scroller")!=null){
							GameObject.FindGameObjectWithTag("Scroller").GetComponent<Scroller>().Reset();
							Destroy(GameObject.FindGameObjectWithTag("Scroller"));
						}
						GameObject.FindGameObjectWithTag("ImagePlayer").GetComponent<ImagePlayer>().closeImage();
						pages = GameObject.FindGameObjectWithTag ("Pages").GetComponent<Pages> ();
						if(GetComponent<App_Pages>().templateMenuOpened){
							pages.PageArray[data.selectedPage].templateOnly = true;
						}
						else{
							pages.PageArray[data.selectedPage].templateOnly = false;
						}
						pages.openPage(data.selectedPage);
						Debug.Log("saved");
					}
					GUI.DrawTexture(new Rect(Screen.width*(0.67f+buttonOffset.x),Screen.height*(0.25f+buttonOffset.y),Screen.width*0.1f,Screen.width*0.1f),frame);
					count++;
				}
			}
			count=0;
		}
	}
}
