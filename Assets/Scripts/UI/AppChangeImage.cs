using UnityEngine;
using System.Collections;

public class AppChangeImage : MonoBehaviour {
	
	public bool enabled = false;
	public ItemVariables item;
	public GameObject itemObject;
	private Texture background;
	private Images images;
	private Database data;
	private GUIStyle textStyle;
	private string ImageName;
	public ItemVariables activeGameObject;
	public bool pageOpened = false;
	private Vector3 scaleOffset;
	private GameObject[] Buttons;
	private bool clickable = true;
	private Texture usingTex;
	private Texture visibleTex;
	private Texture notVisibleTex;
	
	public float posX = 0;
	public string posXString = "-1";
	public float posY = 0;
	public string posYString = "-1";
	
	public float scaleX = 0;
	public string scaleXString = "-1";
	public float scaleY = 0;
	public string scaleYString = "-1";
	
	private string imageString = "start";

	private Vector2 mousepos;

	public Vector2 movePos = Vector2.zero;
	private bool mouseClick = false;
	private Vector2 newPos= Vector2.zero;
	private Vector2 mousestart;
	private bool click = false;
	private Vector2 diff = Vector2.zero;
	private float screenOffset = 0.3418f;
	private Texture selectedImage;
	private Vector2 screenRes;

	
	
	void Start(){
		textStyle = new GUIStyle ();
		images = GetComponent<Images> ();
		data = GetComponent<Database> ();
		screenRes.x = Screen.width * 0.3164f;
		screenRes.y = Screen.height;
		foreach (Texture image in images.images) {
			if(image.name == "AppChangeImage"){
				background = image;
			}
			if(image.name == "visibleTex"){
				visibleTex = image;
			}
			if(image.name == "notVisibleTex"){
				notVisibleTex = image;
			}
			if(image.name == "SelectedImage"){
				selectedImage = image;
			}
		}
	}
	
	public void Reset(){
		ImageName = item.itemName;
		posXString = (item.position.x/11.25f*100).ToString ();
		posYString = (-item.position.y/20*100).ToString ();
		scaleXString = (item.scale.x/11.25f*100).ToString ();
		scaleYString = (item.scale.y/20*100).ToString ();
		if (item.imageMaterial != null) {
			imageString = item.imageMaterial.name;
		} else {
			imageString = "defaultButton";
		}
		clickable = item.imageTapple;
		if (clickable) {
			usingTex = visibleTex;
		} else {
			usingTex = notVisibleTex;
		}
	}
	
