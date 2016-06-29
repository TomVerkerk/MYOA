using UnityEngine;
using System.Collections;

public class App_Pages : MonoBehaviour {
	
	public bool enabled = false;
	private Database data;
	public Texture background;
	public Texture buttonBackground;
	public GUIStyle style;
	private int buttonCount = 1;
	private Images images;
	private string buttonText;
	private float textOffset;
	public bool opened = false;
	private float sliderIndex = 0;
	private Pages pages;
	public bool templateMenuOpened = false;
	private float buttonOffset;

	void Start(){
		data = gameObject.GetComponent<Database> ();
		images = gameObject.GetComponent<Images>();
		foreach (Texture image in images.images) {
			if(data.taal == Database.language.English){
				if(image.name == "AppPagesEnglish"){
					background = image;
				}
				buttonText = "New Page";
				textOffset = 0.0475f;
			}
			if(data.taal == Database.language.Nederlands){
				if(image.name == "AppPages"){
					background = image;
				}
				buttonText = "Nieuwe Pagina";
				textOffset = 0.015f;
			}
		}
		style.fontSize = (50*Screen.width)/1920;
	}
	
	void OnGUI(){
		if (enabled) {
			buttonOffset = 0.18f;
			if(!templateMenuOpened){
				buttonOffset = 0.257f;
				if (GUI.Button (new Rect (Screen.width * 0.0648f, Screen.height * 0.25f, Screen.width * 0.23f, Screen.height * 0.05f), buttonBackground, style)) {
					GetComponent<App_NewPage>().enabled = true;
					GetComponent<AppChangeImage>().pageOpened = true;
					GetComponent<AppChangeImage>().enabled = false;
					GetComponent<AppChangeButton>().enabled = false;
					GetComponent<App_Button>().enabled = false;
					GetComponent<App_Image>().enabled = false;
					GetComponent<App_Image>().pageOpened = true;
				}
				GUI.TextArea(new Rect (Screen.width * (0.1648f - (buttonText.Length * 0.0057f)), Screen.height * 0.25f, Screen.width * 0.23f, Screen.height * 0.05f), buttonText, style);
				foreach(PageTemplate page in data.matchingPages.PageArray){
					if (GUI.Button (new Rect (Screen.width * 0.0648f, Screen.height * (buttonOffset + (0.07f * (buttonCount))), Screen.width * 0.23f, Screen.height * 0.05f), buttonBackground, style)) {
						GetComponent<App_NewPage>().enabled = false;
						GetComponent<AppChangeImage>().enabled = false;
						GetComponent<AppChangeButton>().enabled = false;
						opened = true;
						GetComponent<App_Button>().enabled = false;
						GetComponent<App_Image>().enabled = false;
						GetComponent<AppChangeImage>().pageOpened = true;
						GetComponent<App_Image>().pageOpened = true;
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
						if(templateMenuOpened){
							pages.PageArray[page.index].templateOnly = true;
						}
						else{
							pages.PageArray[page.index].templateOnly = false;
						}
						data.selectedPage = page.index;
						GetComponent<SelectionGatherer>().enabled = false;
						GetComponent<AppChangeImage>().enabled = false;
						GetComponent<AppChangeButton>().enabled = false;
						GetComponent<ObjectLibrary>().enabled = true;
						pages.openPage(page.index);
					}
					GUI.TextArea(new Rect (Screen.width * (0.1648f - (page.pageName.Length * 0.0052f)), Screen.height * (buttonOffset + (0.07f * (buttonCount))), Screen.width * 0.23f, Screen.height * 0.05f), page.pageName, style);
					buttonCount++;
				}
				if(buttonCount>11){
					sliderIndex = GUI.VerticalScrollbar(new Rect(Screen.width*0.97f,Screen.height*0.17f,Screen.width*0.03f,Screen.height*0.8f),sliderIndex,10,0,110);
				}
			}
			buttonCount=1;
		}
	}
}
