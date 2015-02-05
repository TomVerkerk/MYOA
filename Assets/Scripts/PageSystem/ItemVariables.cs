using UnityEngine;
using System.Collections;

public class ItemVariables : MonoBehaviour {

	public int currentPage;
	public Vector3 position;
	public Vector2 scale;
	public bool backEnabled;
	public bool scrollable;
	public float length;
	public float scrollSpeed;
	public bool text;
	public bool button;
	public bool image;
	public bool site;
	public bool crisischeck;
	public bool exit;
	public Material imageMaterial;
	public float buttonLeft;
	public float buttonTop;
	public float buttonWidth;
	public float buttonHeight;
	public int buttonGoesToPage;
	public int backGoesToPage;
	public string siteURL;
	private Pages pages;
	private Vector2 screenRes;
	private CrisisCheck chrisisC;
	private GameObject[] Buttons;
	private Vector2 touchBegin;
	private Vector2 touchEnd;

	void Start(){
		screenRes.x = Screen.width;
		screenRes.y = Screen.height;
		pages = GameObject.FindGameObjectWithTag ("Pages").GetComponent<Pages> ();
		if (image) {
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
					Destroy(chrisisC.aanmelden);
				}
				foreach(GameObject buttonObject in Buttons){
					if(buttonObject!=null){
						Destroy(buttonObject);
					}
				}
				button= false;
			}
		}
	}

	void Update(){
		if (scrollable) {
			foreach (var T in Input.touches) {
				if (T.phase == TouchPhase.Began) {
					touchBegin = T.position;
				} 
				else if (T.phase == TouchPhase.Moved) {
					touchEnd = touchBegin - T.position;
				}
				//else if(T.phase == TouchPhase.Stationary)
			}
			if(Input.touches.Length == 0){
				touchEnd/=2;
			}
			if(transform.position.y < (length+position.y)&&transform.position.y > position.y||transform.position.y >= (length+position.y)&& touchEnd.y > 0 || transform.position.y <= position.y && touchEnd.y < 0){
				transform.position += new Vector3(0,-touchEnd.y*scrollSpeed,0);
			}
		//	else if(transform.position.y > (length+position.y)&& touchEnd.y > 0 || transform.position.y < position.y && touchEnd.y < 0)
		}
		if (backEnabled) {
			if(Input.GetKeyDown(KeyCode.Escape)){
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
					Destroy(chrisisC.aanmelden);
				}
				Buttons = GameObject.FindGameObjectsWithTag("Button");
				pages.openPage (backGoesToPage);
				foreach(GameObject buttonObject in Buttons){
					if(buttonObject.gameObject!=null){
						Destroy(buttonObject);
					}
				}
			}
		}
	}
}
