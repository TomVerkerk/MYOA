using UnityEngine;
using System.Collections;
using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
/*using UnityEngine.WindowsPhone;
using UnityEngine.Windows;
using AOT;
using System;
using UnityEditor;
using UnityEditorInternal;
using Microsoft;*/

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
	public bool buttonVisible;
	public bool image;
	public bool site;
	public bool call;
	public bool mail;
	//private MailMessage mail = new MailMessage ();
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
	private float startY;
	//private OpenWebpage page;
	//private Uri web;

	void Start(){
		screenRes.x = Screen.width;
		screenRes.y = Screen.height;
		if(scrollable){
			startY = transform.position.y;
		}
		pages = GameObject.FindGameObjectWithTag ("Pages").GetComponent<Pages> ();
		if (image) {
			gameObject.renderer.material = imageMaterial;
		}
	//	page = this.gameObject.GetComponent<OpenWebpage> ();
	}

	void OnGUI(){
		if (!buttonVisible) {
						GUI.color = Color.clear;
				}
		if (button) {
			if(GUI.Button (new Rect (screenRes.x*buttonLeft, screenRes.y*buttonTop, screenRes.x*buttonWidth, screenRes.y*buttonHeight),"") ){
				Buttons = GameObject.FindGameObjectsWithTag("Button");
				if(site){
					//#if UNITY_ANDROID
					Application.OpenURL(siteURL);
				//	#endif
				//	web = new Uri("www.google.nl");
				/*	WebScriptObject site = new WebScriptObject();
					UriBuilder(site);*/
				/*	WebBrowserTask namewhatevz = new WebBrowserTask();
					namewhatevz.Uri = new uri("http://google.se", UriKind.Absolute);
					namewhatevz.Show();*/
				}
				else if(call){
					//#if UNITY_ANDROID
					Application.OpenURL("tel://"+siteURL);
					//#endif
				}
				else if(mail){
					Application.OpenURL("mailto:" + siteURL/* + "?subject:" + subject + "&body:" + body*/);
				}
				else if(exit){
					Application.Quit();
				}
				else{
					pages.openPage (buttonGoesToPage);
				}
				if(crisischeck && !site){
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
					Destroy(chrisisC.button);
		//			GameObject.FindGameObjectWithTag ("BeoordeelButton");
					GameObject PHolder;
					PHolder = GameObject.FindGameObjectWithTag("CrisisCheck");
					Destroy(PHolder);
			/*		if(chrisisC.beoordeeling){
						Destroy(GameObject.FindGameObjectWithTag ("BeoordeelButton"));
					}*/
				}
				if(!site && !call && !mail){
					foreach(GameObject buttonObject in Buttons){
						if(buttonObject!=null){
							Destroy(buttonObject);
						}
					}
					button= false;
				}
			//	Destroy(this.gameObject);
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
				touchEnd/=1.3f;
			}
			if(transform.position.y < (length+position.y)&&transform.position.y > position.y||transform.position.y >= (length+position.y)&& touchEnd.y > 0 || transform.position.y <= position.y&& touchEnd.y < 0){
				transform.position += new Vector3(0,-touchEnd.y*scrollSpeed,0);
			}
			if(transform.position.y < startY /*&& Input.touchCount==0*/){
				transform.position = new Vector3(transform.position.x,startY,transform.position.z);
			}
		//	else if(transform.position.y > (length+position.y)&& touchEnd.y > 0 || transform.position.y < position.y && touchEnd.y < 0)
		}
		if (backEnabled) {
			if(Input.GetKeyDown(KeyCode.Escape)){
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
					Destroy(chrisisC.button);
					GameObject PHolder;
					PHolder = GameObject.FindGameObjectWithTag("CrisisCheck");
					Destroy(PHolder);
				}
				Buttons = GameObject.FindGameObjectsWithTag("Button");
				foreach(GameObject buttonObject in Buttons){
					if(buttonObject.gameObject!=null){
						Destroy(buttonObject);
					}
				}
				pages.openPage (backGoesToPage);
			}
		}
	}
}
