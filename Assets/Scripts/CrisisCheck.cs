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
	private bool a = false;
	private bool b = false;
	private bool c = false;
	private bool d = false;
	private bool e = false;
	private int score;
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
	}

	// Use this for initialization
	void OnGUI(){
		GUI.color = Color.clear;
		if(GUI.Button(new Rect(Screen.width*0.013f,Screen.height*0.22f,Screen.width*smallButtonWidth,Screen.height*smallButtonHeight),"")){
			a=!a;
			if(!a){
				check1.gameObject.SetActive(false);
			}
			else{
				check1.gameObject.SetActive(true);
			}
		}
		if(GUI.Button(new Rect(Screen.width*0.013f,Screen.height*0.343f,Screen.width*smallButtonWidth,Screen.height*smallButtonHeight),"")){
			b=!b;
			if(!b){
				check2.gameObject.SetActive(false);
			}
			else{
				check2.gameObject.SetActive(true);
			}
		}
		if(GUI.Button(new Rect(Screen.width*0.013f,Screen.height*0.47f,Screen.width*smallButtonWidth,Screen.height*smallButtonHeight),"")){
			c=!c;
			if(!c){
				check3.gameObject.SetActive(false);
			}
			else{
				check3.gameObject.SetActive(true);
			}
		}
		if(GUI.Button(new Rect(Screen.width*0.013f,Screen.height*0.57f,Screen.width*smallButtonWidth,Screen.height*smallButtonHeight),"")){
			d=!d;
			if(!d){
				check4.gameObject.SetActive(false);
			}
			else{
				check4.gameObject.SetActive(true);
			}
		}
		if(GUI.Button(new Rect(Screen.width*0.013f,Screen.height*0.65f,Screen.width*smallButtonWidth,Screen.height*smallButtonHeight),"")){
			e=!e;
			if(!e){
				check5.gameObject.SetActive(false);
			}
			else{
				check5.gameObject.SetActive(true);
			}
		}
		if(GUI.Button(new Rect(Screen.width*0.53f,Screen.height*0.79f,Screen.width*0.4f,Screen.height*0.1f),"")){
			Next();
		}
	}

	void Next(){
		score = 0;
		if (a) {
			score++;
		}
		if (b) {
			score++;
		}
		if (c) {
			score++;
		}
		if (d) {
			score++;
		}
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
		if (e || score >= 2) {
			pages.openPage (8);
		}
		else {
			pages.openPage(9);
		}
	}
}
