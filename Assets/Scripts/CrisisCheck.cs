using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CrisisCheck : MonoBehaviour {

	public bool CCheck;
	public bool beoordeeling;
	public bool buttonsVisable;
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
	private bool aRated = false;
	private bool bRated = false;
	private bool cRated = false;
	private bool dRated = false;
	private bool eRated = false;
	private Vector2 butPos;
	private Vector2 butScale;


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
		button = GameObject.FindGameObjectWithTag ("BeoordeelButton");
		button.gameObject.renderer.enabled = false;

		if(CCheck){
<<<<<<< HEAD
			button.transform.position=new Vector3(3,-9,-1);
			butScale = new Vector2(1.4f,0.65f);
			butPos = new Vector2(0.58f,0.918f);
			aPos = new Vector3 (0, 10f - (19 * 0.3f), -1);
			bPos = new Vector3 (0, 10.126f - (19 * 0.475f), -1);
			cPos = new Vector3 (0, 10.2f - (19 * 0.65f), -1);
			dPos = new Vector3 (0, 10.25f - (19 * 0.78f), -1);
			ePos = new Vector3 (0, 10.25f - (19 * 0.905f), -1);
		}
		if(beoordeeling){
			button.transform.position=new Vector3(3.28f,-7,-1);
			butPos = new Vector2(0.61f,0.818f);
			butScale = new Vector2(2.1f,0.65f);
			//float x = -4.4f;
			//float y = -0;
			//float z = -1;
			float width = 1.99f;
			check1.transform.position = new Vector3(-4.08f,0,-1);
			check2.transform.position = new Vector3(-4.115f+(width*1),0,-1);
			check3.transform.position = new Vector3(-4.1f+(width*2),0,-1);
			check4.transform.position = new Vector3(-4.08f+(width*3),0,-1);
			check5.transform.position = new Vector3(-4.08f+(width*4),0,-1);
=======

			aPos = new Vector3 (0, 10f - (19 * 0.3f), -1);
			bPos = new Vector3 (0, 10.126f - (19 * 0.475f), -1);
			cPos = new Vector3 (0, 9.99f - (19 * 0.65f), -1);
			dPos = new Vector3 (0, 10.047f - (19 * 0.78f), -1);
			ePos = new Vector3 (0, 10.074f - (19 * 0.905f), -1);
		}
		if(beoordeeling){
			button = GameObject.FindGameObjectWithTag ("BeoordeelButton");
			button.gameObject.GetComponent<Renderer>().enabled = false;
			float x = -4.4f;
			float y = -0;
			float z = -1;
			float width = 2.13f;
			check1.transform.position = new Vector3(/*Screen.width**/x+0.04f,y,z);
			check2.transform.position = new Vector3(/*Screen.width*(*/x-0.04f+(width*1),y,z);
			check3.transform.position = new Vector3(/*Screen.width*(*/x+0.01f+(width*2),y,z);
			check4.transform.position = new Vector3(/*Screen.width*(*/x+(width*3),y,z);
			check5.transform.position = new Vector3(/*Screen.width*(*/x+(width*4),y,z);
>>>>>>> 52ee4db6d127a5c551eee4a1195f14c62466963a
		}
	}

	// Use this for initialization
	void OnGUI(){
		if(!buttonsVisable){
			GUI.color = Color.clear;
		}
		//a
		if(CCheck){
<<<<<<< HEAD
			if(GUI.Button(new Rect(Screen.width*0.09f,Screen.height*0.235f,Screen.width*smallButtonWidth,Screen.height*smallButtonHeight),"")){
=======
			if(GUI.Button(new Rect(Screen.width*0.09f,Screen.height*0.26f,Screen.width*smallButtonWidth,Screen.height*smallButtonHeight),"")){
>>>>>>> 52ee4db6d127a5c551eee4a1195f14c62466963a
				a = 0;
				aPos.x=-6+(12*(0.1f+smallButtonWidth/2));
				check1.gameObject.transform.position = aPos;
				check1.gameObject.SetActive(true);
				aRated=true;
			}
<<<<<<< HEAD
			if(GUI.Button(new Rect(Screen.width*(0.09f+smallButtonWidth),Screen.height*0.235f,Screen.width*smallButtonWidth,Screen.height*smallButtonHeight),"")){
=======
			if(GUI.Button(new Rect(Screen.width*(0.09f+smallButtonWidth),Screen.height*0.26f,Screen.width*smallButtonWidth,Screen.height*smallButtonHeight),"")){
>>>>>>> 52ee4db6d127a5c551eee4a1195f14c62466963a
				a = 1;
				aPos.x=-6+(12*(0.1f+smallButtonWidth*1.5f));
				check1.gameObject.transform.position = aPos;
				check1.gameObject.SetActive(true);
				aRated=true;
			}
<<<<<<< HEAD
			if(GUI.Button(new Rect(Screen.width*(0.09f+smallButtonWidth*2f),Screen.height*0.235f,Screen.width*smallButtonWidth,Screen.height*smallButtonHeight),"")){
=======
			if(GUI.Button(new Rect(Screen.width*(0.09f+smallButtonWidth*2f),Screen.height*0.26f,Screen.width*smallButtonWidth,Screen.height*smallButtonHeight),"")){
>>>>>>> 52ee4db6d127a5c551eee4a1195f14c62466963a
				a = 2;
				aPos.x=-6+(12*(0.1f+smallButtonWidth*2.5f));
				check1.gameObject.transform.position = aPos;
				check1.gameObject.SetActive(true);
				aRated=true;
			}

			//b
<<<<<<< HEAD
			if(GUI.Button(new Rect(Screen.width*0.09f,Screen.height*0.4f,Screen.width*smallButtonWidth,Screen.height*smallButtonHeight),"")){
=======
			if(GUI.Button(new Rect(Screen.width*0.09f,Screen.height*0.428f,Screen.width*smallButtonWidth,Screen.height*smallButtonHeight),"")){
>>>>>>> 52ee4db6d127a5c551eee4a1195f14c62466963a
				b = 0;
				bPos.x=-6+(12*(0.1f+smallButtonWidth/2));
				check2.gameObject.transform.position = bPos;
				check2.gameObject.SetActive(true);
				bRated=true;
			}
<<<<<<< HEAD
			if(GUI.Button(new Rect(Screen.width*(0.09f+smallButtonWidth),Screen.height*0.4f,Screen.width*smallButtonWidth,Screen.height*smallButtonHeight),"")){
=======
			if(GUI.Button(new Rect(Screen.width*(0.09f+smallButtonWidth),Screen.height*0.428f,Screen.width*smallButtonWidth,Screen.height*smallButtonHeight),"")){
>>>>>>> 52ee4db6d127a5c551eee4a1195f14c62466963a
				b = 1;
				bPos.x=-6+(12*(0.1f+smallButtonWidth*1.5f));
				check2.gameObject.transform.position = bPos;
				check2.gameObject.SetActive(true);
				bRated=true;
			}
<<<<<<< HEAD
			if(GUI.Button(new Rect(Screen.width*(0.09f+smallButtonWidth*2f),Screen.height*0.4f,Screen.width*smallButtonWidth,Screen.height*smallButtonHeight),"")){
=======
			if(GUI.Button(new Rect(Screen.width*(0.09f+smallButtonWidth*2f),Screen.height*0.428f,Screen.width*smallButtonWidth,Screen.height*smallButtonHeight),"")){
>>>>>>> 52ee4db6d127a5c551eee4a1195f14c62466963a
				b = 2;
				bPos.x=-6+(12*(0.1f+smallButtonWidth*2.5f));
				check2.gameObject.transform.position = bPos;
				check2.gameObject.SetActive(true);
				bRated=true;
			}

			//c
<<<<<<< HEAD
			if(GUI.Button(new Rect(Screen.width*0.09f,Screen.height*0.56f,Screen.width*smallButtonWidth,Screen.height*smallButtonHeight),"")){
=======
			if(GUI.Button(new Rect(Screen.width*0.09f,Screen.height*0.59f,Screen.width*smallButtonWidth,Screen.height*smallButtonHeight),"")){
>>>>>>> 52ee4db6d127a5c551eee4a1195f14c62466963a
				c = 0;
				cPos.x=-6+(12*(0.1f+smallButtonWidth/2));
				check3.gameObject.transform.position = cPos;
				check3.gameObject.SetActive(true);
				cRated = true;
			}
<<<<<<< HEAD
			if(GUI.Button(new Rect(Screen.width*(0.09f+smallButtonWidth),Screen.height*0.56f,Screen.width*smallButtonWidth,Screen.height*smallButtonHeight),"")){
=======
			if(GUI.Button(new Rect(Screen.width*(0.09f+smallButtonWidth),Screen.height*0.595f,Screen.width*smallButtonWidth,Screen.height*smallButtonHeight),"")){
>>>>>>> 52ee4db6d127a5c551eee4a1195f14c62466963a
				c = 1;
				cPos.x=-6+(12*(0.1f+smallButtonWidth*1.5f));
				check3.gameObject.transform.position = cPos;
				check3.gameObject.SetActive(true);
				cRated = true;
			}
<<<<<<< HEAD
			if(GUI.Button(new Rect(Screen.width*(0.09f+smallButtonWidth*2f),Screen.height*0.56f,Screen.width*smallButtonWidth,Screen.height*smallButtonHeight),"")){
=======
			if(GUI.Button(new Rect(Screen.width*(0.09f+smallButtonWidth*2f),Screen.height*0.595f,Screen.width*smallButtonWidth,Screen.height*smallButtonHeight),"")){
>>>>>>> 52ee4db6d127a5c551eee4a1195f14c62466963a
				c = 2;
				cPos.x=-6+(12*(0.1f+smallButtonWidth*2.5f));
				check3.gameObject.transform.position = cPos;
				check3.gameObject.SetActive(true);
				cRated = true;
			}

			//d
<<<<<<< HEAD
			if(GUI.Button(new Rect(Screen.width*0.09f,Screen.height*0.69f,Screen.width*smallButtonWidth,Screen.height*smallButtonHeight),"")){
=======
			if(GUI.Button(new Rect(Screen.width*0.09f,Screen.height*0.72f,Screen.width*smallButtonWidth,Screen.height*smallButtonHeight),"")){
>>>>>>> 52ee4db6d127a5c551eee4a1195f14c62466963a
				d = 0;
				dPos.x=-6+(12*(0.1f+smallButtonWidth/2));
				check4.gameObject.transform.position = dPos;
				check4.gameObject.SetActive(true);
				dRated = true;
			}
<<<<<<< HEAD
			if(GUI.Button(new Rect(Screen.width*(0.09f+smallButtonWidth),Screen.height*0.69f,Screen.width*smallButtonWidth,Screen.height*smallButtonHeight),"")){
=======
			if(GUI.Button(new Rect(Screen.width*(0.09f+smallButtonWidth),Screen.height*0.72f,Screen.width*smallButtonWidth,Screen.height*smallButtonHeight),"")){
>>>>>>> 52ee4db6d127a5c551eee4a1195f14c62466963a
				d = 1;
				dPos.x=-6+(12*(0.1f+smallButtonWidth*1.5f));
				check4.gameObject.transform.position = dPos;
				check4.gameObject.SetActive(true);
				dRated = true;
			}
<<<<<<< HEAD
			if(GUI.Button(new Rect(Screen.width*(0.09f+smallButtonWidth*2f),Screen.height*0.69f,Screen.width*smallButtonWidth,Screen.height*smallButtonHeight),"")){
=======
			if(GUI.Button(new Rect(Screen.width*(0.09f+smallButtonWidth*2f),Screen.height*0.72f,Screen.width*smallButtonWidth,Screen.height*smallButtonHeight),"")){
>>>>>>> 52ee4db6d127a5c551eee4a1195f14c62466963a
				d = 2;
				dPos.x=-6+(12*(0.1f+smallButtonWidth*2.5f));
				check4.gameObject.transform.position = dPos;
				check4.gameObject.SetActive(true);
				dRated = true;
			}

			//e
<<<<<<< HEAD
			if(GUI.Button(new Rect(Screen.width*0.09f,Screen.height*0.805f,Screen.width*smallButtonWidth,Screen.height*smallButtonHeight),"")){
=======
			if(GUI.Button(new Rect(Screen.width*0.09f,Screen.height*0.84f,Screen.width*smallButtonWidth,Screen.height*smallButtonHeight),"")){
>>>>>>> 52ee4db6d127a5c551eee4a1195f14c62466963a
				e = 0;
				ePos.x=-6+(12*(0.1f+smallButtonWidth/2));
				check5.gameObject.transform.position = ePos;
				check5.gameObject.SetActive(true);
				eRated = true;
			}
<<<<<<< HEAD
			if(GUI.Button(new Rect(Screen.width*(0.09f+smallButtonWidth),Screen.height*0.805f,Screen.width*smallButtonWidth,Screen.height*smallButtonHeight),"")){
=======
			if(GUI.Button(new Rect(Screen.width*(0.09f+smallButtonWidth),Screen.height*0.84f,Screen.width*smallButtonWidth,Screen.height*smallButtonHeight),"")){
>>>>>>> 52ee4db6d127a5c551eee4a1195f14c62466963a
				e = 1;
				ePos.x=-6+(12*(0.1f+smallButtonWidth*1.5f));
				check5.gameObject.transform.position = ePos;
				check5.gameObject.SetActive(true);
				eRated = true;
			}
<<<<<<< HEAD
			if(GUI.Button(new Rect(Screen.width*(0.09f+smallButtonWidth*2f),Screen.height*0.805f,Screen.width*smallButtonWidth,Screen.height*smallButtonHeight),"")){
=======
			if(GUI.Button(new Rect(Screen.width*(0.09f+smallButtonWidth*2f),Screen.height*0.84f,Screen.width*smallButtonWidth,Screen.height*smallButtonHeight),"")){
>>>>>>> 52ee4db6d127a5c551eee4a1195f14c62466963a
				e = 2;
				ePos.x=-6+(12*(0.1f+smallButtonWidth*2.5f));
				check5.gameObject.transform.position = ePos;
				check5.gameObject.SetActive(true);
				eRated = true;
			}

			if(aRated&&bRated&&cRated&&dRated&&eRated){
				rated = true;
				button.gameObject.renderer.enabled = true;
			}
		/*	if(GUI.Button(new Rect(Screen.width*0.59f,Screen.height*0.92f,Screen.width*0.32f,Screen.height*0.076f),"")){
				Next();
			}*/
		}
		if(beoordeeling){
			smallButtonWidth=0.176f;
			smallButtonHeight=0.1f;
			if(GUI.Button(new Rect(Screen.width*(0.05f),Screen.height*0.45f,Screen.width*smallButtonWidth,Screen.height*smallButtonHeight),"")){
				check1.SetActive(true);
				check2.SetActive(false);
				check3.SetActive(false);
				check4.SetActive(false);
				check5.SetActive(false);
				rating=1;
				if(!rated){
					button.gameObject.GetComponent<Renderer>().enabled = true;
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
					button.gameObject.GetComponent<Renderer>().enabled = true;
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
					button.gameObject.GetComponent<Renderer>().enabled = true;
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
					button.gameObject.GetComponent<Renderer>().enabled = true;
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
					button.gameObject.GetComponent<Renderer>().enabled = true;
				}
				rated=true;
			}
		}
		if(rated && GUI.Button(new Rect(Screen.width*butPos.x,Screen.height*butPos.y,Screen.width*smallButtonWidth*butScale.x,Screen.height*smallButtonHeight*butScale.y),"")){
			Next();
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
		Debug.Log (button);
		Destroy(button);
		pages = GameObject.FindGameObjectWithTag ("Pages").GetComponent<Pages> ();
		if(CCheck){
			score = a + b + c + d;          
			if (e > 0 && score >= 2){
				pages.openPage (8);
			}
			else {
				pages.openPage(9);
			}
		}
		Destroy(GameObject.FindGameObjectWithTag("Button"));
		if(beoordeeling){
		//	Destroy(button);
			//Destroy(GameObject.FindGameObjectWithTag("Button"));
			//pages.openPage(13);
			Application.Quit();
		}
		GameObject PHolder;
		PHolder = GameObject.FindGameObjectWithTag("CrisisCheck");
		Destroy(PHolder);
	}
}
