using UnityEngine;
using System.Collections;

public class ItemVariables : MonoBehaviour {

	public string itemName;
	public int currentPage;
	public Vector3 position;
	public Vector2 scale;
	public bool backEnabled;
	public bool button;
	public bool buttonVisable;
	public bool attachedToCam;
	public bool moveButton;
	public float place;
	public bool toTopButton;
	public bool dialButton;
	public string phoneNumber;
	public bool menuBar;
	public bool menuOpen = false;
	public bool image;
	public bool imageOverlaying;
	public bool imageTapple;
	public Vector2 imageTiling;
	public Vector2 imageOffset;
	public bool slider;
	public bool site;
	public string siteURL;
	public bool crisischeck;
	public bool exit;
	public Texture imageMaterial;
	public Texture buttonTexture;
	public float buttonLeft;
	public float buttonTopStart = 0;
	public float buttonTop;
	public float buttonWidth;
	public float buttonHeight;
	public int buttonGoesToPage;
	public int backGoesToPage;
	private Pages pages;
	private Vector2 screenRes;
	private CrisisCheck chrisisC;
	private GameObject[] Buttons;
	public GUIStyle buttonStyle;
	private Texture defaultButton;
	public bool templateItem = false;
	public bool pc;
	private GameObject ui = null;
	private float screenOffset;
	private MenuBar menu;
	private Texture imageZoomBackground;
	private Scroller scroller;
	private ImagePlayer imagePlayer;
	public bool selected = false;
	public bool shift = false;
	private Texture selectedImage;
	private SelectionGatherer gatherer;
	public bool gathered = false;
	private bool click = false;
	private Vector2 save = Vector2.zero;
	private Vector2 movePos = Vector2.zero;
	private Vector2 newPos= Vector2.zero;
	private Vector3 scaleOffset = Vector3.zero;

	void Start(){
		buttonStyle = new GUIStyle ();
		buttonStyle.alignment = TextAnchor.MiddleCenter;
#if UNITY_EDITOR
		screenOffset = 0.3418f;
		pc = true;
#elif UNITY_ANDROID
		screenOffset = 0;
		pc = false;
#endif
		if (pc) {
			screenRes.x = Screen.width * 0.3164f;
			screenRes.y = Screen.height;
			ui = GameObject.FindGameObjectWithTag("UI");
		}
		else {
			screenRes.x = Screen.width;
			screenRes.y = Screen.height;
			ui = Resources.Load ("UI") as GameObject;
		}
		pages = GameObject.FindGameObjectWithTag ("Pages").GetComponent<Pages> ();
		if (slider) {
			gameObject.renderer.material.mainTexture = GetComponent<Slider>().images[0];
		}
		else if (image) {
			gameObject.renderer.material.mainTexture = imageMaterial;
		}
		else {
			gameObject.renderer.enabled = false;
		}
		if (imageTiling == Vector2.zero) {
			imageTiling = new Vector2(1,1);
		}
		if (image && !imageTapple) {
			GetComponent<BoxCollider> ().enabled = true;
		} else {
			gameObject.GetComponent<BoxCollider>().enabled=false;
		}
		gameObject.renderer.material.mainTextureScale = imageTiling;
		gameObject.renderer.material.mainTextureOffset = imageOffset;
		Images images = ui.GetComponent<Images>();
		foreach(Texture tex in images.images){
			if(tex.name == "defaultButton"){
				defaultButton = tex;
			}
			if(tex.name == "ImageZoomBackground"){
				imageZoomBackground = tex;
			}
			if(tex.name == "SelectedImage"){
				selectedImage = tex;
			}
		}
		if(buttonTexture == null){
			buttonTexture = defaultButton;
		}
		buttonTopStart = buttonTop;
		if (menuBar) {
			menu = GetComponent<MenuBar>();
			menu.background.GetComponent<ItemVariables>().position.y = position.y;
		}
		if (image) {
			if(imageTapple){
				button = true;
			}
			if(imageOverlaying){
				transform.position = new Vector3(transform.position.x,transform.position.y,-1);
			}
			else{
				transform.position = new Vector3(transform.position.x,transform.position.y,0);
			}
			buttonLeft = position.x/20;
			buttonTop = -position.y/20;
			buttonTopStart = -position.y/20;
			buttonWidth = scale.x/11.25f;
			buttonHeight = scale.y/20;
		}
		imagePlayer = GameObject.FindGameObjectWithTag ("ImagePlayer").GetComponent<ImagePlayer> ();
		GameObject scroll = GameObject.FindGameObjectWithTag ("Scroller");
		if (scroll != null) {
			scroller = scroll.GetComponent<Scroller> ();
		}
		gatherer = GameObject.FindGameObjectWithTag("UI").GetComponent<SelectionGatherer> ();
	}

