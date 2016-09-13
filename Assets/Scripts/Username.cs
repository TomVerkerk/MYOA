
using UnityEngine;
using System.Collections;

public class Username : MonoBehaviour {

	public TouchScreenKeyboard keyBoard;
	public string user;
	public string pass;
	private TextFields username;
	private TextFields password;
	private GameObject Texts;
	private string text;
	private GameObject[] buttons;
	private Pages pages;
	public GUIStyle gui;
	private string invalid = "";
	private GUIStyle invalidText;
	public Texture textfieldImage;
	public Texture2D placeHolder1;
	public Texture2D placeHolder2;

	// Use this for initialization
	void Start () {
		invalidText = new GUIStyle ();
		invalidText.active.textColor = Color.red;
		invalidText.fontSize = 20;
		pages = GameObject.FindGameObjectWithTag ("Pages").GetComponent<Pages> ();

		keyBoard = new TouchScreenKeyboard ("", TouchScreenKeyboardType.Default, false, false, true, false, "3");
		keyBoard.active = false;

		Texts = new GameObject ();

		username = Texts.gameObject.AddComponent<TextFields>();
		username.name = "";
		username.placeHolder = "Username";;
		username.x = 0.16f;
		username.y = 0.16f;
		username.width = 0.68f;
		username.height = 0.06f;
		username.gui = gui;

		password = Texts.gameObject.AddComponent<TextFields>();
		password.name = "";
		password.placeHolder = "Password";
		password.x = 0.16f;
		password.y = 0.35f;
		password.width = 0.68f;
		password.height = 0.06f;
		password.gui = gui;
	}

	void OnGUI(){
		GUI.TextField(new Rect(Screen.width*0.16f,Screen.height*0.77f,Screen.width*0.68f,Screen.height*0.15f),invalid,invalidText);
		GUI.color = Color.clear;
		if(GUI.Button(new Rect(Screen.width*0.155f,Screen.height*(0.52f),Screen.width*0.68f,Screen.height*0.125f),"")){
			if(username.name == user && password.name == pass){
				Destroy(Texts);
				buttons = GameObject.FindGameObjectsWithTag("Button");
				keyBoard.active = false;
				foreach(GameObject buttonObject in buttons){
					if(buttonObject!=null){
						Destroy(buttonObject);
					}
				}
				pages.openPage(1);
			}
			else{
				invalid = "Verkeerde combinatie!";
			}
		}
	}
}
