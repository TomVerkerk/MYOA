using UnityEngine;
using System.Collections;

public class App_Buttons : MonoBehaviour {

	public bool enabled = false;
	private Database data;
	private int buttonCount = 1;
	private bool placed = false;
	public Texture background;
	public Texture buttonBackground;
	public Texture white;
	public GUIStyle style;
	public GUIStyle headerStyle;
	private float sliderIndex = 0;
	private bool first = true;

	void Start(){
		data = this.gameObject.GetComponent<Database> ();
		style.fontSize = (42*Screen.width)/1920;
		headerStyle.fontSize = (31*Screen.width)/1920;
	}
	
	void OnGUI(){
		if (enabled) {
			GUI.DrawTexture(new Rect(Screen.width* 0.6582f, 0, Screen.width*0.3418f, Screen.height),white);
			GUI.DrawTexture(new Rect (Screen.width * 0.72f, Screen.height * (0.16f- sliderIndex), Screen.width * 0.23f, Screen.height * 0.05f), buttonBackground);
			if (GUI.Button(new Rect(Screen.width * 0.72f, Screen.height * (0.165f-sliderIndex), Screen.width * 0.23f, Screen.height * 0.05f),"",style)){
				GetComponent<App_Menu>().enabled = false;
				GetComponent<AppChangeButton>().enabled = false;
				if(GetComponent<AppChangeButton>().activeGameObject!=null){
					GetComponent<AppChangeButton>().Reset();
				}
				GetComponent<App_Button>().enabled = true;
			}
			GUI.TextArea(new Rect(Screen.width*0.775f,Screen.height*(0.165f-sliderIndex),Screen.width*0.1f,Screen.height*0.04f),"New Button",style);
			GUI.DrawTexture(new Rect (Screen.width * 0.72f, Screen.height * (0.23f- sliderIndex), Screen.width * 0.23f, Screen.height * 0.05f), buttonBackground);
			if (GUI.Button(new Rect(Screen.width * 0.72f, Screen.height * (0.235f-sliderIndex), Screen.width * 0.23f, Screen.height * 0.05f),"",style)){
				GetComponent<App_Menu>().enabled = false;
				GetComponent<AppChangeButton>().enabled = false;
				if(GetComponent<AppChangeButton>().activeGameObject!=null){
					GetComponent<AppChangeButton>().Reset();
				}
				GetComponent<ButtonLibrary>().enabled = true;
			}
			GUI.TextArea(new Rect(Screen.width*0.775f,Screen.height*(0.235f-sliderIndex),Screen.width*0.1f,Screen.height*0.04f),"Button Library",style);
			foreach(GameObject variables in data.matchingPages.PageArray[data.selectedPage].objects){
				if(variables.gameObject.GetComponent<ItemVariables>().button == true){
					if (GUI.Button (new Rect (Screen.width * 0.723f, Screen.height * (0.235f + (0.07f * buttonCount) - sliderIndex), Screen.width * 0.23f, Screen.height * 0.05f), buttonBackground, style)) {
						first = false;
						GetComponent<AppChangeButton>().enabled = false;
						GetComponent<AppChangeButton>().item = variables.gameObject.GetComponent<ItemVariables>();
						GetComponent<AppChangeButton>().itemObject = variables;
						GetComponent<AppChangeButton>().Reset();
						GetComponent<AppChangeButton>().enabled = true;
						GetComponent<App_Button>().enabled = false;
						GetComponent<App_Menu>().enabled = false;
					}
					GUI.TextArea(new Rect (Screen.width * (0.824f - (variables.gameObject.GetComponent<ItemVariables>().name.Length * 0.0052f)), Screen.height * (0.235f + (0.07f * buttonCount) - sliderIndex), Screen.width * 0.001f, Screen.height * 0.1f), variables.gameObject.GetComponent<ItemVariables>().name, style);
					buttonCount++;
				}
			}
			GUI.DrawTexture(new Rect(Screen.width* 0.6582f, 0, Screen.width*0.3418f, Screen.height),background);
			if((buttonCount+1)>12){
				sliderIndex = GUI.VerticalScrollbar(new Rect(Screen.width*0.97f,Screen.height*0.17f,Screen.width*0.03f,Screen.height*0.8f),sliderIndex,0.01f,0,(buttonCount-12)*0.07f);
			}
			buttonCount = 1;
		}
	}
}
