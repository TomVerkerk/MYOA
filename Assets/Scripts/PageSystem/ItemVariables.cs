using UnityEngine;
using System.Collections;

public class ItemVariables : MonoBehaviour {

	public int currentPage;
	public Vector3 position;
	public Vector2 scale;
	public bool backEnabled;
	public bool text;
	public bool button;
	public bool image;
	public bool site;
	public bool crisischeck;
	public bool exit;
//	public bool image;
//	public string TextField;
//	public GUIStyle style;
//	public Texture imageTexture;
//	public GUIStyle stylo;
	public Material imageMaterial;
	public float buttonLeft;
	public float buttonTop;
	public float buttonWidth;
	public float buttonHeight;
//	public float imageWidth;
//	public float imageHeight;
	public int buttonGoesToPage;
	public int backGoesToPage;
	public string siteURL;
	private Pages pages;
	private Vector2 screenRes;
	private CrisisCheck chrisisC;
	private GameObject[] Buttons;

	void Start(){
		screenRes.x = Screen.width;
		screenRes.y = Screen.height;
		pages = GameObject.FindGameObjectWithTag ("Pages").GetComponent<Pages> ();
		if (image) {
			//transform.localScale = new Vector3(imageWidth,imageHeight,1);
			gameObject.renderer.material = imageMaterial;
		}
	}

	void OnGUI(){
		GUI.color = Color.clear;
		if (button) {
			if(GUI.Button (new Rect (screenRes.x*buttonLeft, screenRes.y*buttonTop, screenRes.x*buttonWidth, screenRes.y*buttonHeight),"") ){
				Buttons = GameObject.FindGameObjectsWithTag("Button");
				if(site){
				//Application.OpenURL(siteURL);
				}
				else if(exit){
					Application.Quit();
				}
				else{
					pages.openPage (buttonGoesToPage);
				}
				if(crisischeck){
					chrisisC = this.gameObject.GetComponent<CrisisCheck>();
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
				}
				foreach(GameObject buttonObject in Buttons){
					if(buttonObject!=null){
						Destroy(buttonObject);
						//GUI.enabled = false;
					}
				}
				button= false;
			}
		}
		/*	if(image){
				GUI.DrawTexture(new Rect (screenRes.x*left, screenRes.y*top, screenRes.x*width, screenRes.y*height),imageTexture);
			}*/
//		if (text) {
//			GUI.TextField(new Rect (screenRes.x*left, screenRes.y*top, screenRes.x*width, screenRes.y*height),TextField/*,style*/);
//		}
	}

	void Update(){
		if (backEnabled) {
			if(Input.GetKeyDown(KeyCode.Escape)){
				if(crisischeck){
					Destroy(GameObject.FindGameObjectWithTag ("check1"));
					Destroy(GameObject.FindGameObjectWithTag ("check2"));
					Destroy(GameObject.FindGameObjectWithTag ("check3"));
					Destroy(GameObject.FindGameObjectWithTag ("check4"));
					Destroy(GameObject.FindGameObjectWithTag ("check5"));
				}
				Buttons = GameObject.FindGameObjectsWithTag("Button");
				pages.openPage (backGoesToPage);
				foreach(GameObject buttonObject in Buttons){
					if(buttonObject.gameObject!=null){
						Destroy(buttonObject);
					}
				}
				//pages.closePage(currentPage);
			//	button=false;
			}
		}
	}
}
