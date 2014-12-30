using UnityEngine;
using System.Collections;

public class ItemVariables : MonoBehaviour {

	public int currentPage;
	public Vector3 position;
	public Vector3 scale;
	public bool backEnabled;
	public bool text;
	public bool button;
//	public bool image;
	public string TextField;
	public GUIStyle style;
//	public Texture imageTexture;
//	public GUIStyle stylo;
	public float left;
	public float top;
	public float width;
	public float height;
	public int buttonGoesToPage;
	private Pages pages;
	private Vector2 screenRes;
	private GameObject[] Buttons;

	void Start(){
		screenRes.x = Screen.width;
		screenRes.y = Screen.height;
	}

	void OnGUI(){
		if (button) {
			if(GUI.Button (new Rect (screenRes.x*left, screenRes.y*top, screenRes.x*width, screenRes.y*height), TextField)) {
				Buttons = GameObject.FindGameObjectsWithTag("Button");
				foreach(GameObject buttonObject in Buttons){
					if(buttonObject!=null){
						Destroy(buttonObject);
					}
				}
				pages = GameObject.FindGameObjectWithTag ("Pages").GetComponent<Pages> ();
				pages.openPage (buttonGoesToPage);
				button= false;
			}
		/*	if(image){
				GUI.DrawTexture(new Rect (screenRes.x*left, screenRes.y*top, screenRes.x*width, screenRes.y*height),imageTexture);
			}*/
		}
		if (text) {
			GUI.TextField(new Rect (screenRes.x*left, screenRes.y*top, screenRes.x*width, screenRes.y*height),TextField,style);
		}
	}

	void Update(){
		if (backEnabled) {
			if(Input.GetKeyDown(KeyCode.Escape)){
				Buttons = GameObject.FindGameObjectsWithTag("Button");
				foreach(GameObject buttonObject in Buttons){
					if(buttonObject!=null){
						Destroy(buttonObject);
					}
				}
				pages = GameObject.FindGameObjectWithTag ("Pages").GetComponent<Pages> ();
				pages.openPage (buttonGoesToPage);
				pages.closePage(currentPage);
			//	button=false;
			}
		}
	}
}
