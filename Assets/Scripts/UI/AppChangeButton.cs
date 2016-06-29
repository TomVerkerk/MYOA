using UnityEngine;
using System.Collections;

public class AppChangeButton : MonoBehaviour {

	public bool enabled = false;
	public ItemVariables item;
	public GameObject itemObject;
	private Texture background;
	private Images images;
	private Database data;
	private GUIStyle textStyle;
	private string buttonName;
	public ItemVariables activeGameObject;
	private bool visible;
	private bool inTemplate = false;
	private Texture visibleTex;
	private Texture notVisibleTex;
	private Texture usingTex;
	private Texture inTemplateImg;

	public float posX = 0;
	public string posXString = "-1";
	public float posY = 0;
	public string posYString = "-1";

	public float scaleX = 0;
	public string scaleXString = "-1";
	public float scaleY = 0;
	public string scaleYString = "-1";

	private string imageString = "start";

	private int toPage;
	private string toPageString = "-2";


	void Start(){
		textStyle = new GUIStyle ();
		images = GetComponent<Images> ();
		data = GetComponent<Database> ();
		foreach (Texture image in images.images) {
			if(image.name == "AppChangeButton"){
				background = image;
			}
			if(image.name == "visibleTex"){
				visibleTex = image;
			}
			if(image.name == "notVisibleTex"){
				notVisibleTex = image;
			}
		}
	}

	public void Reset(){
		if (item != null) {
			buttonName = item.itemName;
			posXString = (100 * item.buttonLeft).ToString ();
			posYString = (100 * item.buttonTop).ToString ();
			scaleXString = (100 * item.buttonWidth).ToString ();
			scaleYString = (100 * item.buttonHeight).ToString ();
			toPageString = (item.buttonGoesToPage + 1).ToString ();
			visible = item.buttonVisable;
			if (visible) {
				usingTex = visibleTex;
			} else {
				usingTex = notVisibleTex;
			}
			activeGameObject = GameObject.Find (buttonName + "(Clone)").GetComponent<ItemVariables> ();
			activeGameObject.buttonVisable = visible;
			if (item.buttonTexture != null) {
				imageString = item.buttonTexture.name;
			} else {
				imageString = "defaultButton";
			}
		}
	}