	void OnGUI(){
		if (enabled) {
			moveImage();
			GUI.DrawTexture(new Rect(Screen.width* 0.6582f, 0, Screen.width * 0.3418f, Screen.height), background);
			textStyle.fontSize = (42*Screen.width)/1920;
			ImageName = GUI.TextArea (new Rect (Screen.width * (0.02f+0.6582f), Screen.height * 0.195f, Screen.width * 0.23f, Screen.height * 0.1f), ImageName, textStyle);
			posXString = GUI.TextArea (new Rect (Screen.width * (0.08f+0.6582f), Screen.height * 0.315f, Screen.width * 0.05f, Screen.height * 0.05f), posXString, textStyle);
			posYString = GUI.TextArea (new Rect (Screen.width * (0.225f+0.6582f), Screen.height * 0.315f, Screen.width * 0.05f, Screen.height * 0.05f), posYString, textStyle);
			scaleXString = GUI.TextArea (new Rect (Screen.width * (0.08f+0.6582f), Screen.height * 0.44f, Screen.width * 0.05f, Screen.height * 0.05f), scaleXString, textStyle);
			scaleYString = GUI.TextArea (new Rect (Screen.width * (0.225f+0.6582f), Screen.height * 0.44f, Screen.width * 0.05f, Screen.height * 0.05f), scaleYString, textStyle);
			imageString = GUI.TextArea (new Rect (Screen.width *( 0.028f+0.6582f), Screen.height * 0.565f, Screen.width * 0.27f, Screen.height * 0.05f), imageString, textStyle);
			textStyle.fontSize = (55*Screen.width)/1920;
			GUI.TextField (new Rect (Screen.width * (0.06f+0.6582f), Screen.height * 0.02f, Screen.width * 0.23f, Screen.height * 0.1f), ImageName, textStyle);
			if(GUI.Button(new Rect (Screen.width * (0.225f+0.65825f), Screen.height * 0.688f, Screen.width * 0.035f, Screen.height * 0.055f),usingTex, textStyle)){
				clickable = !clickable;
				if (clickable) {
					usingTex = visibleTex;
				} else {
					usingTex = notVisibleTex;
				}
			}
			GUI.color = Color.clear;
			if (GUI.Button (new Rect (Screen.width * (0.28f+0.6582f), Screen.height * 0.11f, Screen.width * 0.058f, Screen.height * 0.1f), "")) {
				foreach(GameObject page in data.matchingPages.PageArray[data.selectedPage].GetComponent<PageTemplate>().objects){
					if(page.GetComponent<ItemVariables>().itemName==item.itemName){
						if(!gameObject.GetComponent<App_TemplateEditor>().enabled){
							data.matchingPages.PageArray[data.selectedPage].GetComponent<PageTemplate>().objects.Remove(page);
							break;
						}
					}
				}
				foreach(GameObject page in data.matchingPages.PageArray[data.selectedPage].GetComponent<PageTemplate>().templateObjects){
					if(page.GetComponent<ItemVariables>().itemName==item.itemName){
						if(gameObject.GetComponent<App_TemplateEditor>().enabled){
							data.matchingPages.PageArray[data.selectedPage].GetComponent<PageTemplate>().templateObjects.Remove(page);
							
							break;
						}
					}
				}
				foreach(GameObject image in GameObject.FindGameObjectsWithTag("Button")){
					if(image.GetComponent<ItemVariables>().itemName == item.itemName){
						Destroy(image);
					}
				}
				GetComponent<ObjectLibrary>().enabled = true;
				enabled = false;
			}
			if (GUI.Button (new Rect (Screen.width * (0.06f+0.6582f), Screen.height * 0.782f, Screen.width * 0.23f, Screen.height * 0.1f), "")) {
				if (float.TryParse (posXString, out posX) == true &&
				    float.TryParse (posYString, out posY) == true &&
				    float.TryParse (scaleXString, out scaleX) == true &&
				    float.TryParse (scaleYString, out scaleY) == true) {
					activeGameObject = GameObject.Find (item.itemName+"(Clone)").GetComponent<ItemVariables> ();
					foreach(Texture image in images.images){
						if(image.name == imageString){
							item.imageMaterial = image;
							activeGameObject.imageMaterial = image;
							activeGameObject.gameObject.renderer.material.mainTexture = image;
						}
					}
					posX = float.Parse (posXString);
					posY = float.Parse (posYString);
					scaleX = float.Parse (scaleXString);
					scaleY = float.Parse (scaleYString);
					item.itemName = ImageName;
					item.gameObject.name = ImageName;
					item.name = ImageName;
					item.position.x = 0.1125f*posX;
					item.position.y = -0.2f*posY;
					item.scale.x = scaleX/100*11.25f;
					item.scale.y = scaleY/100*20;
					item.buttonLeft = item.position.x/20;
					item.buttonTop = -item.position.y/20;
					item.buttonTopStart = -item.position.y/20;
					item.buttonWidth = item.scale.x/11.25f;
					item.buttonHeight = item.scale.y/20;
					item.imageTapple = clickable;
					activeGameObject.itemName = ImageName;
					activeGameObject.gameObject.name = ImageName+"(Clone)";
					activeGameObject.position.x = item.position.x;
					activeGameObject.position.y = item.position.y;
					scaleOffset = new Vector3(5.625f - item.scale.x/2,-10 + item.scale.y/2);
					activeGameObject.transform.position = new Vector3(item.position.x - scaleOffset.x,item.position.y - scaleOffset.y,activeGameObject.transform.position.z);
					activeGameObject.scale.x = item.scale.x;
					activeGameObject.scale.y = item.scale.y;
					activeGameObject.transform.localScale = new Vector3(item.scale.x,item.scale.y,activeGameObject.transform.localScale.z);
					activeGameObject.buttonLeft = item.position.x/20;
					activeGameObject.buttonTop = -item.position.y/20;
					activeGameObject.buttonTopStart = -item.position.y/20;
					activeGameObject.buttonWidth = item.scale.x/11.25f;
					activeGameObject.buttonHeight = item.scale.y/20;
					activeGameObject.selected = false;
					activeGameObject.imageTapple = clickable;
					Buttons = GameObject.FindGameObjectsWithTag("Button");
					foreach(GameObject but in Buttons){
						but.GetComponent<ItemVariables>().selected = false;
						but.GetComponent<ItemVariables>().gathered = false;
					}
					GetComponent<ObjectLibrary>().enabled = true;
					Reset();
					enabled = false;
				}
			}
		}
	}

	void moveImage(){
		if (Event.current.shift) {
			if (Input.GetMouseButton (0) && Input.mousePosition.x>(Screen.width*screenOffset) && Input.mousePosition.x<Screen.width*(screenOffset)+screenRes.x) {
				if (!mouseClick) {
					mousestart = new Vector2 (Input.mousePosition.x, Input.mousePosition.y);
					mouseClick = true;
				} 
				else if (mouseClick){
					diff = mousestart - new Vector2 (Input.mousePosition.x, Input.mousePosition.y);
					diff = new Vector2 ((diff.x / screenRes.x) * -100, (diff.y / screenRes.y) * 100);
					newPos = (movePos + diff);
					posXString = newPos.x.ToString ();
					posX = newPos.x;
					posY = newPos.y;
					posYString = newPos.y.ToString ();
					item.position.x = 0.1125f * newPos.x;
					item.position.y = -0.2f * newPos.y;
					scaleOffset = new Vector3 (5.625f - item.scale.x / 2, -10 + item.scale.y / 2);
					itemObject.transform.position = new Vector3 (item.position.x - scaleOffset.x, item.position.y - scaleOffset.y, itemObject.transform.position.z);
				}
			} 
			if (Input.GetMouseButtonUp (0) && mouseClick) {
				diff = Vector2.zero;
				movePos = newPos;
				mouseClick = false;
			}
		}
		GUI.DrawTexture(new Rect ((Screen.width * screenOffset) + (screenRes.x/100*(movePos.x+diff.x)), screenRes.y/100*(movePos.y+diff.y), screenRes.x*(item.scale.x/11.25f), screenRes.y*(item.scale.y/20)),selectedImage,ScaleMode.StretchToFill);
	}

	void scaleImage(){

	}

}