	public void setSelection(){
		gathered = false;
		gatherer.clearSelection ();
		Buttons = GameObject.FindGameObjectsWithTag("Button");
		if(selected){
			selected=false;
			ui.GetComponent<AppChangeImage>().enabled = false;
			ui.GetComponent<AppChangeButton>().enabled = false;
			ui.GetComponent<ObjectLibrary>().enabled = true;
		}
		else{
			foreach(GameObject buttonObject in Buttons){
				buttonObject.GetComponent<ItemVariables>().selected=false;
			}
			selected=true;
			ui.GetComponent<Selecter>().clicked = false;
			ui.GetComponent<ObjectLibrary>().enabled = false;
			ui.GetComponent<App_NewPage>().enabled = false;
			ui.GetComponent<App_Button>().enabled = false;
			ui.GetComponent<App_Image>().enabled = false;
			if(!templateItem && !ui.GetComponent<App_TemplateEditor>().enabled){
				if(image){
					ui.GetComponent<AppChangeImage>().enabled = false;
					pages=GameObject.FindGameObjectWithTag("Pages").GetComponent<Pages>();
					foreach(GameObject obj in pages.PageArray[ui.GetComponent<Database>().selectedPage].objects){
						if(obj.GetComponent<ItemVariables>().itemName == itemName){
							ui.GetComponent<AppChangeImage> ().item =obj.GetComponent<ItemVariables>();
							foreach(GameObject imageObj in GameObject.FindGameObjectsWithTag("Button")){
								if(imageObj.GetComponent<ItemVariables>().itemName == itemName){
									ui.GetComponent<AppChangeImage>().itemObject = imageObj;
								}
							}
							movePos = new Vector2(obj.GetComponent<ItemVariables>().position.x/11.25f*100,-obj.GetComponent<ItemVariables>().position.y/20*100);
						}
					}
					ui.GetComponent<AppChangeImage> ().pageOpened = true;
					ui.GetComponent<AppChangeImage> ().Reset ();
					ui.GetComponent<AppChangeImage>().enabled = true;
					ui.GetComponent<AppChangeButton>().enabled = false;
				}
				else if(button){
					ui.GetComponent<AppChangeButton>().enabled = false;
					pages = GameObject.FindGameObjectWithTag("Pages").GetComponent<Pages>();
					foreach(GameObject obj in pages.PageArray[ui.GetComponent<Database>().selectedPage].objects){
						if(obj.GetComponent<ItemVariables>().itemName == itemName){
							ui.GetComponent<AppChangeButton>().item = obj.GetComponent<ItemVariables>();
							ui.GetComponent<AppChangeButton>().itemObject = obj;
							movePos = new Vector2(buttonLeft*100,buttonTop*100);
						}
					}
					ui.GetComponent<AppChangeButton>().Reset();
					ui.GetComponent<AppChangeButton>().enabled = true;
					ui.GetComponent<AppChangeImage>().enabled = false;
				}
			}
			else if(templateItem && ui.GetComponent<App_TemplateEditor>().enabled){
				if(image){
					pages=GameObject.FindGameObjectWithTag("Pages").GetComponent<Pages>();
					foreach(GameObject obj in pages.templateObjects){
						if(obj.GetComponent<ItemVariables>().itemName == itemName){
							ui.GetComponent<AppChangeImage> ().item =obj.GetComponent<ItemVariables>();
							foreach(GameObject imageObj in GameObject.FindGameObjectsWithTag("Button")){
								if(imageObj.GetComponent<ItemVariables>().itemName == itemName){
									ui.GetComponent<AppChangeImage>().itemObject = imageObj;
								}
							}
							ui.GetComponent<AppChangeImage>().movePos = new Vector2(obj.GetComponent<ItemVariables>().position.x/11.25f*100,-obj.GetComponent<ItemVariables>().position.y/20*100);
						}
					}
					ui.GetComponent<AppChangeImage> ().pageOpened = true;
					ui.GetComponent<AppChangeImage> ().Reset ();
					ui.GetComponent<AppChangeImage>().enabled = true;
					ui.GetComponent<AppChangeButton>().enabled = false;
				}
				else if(button){
					pages = GameObject.FindGameObjectWithTag("Pages").GetComponent<Pages>();
					foreach(GameObject obj in pages.templateObjects){
						if(obj.GetComponent<ItemVariables>().itemName == itemName){
							ui.GetComponent<AppChangeButton>().item = obj.GetComponent<ItemVariables>();
							foreach(GameObject buttonObj in GameObject.FindGameObjectsWithTag("Button")){
								if(buttonObj.GetComponent<ItemVariables>().itemName == itemName){
									ui.GetComponent<AppChangeButton>().itemObject = buttonObj;
								}
							}
							ui.GetComponent<AppChangeButton>().movePos = new Vector2(buttonLeft*100,buttonTop*100);
						}
					}
					ui.GetComponent<AppChangeButton>().Reset();
					ui.GetComponent<AppChangeButton>().enabled = true;
					ui.GetComponent<AppChangeImage>().enabled = false;
				}
			}
		}
	}