	void OnGUI(){
		if (enabled) {
			if (posXString == "-1" ||
			    posYString == "-1" ||
			    scaleXString == "-1" ||
			    scaleYString == "-1" ||
			    toPageString == "-2" ||
			    imageString == "start") {
				posXString = (100 * item.buttonLeft).ToString ();
				posYString = (100 * item.buttonTop).ToString ();
				scaleXString = (100 * item.buttonWidth).ToString ();
				scaleYString = (100 * item.buttonHeight).ToString ();
				toPageString = (item.buttonGoesToPage+1).ToString();
				imageString = item.buttonTexture.name;
				activeGameObject = GameObject.Find (buttonName + "(Clone)").GetComponent<ItemVariables> ();
				visible = item.buttonVisable;
				if (visible) {
					usingTex = visibleTex;
				} else {
					usingTex = notVisibleTex;
				}
			}
			GUI.DrawTexture(new Rect(Screen.width* 0.6582f, 0, Screen.width * 0.3418f, Screen.height), background);
			textStyle.fontSize = (42*Screen.width)/1920;
			buttonName = GUI.TextArea (new Rect (Screen.width * (0.02f+0.6582f), Screen.height * 0.195f, Screen.width * 0.23f, Screen.height * 0.1f), buttonName, textStyle);
			posXString = GUI.TextArea (new Rect (Screen.width * (0.08f+0.6582f), Screen.height * 0.315f, Screen.width * 0.05f, Screen.height * 0.05f), posXString, textStyle);
			posYString = GUI.TextArea (new Rect (Screen.width * (0.225f+0.6582f), Screen.height * 0.315f, Screen.width * 0.05f, Screen.height * 0.05f), posYString, textStyle);
			scaleXString = GUI.TextArea (new Rect (Screen.width * (0.08f+0.6582f), Screen.height * 0.44f, Screen.width * 0.05f, Screen.height * 0.05f), scaleXString, textStyle);
			scaleYString = GUI.TextArea (new Rect (Screen.width * (0.225f+0.6582f), Screen.height * 0.44f, Screen.width * 0.05f, Screen.height * 0.05f), scaleYString, textStyle);
			toPageString = GUI.TextArea (new Rect (Screen.width *( 0.08f+0.6582f), Screen.height * 0.69f, Screen.width * 0.05f, Screen.height * 0.05f), toPageString, textStyle);
			imageString = GUI.TextArea (new Rect (Screen.width * (0.028f+0.6582f), Screen.height * 0.565f, Screen.width * 0.27f, Screen.height * 0.05f), imageString, textStyle);
			textStyle.fontSize = (55*Screen.width)/1920;
			GUI.TextField (new Rect (Screen.width * (0.06f+0.6582f), Screen.height * 0.02f, Screen.width * 0.23f, Screen.height * 0.1f), buttonName, textStyle);
			if(GUI.Button(new Rect (Screen.width * (0.225f+0.65825f), Screen.height * 0.688f, Screen.width * 0.035f, Screen.height * 0.055f),usingTex, textStyle)){
				visible = !visible;
				activeGameObject = GameObject.Find (buttonName+"(Clone)").GetComponent<ItemVariables> ();
				activeGameObject.buttonVisable = visible;
				if (visible) {
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
			if (GUI.Button (new Rect (Screen.width * (0.06f+0.6582f), Screen.height * 0.87f, Screen.width * 0.23f, Screen.height * 0.1f), "")) {
				if (float.TryParse (posXString, out posX) == true &&
					float.TryParse (posYString, out posY) == true &&
					float.TryParse (scaleXString, out scaleX) == true &&
					float.TryParse (scaleYString, out scaleY) == true &&
				    int.TryParse(toPageString, out toPage) == true) {
					activeGameObject = GameObject.Find (item.itemName+"(Clone)").GetComponent<ItemVariables> ();
					foreach(Texture image in images.images){
						if(image.name == imageString){
							item.buttonTexture = image;
							activeGameObject.buttonTexture = image;
						}
					}
					posX = float.Parse (posXString);
					posY = float.Parse (posYString);
					scaleX = float.Parse (scaleXString);
					scaleY = float.Parse (scaleYString);
					toPage = int.Parse(toPageString);
					item.itemName = buttonName;
					item.gameObject.name = buttonName;
					item.name = buttonName;
					item.buttonLeft = posX / 100;
					item.buttonTop = posY / 100;
					item.buttonWidth = scaleX / 100;
					item.buttonHeight = scaleY / 100;
					item.buttonGoesToPage = toPage-1;
					item.buttonVisable = visible;
					activeGameObject.itemName = buttonName;
					activeGameObject.gameObject.name = buttonName+"(Clone)";
					activeGameObject.buttonLeft = posX / 100;
					activeGameObject.buttonTopStart = posY / 100;
					activeGameObject.buttonTop = posY / 100;
					activeGameObject.buttonWidth = scaleX / 100;
					activeGameObject.buttonHeight = scaleY / 100;
					activeGameObject.buttonGoesToPage = toPage-1;
					activeGameObject.buttonVisable = visible;
					itemObject.gameObject.name = buttonName;
					activeGameObject.GetComponent<ItemVariables>().selected = false;
					/*if(GameObject.FindGameObjectWithTag("Scroller")!=null){
						GameObject.FindGameObjectWithTag("Scroller").GetComponent<Scroller>().CheckUse();
					}*/
					Reset();
					GetComponent<ObjectLibrary>().enabled = true;
					enabled = false;
				}
			}
		}
	}

}
