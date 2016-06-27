using UnityEngine;
using System.Collections;

public class ImagePlayer : MonoBehaviour {

	public Texture[] images;
	private Texture showingImage;
	private float screenOffset;
	private Vector2 screenRes;
	private bool pc = false;
	private Vector2 imageScale;
	private float imageRes;
	private Texture imageZoomBackground;
	private GameObject ui;
	public bool opened = false;
	private Scroller scroller;
	private Vector2 touch1Begin;
	private Vector2 touch1End;
	private Vector2 touch2Begin;
	private Vector2 touch2End;
	private Vector2 zoom;
	public GUIStyle style;

	void Start(){
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
		Images images = ui.GetComponent<Images>();
		foreach(Texture tex in images.images){
			if(tex.name == "ImageZoomBackground"){
				imageZoomBackground = tex;
			}
		}
		GameObject scroll = GameObject.FindGameObjectWithTag ("Scroller");
		if (scroll != null) {
			scroller = scroll.GetComponent<Scroller> ();
		}
	}

	public void openImage(Texture[] imgs, int openNumber){
		images = imgs;
		imageScale = new Vector2(images [openNumber].width , images [openNumber].height);
		imageRes = imageScale.x / imageScale.y;
		showingImage = images [openNumber];
		opened = true;
	}

	public void closeImage(){
		scroller = GameObject.FindGameObjectWithTag ("Scroller").GetComponent<Scroller>();
		if (scroller.length>0) {
			scroller.on = true;
		}
		opened = false;
	}

	void Update(){
		if(Input.GetKeyDown(KeyCode.Escape)/*||
		   Input.touchCount>0||
		   Input.GetMouseButtonDown(0)*/){
			closeImage();
		}
		/*if(Input.touchCount>0){
			float count = 0;
			foreach (Touch t in Input.touches) {
				if (t.phase == TouchPhase.Began) {
					if(count==0){
						touch1Begin = t.position;
					}
					else{
						touch2Begin = t.position;
					}
				} else if (t.phase == TouchPhase.Moved) {
					if(count==0){
						touch1End = t.position;
					}
					else{
						touch2End = t.position;
					}
				}
				count++;
			}
			zoom = (touch1Begin-touch1End)-(touch2Begin-touch2End);
		}
		zoom.x += Input.GetAxis ("Mouse ScrollWheel");*/
	}

	void OnGUI(){
		if (opened) {
			//Input.multiTouchEnabled = true;
			GUI.DrawTexture (new Rect (Screen.width * screenOffset, 0, screenRes.x, screenRes.y), imageZoomBackground);
			GUI.DrawTexture (new Rect (Screen.width * screenOffset, (screenRes.y - (screenRes.x / imageRes)) / 2, screenRes.x, screenRes.x/ imageRes), showingImage);
		} else {
			//Input.multiTouchEnabled = false;
		}
	}
}