	void OnGUI(){
		if (!buttonVisable) {
			GUI.color = Color.clear;
		}

		if(Input.GetMouseButtonDown(0)){
			ui.GetComponent<Selecter>().nothingClicked = true;
		}
		if (button && imagePlayer.opened==false) {
			if(scroller == null || scroller.on && !scroller.moved || scroller.on==false){
				if(GUI.Button (new Rect ((Screen.width * screenOffset) + screenRes.x*buttonLeft, screenRes.y*buttonTop, screenRes.x*buttonWidth, screenRes.y*buttonHeight),buttonTexture,buttonStyle)){
					Buttons = GameObject.FindGameObjectsWithTag("Button");
					ui.GetComponent<Selecter>().nothingClicked = false;
					if(shift){
						if(!templateItem && !ui.GetComponent<App_TemplateEditor>().enabled||
						   templateItem && ui.GetComponent<App_TemplateEditor>().enabled){
							if(!gathered && ui.GetComponent<ObjectLibrary>().enabled ||
							   !gathered && gatherer.enabled){
								gatherer.addToSelection(this);
								gathered = true;
							}
						}
					}
					else{
						if(site){
							#if UNITY_ANDROID || UNITY_EDITOR
							Application.OpenURL("http://"+siteURL);
							#endif
						}
						else if(exit){
							Application.Quit();
						}
						else if(menuBar){
							menuOpen = !menuOpen;
							menu.OpenClose(menuOpen);
						}
						else if(image){
							if(imageTapple){
								scroller.on = false;
								Texture[] images={imageMaterial};
								imagePlayer.openImage(images,0);
							}
						}
						else if(toTopButton){
							scroller.Reset();
						}
						else if (moveButton){
							scroller.Reset();
							#if UNITY_EDITOR
							scroller.testScroll += new Vector2(0,-place);
							#endif
						}
						else if(dialButton){
							#if UNITY_ANDROID
							Application.OpenURL("tel://"+phoneNumber);
							#endif
						}
						else{
							if(buttonGoesToPage >=0){
								if(GameObject.FindGameObjectWithTag ("Scroller")!=null){
									GameObject.FindGameObjectWithTag ("Scroller").GetComponent<Scroller> ().Reset();
									Destroy(GameObject.FindGameObjectWithTag("Scroller"));
								}
								GameObject.FindGameObjectWithTag("ImagePlayer").GetComponent<ImagePlayer>().closeImage();
								ui.GetComponent<AppChangeButton>().enabled = false;
								ui.GetComponent<Database>().selectedPage = buttonGoesToPage;
								ui.GetComponent<AppChangeImage>().enabled = false;
								ui.GetComponent<ObjectLibrary>().enabled = true;
								pages.openPage (buttonGoesToPage);
							}
						}
						if(crisischeck){
							chrisisC = GameObject.FindGameObjectWithTag("CrisisCheck").gameObject.GetComponent<CrisisCheck>();
							chrisisC.check1.gameObject.SetActive(true);
							chrisisC.check2.gameObject.SetActive(true);
							chrisisC.check3.gameObject.SetActive(true);
							chrisisC.check4.gameObject.SetActive(true);
							chrisisC.check5.gameObject.SetActive(true);
							Destroy(chrisisC.check1);
							Destroy(chrisisC.check2);
							Destroy(chrisisC.check3);
							Destroy(chrisisC.check4);
							Destroy(chrisisC.check5);
							Destroy(chrisisC.aanmelden);
							GameObject PHolder;
							PHolder = GameObject.FindGameObjectWithTag("CrisisCheck");
							Destroy(PHolder);
							if(chrisisC.beoordeeling){
								Destroy(GameObject.FindGameObjectWithTag ("BeoordeelButton"));
							}
						}
						foreach(GameObject buttonObject in Buttons){
							if(buttonObject!=null && !site && !toTopButton && !dialButton && !menuBar && !imageTapple && !moveButton && !image && buttonGoesToPage>=0){
								buttonObject.SetActive(true);
								Destroy(buttonObject);
							}
						}
						if(!site && !toTopButton && !dialButton && !menuBar && !imageTapple && !moveButton && !image && buttonGoesToPage>=0){
							button= false;
						}
					}
				}
			}
		}
	}
}
