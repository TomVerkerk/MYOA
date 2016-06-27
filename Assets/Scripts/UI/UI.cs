using UnityEngine;
using System.Collections;

public class UI : MonoBehaviour {

	public Texture uiBackgroundImage;
	public Vector2 startPages;
	public UIPage[] uiPages;

	void Start(){
		uiPages [Mathf.RoundToInt(startPages.x)].Open (true);
	//	uiPages [Mathf.RoundToInt(startPages.y)].Open (false);
	}

	void OnGUI(){
	//	GUI.DrawTexture (new Rect (0, 0, (Screen.width-(Screen.height*0.5625f)) / 2, Screen.height), uiBackgroundImage);
	//	GUI.DrawTexture (new Rect (((Screen.width-(Screen.height*0.5625f)) / 2)+(Screen.height*0.5625f), 0, (Screen.width-(Screen.height*0.5625f)) / 2, Screen.height), uiBackgroundImage);
	}
}
