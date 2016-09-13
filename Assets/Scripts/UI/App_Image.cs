using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif
using System.Collections;

public class App_Image : MonoBehaviour {
	
	public bool enabled = false;
	private Texture background;
	private Images images;
	private Database data;
	private string ImageName = "New Image";
	private GUIStyle textStyle;
	public ItemVariables imageObject;
	public string textureName;
	public bool pageOpened = false;
	private Vector3 scaleOffset = Vector3.zero;
	private bool clickable = true;
	private Texture usingTex;
	private Texture visibleTex;
	private Texture notVisibleTex;

	private float posX = 0;
	private string posXString = "0";
	private float posY = 0;
	private string posYString = "0";
	
	private float scaleX = 0;
	private string scaleXString = "0";
	private float scaleY = 0;
	private string scaleYString = "0";
	
	private string imageString = "defaultButton";

	void Start(){
		textStyle = new GUIStyle ();
		textStyle.fontSize = (18*Screen.width)/1920;
		images = GetComponent<Images> ();
		data = GetComponent<Database> ();
		foreach (Texture image in images.images) {
			if(image.name == "AppImage"){
				background = image;
			}
			if(image.name == "visibleTex"){
				visibleTex = image;
			}
			if(image.name == "notVisibleTex"){
				notVisibleTex = image;
			}
		}
		if (clickable) {
			usingTex = visibleTex;
		} else {
			usingTex = notVisibleTex;
		}
	}

	public void Reset(){
		ImageName = "New Button";
		posXString = "0";
		posYString = "0";
		scaleXString = "0";
		scaleYString = "0";
		imageString = "defaultButton";
	}

	void OnGUI(){
		if (enabled) {
			GUI.DrawTexture(new Rect(Screen.width* 0.6582f, 0, Screen.width * 0.3418f, Screen.height),background);
			textStyle.fontSize = (42*Screen.width)/1920;
			ImageName = GUI.TextArea (new Rect (Screen.width * 0.6782f, Screen.height * 0.195f, Screen.width * 0.23f, Screen.height * 0.1f), ImageName, textStyle);
			posXString = GUI.TextArea (new Rect (Screen.width * 0.7382f, Screen.height * 0.315f, Screen.width * 0.05f, Screen.height * 0.05f), posXString, textStyle);
			posYString = GUI.TextArea (new Rect (Screen.width * 0.8832f, Screen.height * 0.315f, Screen.width * 0.05f, Screen.height * 0.05f), posYString, textStyle);
			scaleXString = GUI.TextArea (new Rect (Screen.width * 0.7382f, Screen.height * 0.44f, Screen.width * 0.05f, Screen.height * 0.05f), scaleXString, textStyle);
			scaleYString = GUI.TextArea (new Rect (Screen.width * 0.8832f, Screen.height * 0.44f, Screen.width * 0.05f, Screen.height * 0.05f), scaleYString, textStyle);
			imageString = GUI.TextArea (new Rect (Screen.width * 0.6862f, Screen.height * 0.565f, Screen.width * 0.27f, Screen.height * 0.05f), imageString, textStyle);
			textStyle.fontSize = (55*Screen.width)/1920;
			GUI.TextField (new Rect (Screen.width * 0.7182f, Screen.height * 0.02f, Screen.width * 0.23f, Screen.height * 0.1f), ImageName, textStyle);
			if(GUI.Button(new Rect (Screen.width * (0.225f+0.65825f), Screen.height * 0.688f, Screen.width * 0.035f, Screen.height * 0.055f),usingTex, textStyle)){
				clickable = !clickable;
				if (clickable) {
					usingTex = visibleTex;
				} else {
					usingTex = notVisibleTex;
				}
			}
			GUI.color = Color.clear;
			if(GUI.Button(new Rect(Screen.width*0.7182f,Screen.height*0.783f,Screen.width*0.233f,Screen.height*0.1f),"")){
				if (float.TryParse (posXString, out posX) == true &&
				    float.TryParse (posYString, out posY) == true &&
				    float.TryParse (scaleXString, out scaleX) == true &&
				    float.TryParse (scaleYString, out scaleY) == true) {
					GameObject prefab;
					prefab = Resources.Load("BlankElement") as GameObject;
					prefab.name = ImageName;
					ItemVariables item = prefab.GetComponent<ItemVariables>();
					item.itemName = ImageName;
					foreach(Texture image in images.images){
						if(image.name == imageString){
							item.imageMaterial = image;
						}
					}
					posX = float.Parse (posXString);
					posY = float.Parse (posYString);
					scaleX = float.Parse (scaleXString);
					scaleY = float.Parse (scaleYString);
					prefab.transform.localScale = new Vector3(scaleX*0.1125f,scaleY*0.2f,1);
					prefab.transform.rotation = Quaternion.Euler(new Vector3(0,0,180));
					item.position.x = 0.1125f*posX;
					item.position.y = -0.2f*posY;
					item.scale.x = scaleX*0.1125f;
					item.scale.y = scaleY*0.2f;
					item.imageTapple = clickable;
					scaleOffset = new Vector3(5.625f - item.scale.x/2,-10 + item.scale.y/2);
					item.image = true;
					item.button = false;
					Instantiate(prefab,new Vector3(item.position.x - scaleOffset.x,item.position.y - scaleOffset.y, 0),prefab.transform.rotation);
					GameObject save = PrefabUtility.CreatePrefab("Assets/Elements/"+data.AppTitle+"/"+ImageName+".prefab",prefab);
					data.matchingPages.PageArray[data.selectedPage].objects.Add(save);
					//GameObject.FindGameObjectWithTag("Pages").GetComponent<Pages>().PageArray[data.selectedPage].objects.Add(save);
					/*if(pageOpened){
						GetComponent<App_Menu> ().enabled = true;
						GetComponent<MainApp> ().enabled = false;
					}
					else{
						GetComponent<MainApp> ().enabled = true;
						GetComponent<App_Menu> ().enabled = false;
					}*/
					enabled = false;
					Reset();
				}
			}
		}
	}
}