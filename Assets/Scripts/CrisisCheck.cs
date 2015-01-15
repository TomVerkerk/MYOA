using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CrisisCheck : MonoBehaviour {

	public GameObject[] Check;
	public GameObject check1;
	public GameObject check2;
	public GameObject check3;
	public GameObject check4;
	public GameObject check5;
	private GameObject checkmark;
	public float smallButtonWidth;
	public float smallButtonHeight;
	private float a;
	private float b;
	private float c;
	private float d;
	private float e;
	private Vector3 aPos;
	private Vector3 bPos;
	private Vector3 cPos;
	private Vector3 dPos;
	private Vector3 ePos;
	private float score;
	private Pages pages;

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

		aPos = new Vector3 (0, 9.5f - (19 * 0.29f), -1);
		bPos = new Vector3 (0, 9.5f - (19 * 0.466f), -1);
		cPos = new Vector3 (0, 9.5f - (19 * 0.64f), -1);
		dPos = new Vector3 (0, 9.5f - (19 * 0.773f), -1);
		ePos = new Vector3 (0, 9.5f - (19 * 0.896f), -1);
	}

	// Use this for initialization
	void OnGUI(){
		GUI.color = Color.clear;
		//a
		if(GUI.Button(new Rect(Screen.width*0.1f,Screen.height*0.28f,Screen.width*smallButtonWidth,Screen.height*smallButtonHeight),"")){
			a = 0;
			aPos.x=-6+(12*(0.1f+smallButtonWidth/2));
			check1.gameObject.transform.position = aPos;
			check1.gameObject.SetActive(true);
		}
		if(GUI.Button(new Rect(Screen.width*(0.1f+smallButtonWidth),Screen.height*0.28f,Screen.width*smallButtonWidth,Screen.height*smallButtonHeight),"")){
			a = 1;
			aPos.x=-6+(12*(0.1f+smallButtonWidth*1.5f));
			check1.gameObject.transform.position = aPos;
			check1.gameObject.SetActive(true);
		}
		if(GUI.Button(new Rect(Screen.width*(0.1f+smallButtonWidth*2f),Screen.height*0.28f,Screen.width*smallButtonWidth,Screen.height*smallButtonHeight),"")){
			a = 2;
			aPos.x=-6+(12*(0.1f+smallButtonWidth*2.5f));
			check1.gameObject.transform.position = aPos;
			check1.gameObject.SetActive(true);
		}

		//b
		if(GUI.Button(new Rect(Screen.width*0.1f,Screen.height*0.45f,Screen.width*smallButtonWidth,Screen.height*smallButtonHeight),"")){
			b = 0;
			bPos.x=-6+(12*(0.1f+smallButtonWidth/2));
			check2.gameObject.transform.position = bPos;
			check2.gameObject.SetActive(true);
		}
		if(GUI.Button(new Rect(Screen.width*(0.1f+smallButtonWidth),Screen.height*0.45f,Screen.width*smallButtonWidth,Screen.height*smallButtonHeight),"")){
			b = 1;
			bPos.x=-6+(12*(0.1f+smallButtonWidth*1.5f));
			check2.gameObject.transform.position = bPos;
			check2.gameObject.SetActive(true);
		}
		if(GUI.Button(new Rect(Screen.width*(0.1f+smallButtonWidth*2f),Screen.height*0.45f,Screen.width*smallButtonWidth,Screen.height*smallButtonHeight),"")){
			b = 2;
			bPos.x=-6+(12*(0.1f+smallButtonWidth*2.5f));
			check2.gameObject.transform.position = bPos;
			check2.gameObject.SetActive(true);
		}

		//c
		if(GUI.Button(new Rect(Screen.width*0.1f,Screen.height*0.62f,Screen.width*smallButtonWidth,Screen.height*smallButtonHeight),"")){
			c = 0;
			cPos.x=-6+(12*(0.1f+smallButtonWidth/2));
			check3.gameObject.transform.position = cPos;
			check3.gameObject.SetActive(true);
		}
		if(GUI.Button(new Rect(Screen.width*(0.1f+smallButtonWidth),Screen.height*0.62f,Screen.width*smallButtonWidth,Screen.height*smallButtonHeight),"")){
			c = 1;
			cPos.x=-6+(12*(0.1f+smallButtonWidth*1.5f));
			check3.gameObject.transform.position = cPos;
			check3.gameObject.SetActive(true);
		}
		if(GUI.Button(new Rect(Screen.width*(0.1f+smallButtonWidth*2f),Screen.height*0.62f,Screen.width*smallButtonWidth,Screen.height*smallButtonHeight),"")){
			c = 2;
			cPos.x=-6+(12*(0.1f+smallButtonWidth*2.5f));
			check3.gameObject.transform.position = cPos;
			check3.gameObject.SetActive(true);
		}

		//d
		if(GUI.Button(new Rect(Screen.width*0.1f,Screen.height*0.74f,Screen.width*smallButtonWidth,Screen.height*smallButtonHeight),"")){
			d = 0;
			dPos.x=-6+(12*(0.1f+smallButtonWidth/2));
			check4.gameObject.transform.position = dPos;
			check4.gameObject.SetActive(true);
		}
		if(GUI.Button(new Rect(Screen.width*(0.1f+smallButtonWidth),Screen.height*0.74f,Screen.width*smallButtonWidth,Screen.height*smallButtonHeight),"")){
			d = 1;
			dPos.x=-6+(12*(0.1f+smallButtonWidth*1.5f));
			check4.gameObject.transform.position = dPos;
			check4.gameObject.SetActive(true);
		}
		if(GUI.Button(new Rect(Screen.width*(0.1f+smallButtonWidth*2f),Screen.height*0.74f,Screen.width*smallButtonWidth,Screen.height*smallButtonHeight),"")){
			d = 2;
			dPos.x=-6+(12*(0.1f+smallButtonWidth*2.5f));
			check4.gameObject.transform.position = dPos;
			check4.gameObject.SetActive(true);
		}

		//e
		if(GUI.Button(new Rect(Screen.width*0.1f,Screen.height*0.861f,Screen.width*smallButtonWidth,Screen.height*smallButtonHeight),"")){
			e = 0;
			ePos.x=-6+(12*(0.1f+smallButtonWidth/2));
			check5.gameObject.transform.position = ePos;
			check5.gameObject.SetActive(true);
		}
		if(GUI.Button(new Rect(Screen.width*(0.1f+smallButtonWidth),Screen.height*0.861f,Screen.width*smallButtonWidth,Screen.height*smallButtonHeight),"")){
			e = 1;
			ePos.x=-6+(12*(0.1f+smallButtonWidth*1.5f));
			check5.gameObject.transform.position = ePos;
			check5.gameObject.SetActive(true);
		}
		if(GUI.Button(new Rect(Screen.width*(0.1f+smallButtonWidth*2f),Screen.height*0.861f,Screen.width*smallButtonWidth,Screen.height*smallButtonHeight),"")){
			e = 2;
			ePos.x=-6+(12*(0.1f+smallButtonWidth*2.5f));
			check5.gameObject.transform.position = ePos;
			check5.gameObject.SetActive(true);
		}

		if(GUI.Button(new Rect(Screen.width*0.59f,Screen.height*0.92f,Screen.width*0.32f,Screen.height*0.076f),"")){
			Next();
		}
	}

	void Next(){
		score = a + b + c + d;
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
		Destroy(GameObject.FindGameObjectWithTag ("Button").gameObject);
		Destroy (this.gameObject);
		pages = GameObject.FindGameObjectWithTag ("Pages").GetComponent<Pages> ();
		if (e == 2 && score >= 4 || score >= 6) {
			pages.openPage (8);
		}
		else {
			pages.openPage(9);
		}
	}
}
