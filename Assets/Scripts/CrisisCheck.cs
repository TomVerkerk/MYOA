using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CrisisCheck : MonoBehaviour {

	public bool CCheck;
	public bool beoordeeling;
	public GameObject[] Check;
	public GameObject check1;
	public GameObject check2;
	public GameObject check3;
	public GameObject check4;
	public GameObject check5;
	public GameObject aanmelden;
	public GameObject button;
	private GameObject checkmark;
	public float smallButtonWidth;
	public float smallButtonHeight;
	private float a = 0;
	private float b = 0;
	private float c = 0;
	private float d = 0;
	private float e = 0;
	private float rating = 5;
	private Vector3 aPos;
	private Vector3 bPos;
	private Vector3 cPos;
	private Vector3 dPos;
	private Vector3 ePos;
	private float score;
	private Pages pages;
	private bool rated = false;

	void Start(){
		foreach (GameObject element in Check) {
			checkmark = Instantiate(element,element.transform.position,element.transform.rotation) as GameObject;
		}
		check1 = GameObject.FindGameObjectWithTag ("check1");
		check1.gameObject.SetActive (false);
		check2 = GameObject.FindGameObjectWithTag ("check2");
		check2.gameObject.SetActive (false);
		check3 = GameObject.FindGameObjectWithTag ("check3");
		check3.gameObject.SetActive (false);
		check4 = GameObject.FindGameObjectWithTag ("check4");
		check4.gameObject.SetActive (false);
		check5 = GameObject.FindGameObjectWithTag ("check5");
		check5.gameObject.SetActive (false);
		aanmelden = GameObject.FindGameObjectWithTag ("aanmelden");

		if(CCheck){

			aPos = new Vector3 (0, 10f - (19 * 0.29f), -1);
			bPos = new Vector3 (0, 10.126f - (19 * 0.466f), -1);
			cPos = new Vector3 (0, 9.99f - (19 * 0.64f), -1);
			dPos = new Vector3 (0, 10.047f - (19 * 0.773f), -1);
			ePos = new Vector3 (0, 10.074f - (19 * 0.896f), -1);
		}
		if(beoordeeling){
			button = GameObject.FindGameObjectWithTag ("BeoordeelButton");
			button.gameObject.renderer.enabled = false;
			float x = -4.5f;
			float y = -0;
			float z = -1;
			float width = 2.1f;
			check1.transform.position = new Vector3(/*Screen.width**/x,y,z);
			check2.transform.position = new Vector3(/*Screen.width*(*/x+(width*1),y,z);
			check3.transform.position = new Vector3(/*Screen.width*(*/x+(width*2),y,z);
			check4.transform.position = new Vector3(/*Screen.width*(*/x+(width*3),y,z);
			check5.transform.position = new Vector3(/*Screen.width*(*/x+(width*4),y,z);
		}
	}

	// Use this for initialization
	void OnGUI(){
		GUI.color = Color.clear;
		//a
		if(CCheck){
			if(GUI.Button(new Rect(Screen.width*0.09f,Screen.height*0.25f,Screen.width*smallButtonWidth,Screen.height*smallButtonHeight),"")){
				a = 0;
				aPos.x=-6+(12*(0.1f+smallButtonWidth/2));
				check1.gameObject.transform.position = aPos;
				check1.gameObject.SetActive(true);
			}
			if(GUI.Button(new Rect(Screen.width*(0.09f+smallButtonWidth),Screen.height*0.25f,Screen.width*smallButtonWidth,Screen.height*smallButtonHeight),"")){
				a = 1;
				aPos.x=-6+(12*(0.1f+smallButtonWidth*1.5f));
				check1.gameObject.transform.position = aPos;
				check1.gameObject.SetActive(true);
			}
			if(GUI.Button(new Rect(Screen.width*(0.09f+smallButtonWidth*2f),Screen.height*0.25f,Screen.width*smallButtonWidth,Screen.height*smallButtonHeight),"")){
				a = 2;
				aPos.x=-6+(12*(0.1f+smallButtonWidth*2.5f));
				check1.gameObject.transform.position = aPos;
				check1.gameObject.SetActive(true);
			}

			//b
			if(GUI.Button(new Rect(Screen.width*0.09f,Screen.height*0.41f,Screen.width*smallButtonWidth,Screen.height*smallButtonHeight),"")){
				b = 0;
				bPos.x=-6+(12*(0.1f+smallButtonWidth/2));
				check2.gameObject.transform.position = bPos;
				check2.gameObject.SetActive(true);
			}
			if(GUI.Button(new Rect(Screen.width*(0.09f+smallButtonWidth),Screen.height*0.41f,Screen.width*smallButtonWidth,Screen.height*smallButtonHeight),"")){
				b = 1;
				bPos.x=-6+(12*(0.1f+smallButtonWidth*1.5f));
				check2.gameObject.transform.position = bPos;
				check2.gameObject.SetActive(true);
			}
			if(GUI.Button(new Rect(Screen.width*(0.09f+smallButtonWidth*2f),Screen.height*0.41f,Screen.width*smallButtonWidth,Screen.height*smallButtonHeight),"")){
				b = 2;
				bPos.x=-6+(12*(0.1f+smallButtonWidth*2.5f));
				check2.gameObject.transform.position = bPos;
				check2.gameObject.SetActive(true);
			}

			//c
			if(GUI.Button(new Rect(Screen.width*0.09f,Screen.height*0.575f,Screen.width*smallButtonWidth,Screen.height*smallButtonHeight),"")){
				c = 0;
				cPos.x=-6+(12*(0.1f+smallButtonWidth/2));
				check3.gameObject.transform.position = cPos;
				check3.gameObject.SetActive(true);
			}
			if(GUI.Button(new Rect(Screen.width*(0.09f+smallButtonWidth),Screen.height*0.575f,Screen.width*smallButtonWidth,Screen.height*smallButtonHeight),"")){
				c = 1;
				cPos.x=-6+(12*(0.1f+smallButtonWidth*1.5f));
				check3.gameObject.transform.position = cPos;
				check3.gameObject.SetActive(true);
			}
			if(GUI.Button(new Rect(Screen.width*(0.09f+smallButtonWidth*2f),Screen.height*0.575f,Screen.width*smallButtonWidth,Screen.height*smallButtonHeight),"")){
				c = 2;
				cPos.x=-6+(12*(0.1f+smallButtonWidth*2.5f));
				check3.gameObject.transform.position = cPos;
				check3.gameObject.SetActive(true);
			}

			//d
			if(GUI.Button(new Rect(Screen.width*0.09f,Screen.height*0.705f,Screen.width*smallButtonWidth,Screen.height*smallButtonHeight),"")){
				d = 0;
				dPos.x=-6+(12*(0.1f+smallButtonWidth/2));
				check4.gameObject.transform.position = dPos;
				check4.gameObject.SetActive(true);
			}
			if(GUI.Button(new Rect(Screen.width*(0.09f+smallButtonWidth),Screen.height*0.705f,Screen.width*smallButtonWidth,Screen.height*smallButtonHeight),"")){
				d = 1;
				dPos.x=-6+(12*(0.1f+smallButtonWidth*1.5f));
				check4.gameObject.transform.position = dPos;
				check4.gameObject.SetActive(true);
			}
			if(GUI.Button(new Rect(Screen.width*(0.09f+smallButtonWidth*2f),Screen.height*0.705f,Screen.width*smallButtonWidth,Screen.height*smallButtonHeight),"")){
				d = 2;
				dPos.x=-6+(12*(0.1f+smallButtonWidth*2.5f));
				check4.gameObject.transform.position = dPos;
				check4.gameObject.SetActive(true);
			}

			//e
			if(GUI.Button(new Rect(Screen.width*0.09f,Screen.height*0.825f,Screen.width*smallButtonWidth,Screen.height*smallButtonHeight),"")){
				e = 0;
				ePos.x=-6+(12*(0.1f+smallButtonWidth/2));
				check5.gameObject.transform.position = ePos;
				check5.gameObject.SetActive(true);
			}
			if(GUI.Button(new Rect(Screen.width*(0.09f+smallButtonWidth),Screen.height*0.825f,Screen.width*smallButtonWidth,Screen.height*smallButtonHeight),"")){
				e = 1;
				ePos.x=-6+(12*(0.1f+smallButtonWidth*1.5f));
				check5.gameObject.transform.position = ePos;
				check5.gameObject.SetActive(true);
			}
			if(GUI.Button(new Rect(Screen.width*(0.09f+smallButtonWidth*2f),Screen.height*0.825f,Screen.width*smallButtonWidth,Screen.height*smallButtonHeight),"")){
				e = 2;
				ePos.x=-6+(12*(0.1f+smallButtonWidth*2.5f));
				check5.gameObject.transform.position = ePos;
				check5.gameObject.SetActive(true);
			}

			if(GUI.Button(new Rect(Screen.width*0.59f,Screen.height*0.92f,Screen.width*0.32f,Screen.height*0.076f),"")){
				Next();
			}
		}
		if(beoordeeling){
			smallButtonWidth=0.174f;
			smallButtonHeight=0.1f;
			if(GUI.Button(new Rect(Screen.width*(0.05f),Screen.height*0.45f,Screen.width*smallButtonWidth,Screen.height*smallButtonHeight),"")){
				check1.SetActive(true);
				check2.SetActive(false);
				check3.SetActive(false);
				check4.SetActive(false);
				check5.SetActive(false);
				rating=1;
				if(!rated){
					button.gameObject.renderer.enabled = true;
				}
				rated=true;
			}
			if(GUI.Button(new Rect(Screen.width*(0.05f+smallButtonWidth*1),Screen.height*0.45f,Screen.width*smallButtonWidth,Screen.height*smallButtonHeight),"")){
				check1.SetActive(true);
				check2.SetActive(true);
				check3.SetActive(false);
				check4.SetActive(false);
				check5.SetActive(false);
				rating=2;
				if(!rated){
					button.gameObject.renderer.enabled = true;
				}
				rated=true;
			}
			if(GUI.Button(new Rect(Screen.width*(0.05f+smallButtonWidth*2),Screen.height*0.45f,Screen.width*smallButtonWidth,Screen.height*smallButtonHeight),"")){
				check1.SetActive(true);
				check2.SetActive(true);
				check3.SetActive(true);
				check4.SetActive(false);
				check5.SetActive(false);
				rating=3;
				if(!rated){
					button.gameObject.renderer.enabled = true;
				}
				rated=true;
			}
			if(GUI.Button(new Rect(Screen.width*(0.05f+smallButtonWidth*3),Screen.height*0.45f,Screen.width*smallButtonWidth,Screen.height*smallButtonHeight),"")){
				check1.SetActive(true);
				check2.SetActive(true);
				check3.SetActive(true);
				check4.SetActive(true);
				check5.SetActive(false);
				rating=4;
				if(!rated){
					button.gameObject.renderer.enabled = true;
				}
				rated=true;
			}
			if(GUI.Button(new Rect(Screen.width*(0.05f+smallButtonWidth*4),Screen.height*0.45f,Screen.width*smallButtonWidth,Screen.height*smallButtonHeight),"")){
				check1.SetActive(true);
				check2.SetActive(true);
				check3.SetActive(true);
				check4.SetActive(true);
				check5.SetActive(true);
				rating=5;
				if(!rated){
					button.gameObject.renderer.enabled = true;
				}
				rated=true;
			}

			if(rated && GUI.Button(new Rect(Screen.width*0.6f,Screen.height*0.8f,Screen.width*smallButtonWidth*2,Screen.height*smallButtonHeight),"")){
				Next();
			}

		}
	}

	void Next(){
		check1.gameObject.SetActive (true);
		check2.gameObject.SetActive (true);
		check3.gameObject.SetActive (true);
		check4.gameObject.SetActive (true);
		check5.gameObject.SetActive (true);
		Destroy (check1);
		Destroy (check2);
		Destroy (check3);
		Destroy (check4);
		Destroy (check5); 
		Destroy (aanmelden);
		Destroy (this.gameObject);
		pages = GameObject.FindGameObjectWithTag ("Pages").GetComponent<Pages> ();
		if(CCheck){
			score = a + b + c + d;          
			if (e == 2 || e == 1 && score >= 4 || score >= 6) {
				pages.openPage (8);
			}
			else {
				pages.openPage(9);
			}
		}
		if(beoordeeling){
			Destroy(button);
			Destroy(GameObject.FindGameObjectWithTag("Button"));
			pages.openPage(2);
		}
	}
}
