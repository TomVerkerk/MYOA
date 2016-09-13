using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif
using System.Collections;

public class App_Button : MonoBehaviour {

	public bool enabled = false;
	private Texture background;
	private Images images;
	private string buttonName = "New Button";
	private GUIStyle textStyle;
	private Database data;
	private App_Menu appMenu;
	public bool image;
	private Texture buttonImage;
	private Texture defaultImage;

	private float posX = 0;
	private string posXString = "0";
	private float posY = 0;
	private string posYString = "0";
	
	private float scaleX = 0;
	private string scaleXString = "0";
	private float scaleY = 0;
	private string scaleYString = "0";
	
	private string imageString = "defaultButton";
	
	private int toPage;
	private string toPageString = "0";

	void Start(){
		appMenu = GetComponent<App_Menu> ();
		data = GetComponent<Database> ();
		textStyle = new GUIStyle ();
		images = GetComponent<Images> ();
		foreach (Texture tex in images.images) {
			if(tex.name == "AppButton"){
				background = tex;
			}
			if(tex.name == "defaultButton"){
				buttonImage = tex;
			}
		}
	}

	public void Reset(){
		buttonName = "New Button";
		posXString = "0";
		posYString = "0";
		scaleXString = "0";
		scaleYString = "0";
		toPageString = "0";
		imageString = "defaultButton";
	}

	void OnGUI(){
		if (enabled) {
			GUI.DrawTexture(new Rect(Screen.width* 0.6582f, 0, Screen.width * 0.3418f, Screen.height),background);
			textStyle.fontSize = (55*Screen.width)/1920;
			GUI.TextField(new Rect(Screen.width * 0.7182f, Screen.height * 0.02f, Screen.width * 0.23f, Screen.height * 0.1f), buttonName, textStyle);
			textStyle.fontSize = (42*Screen.width)/1920;
			buttonName = GUI.TextArea (new Rect (Screen.width * 0.6782f, Screen.height * 0.20f, Screen.width * 0.23f, Screen.height * 0.1f), buttonName, textStyle);

			posXString = GUI.TextArea (new Rect (Screen.width * 0.7382f, Screen.height * 0.315f, Screen.width * 0.05f, Screen.height * 0.05f), posXString, textStyle);
			posYString = GUI.TextArea (new Rect (Screen.width * 0.8832f, Screen.height * 0.315f, Screen.width * 0.05f, Screen.height * 0.05f), posYString, textStyle);
			scaleXString = GUI.TextArea (new Rect (Screen.width * 0.7382f, Screen.height * 0.44f, Screen.width * 0.05f, Screen.height * 0.05f), scaleXString, textStyle);
			scaleYString = GUI.TextArea (new Rect (Screen.width * 0.8832f, Screen.height * 0.44f, Screen.width * 0.05f, Screen.height * 0.05f), scaleYString, textStyle);
			toPageString = GUI.TextArea (new Rect (Screen.width * 0.7382f, Screen.height * 0.69f, Screen.width * 0.05f, Screen.height * 0.05f), toPageString, textStyle);
			imageString = GUI.TextArea (new Rect (Screen.width * 0.6862f, Screen.height * 0.565f, Screen.width * 0.27f, Screen.height * 0.05f), imageString, textStyle);
			GUI.color = Color.clear;
			if(GUI.Button(new Rect(Screen.width*0.7182f,Screen.height*0.783f,Screen.width*0.233f,Screen.height*0.1f),"")){
				if (float.TryParse (posXString, out posX) == true &&
				    float.TryParse (posYString, out posY) == true &&
				    float.TryParse (scaleXString, out scaleX) == true &&
				    float.TryParse (scaleYString, out scaleY) == true &&
				    int.TryParse(toPageString, out toPage) == true) {
					GameObject prefabload = new GameObject();
					prefabload = Resources.Load("BlankElement") as GameObject;
					GameObject prefab = Instantiate(prefabload) as GameObject;
					prefab.gameObject.name = buttonName+"(Clone)";
					ItemVariables itemvar = prefab.GetComponent<ItemVariables>();
					itemvar.itemName = buttonName;
					foreach(Texture image in images.images){
						if(image.name == imageString){
							buttonImage = image;
						}
					}
					posX = float.Parse (posXString);
					posY = float.Parse (posYString);
					scaleX = float.Parse (scaleXString);
					scaleY = float.Parse (scaleYString);
					toPage = int.Parse(toPageString);
					itemvar.buttonTexture = buttonImage;
					itemvar.currentPage = data.selectedPage;
					itemvar.buttonLeft = posX/100;
					itemvar.buttonTop = posY/100;
					itemvar.buttonTopStart = posY/100;
					itemvar.buttonWidth = scaleX/100;
					itemvar.buttonHeight = scaleY/100;
					itemvar.buttonGoesToPage = toPage-1;
					itemvar.buttonVisable = true;
					itemvar.button = true;
					itemvar.image = false;
					itemvar.imageOverlaying = false;
					GameObject save = PrefabUtility.CreatePrefab("Assets/Elements/"+data.AppTitle+"/"+buttonName+".prefab",prefab);
					data.databaseObject.GetComponent<Pages>().PageArray[data.selectedPage].objects.Add(save);
					if(GameObject.FindGameObjectWithTag("Scroller")!=null){
						GameObject.FindGameObjectWithTag("Scroller").GetComponent<Scroller>().attached.Add(prefab);
					}
					enabled = false;
					Reset();
				}
			}
		}
	}
}
