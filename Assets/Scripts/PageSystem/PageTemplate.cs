using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PageTemplate : MonoBehaviour {

	public bool template;
	public bool templateOnly = false;
	public string pageName;
	public float scrollSpeed;
	private float length;
	private Scroller scroller;
	public int index;
	public List<GameObject> templateObjects;
	public List<GameObject> objects;
	private ItemVariables variables;
	private Vector3 scaleOffset = Vector3.zero;

	public void OpenPage(){
		//if (GameObject.FindGameObjectWithTag ("Scroller") == null) {
			scroller = (Resources.Load ("Scroller") as GameObject).GetComponent<Scroller> ();
			scroller.Reset ();
			Instantiate (scroller);
		//} else {
			scroller = GameObject.FindGameObjectWithTag("Scroller").GetComponent<Scroller>();
		//}
		if(!templateOnly){
			foreach (GameObject element in objects) {
				InstantiateObject(element,false);
			}
		}
		foreach(GameObject element in templateObjects){
			InstantiateObject(element,true);
		}
		//if (GameObject.FindGameObjectWithTag ("ImagePlayer") == null) {
			Instantiate(Resources.Load ("ImagePlayer") as GameObject);
		//}
		//if (GameObject.FindGameObjectWithTag ("Scroller") != null) {
			scroller.CheckUse();
		//}
	}

	void InstantiateObject(GameObject element, bool bTemplateObject){
		variables = element.GetComponent<ItemVariables> ();
		element.transform.localScale = new Vector3 (variables.scale.x, variables.scale.y, 1);
		scaleOffset = new Vector3 (5.625f - variables.scale.x / 2, -10 + variables.scale.y / 2);
		variables.templateItem = bTemplateObject;
		if (variables.menuBar) {
			element.GetComponent<MenuBar> ().buttonsObj.Clear ();
			foreach (GameObject button in element.GetComponent<MenuBar>().buttons) {
				button.GetComponent<ItemVariables> ().buttonTopStart = button.GetComponent<ItemVariables> ().buttonTop;
				GameObject buttonObj = Instantiate (button, transform.position, transform.rotation) as GameObject;
				element.GetComponent<MenuBar> ().buttonsObj.Add (buttonObj);
				scroller.attached.Add (buttonObj);
				buttonObj.GetComponent<ItemVariables> ().button = false;
			}
		}
		if (variables.slider) {
			element.GetComponent<Slider> ().parentVar = variables;
			element.GetComponent<Slider> ().SpawnStaticImage ();
			element.GetComponent<Slider> ().SpawnImage ();
			GameObject obj = element.GetComponent<Slider> ().spawnedObject;
			scroller.attached.Add (obj);
		}
		scroller.attached.Add (Instantiate (element, variables.position - scaleOffset, element.transform.rotation) as GameObject);
	}

	public void ClosePage(){
		GameObject[] buttons = GameObject.FindGameObjectsWithTag ("Button");
		foreach (GameObject button in buttons) {
			if(button!=null){
				Destroy(button.gameObject);
			}
		}
		if (GameObject.FindGameObjectWithTag("Scroller") != null) {
			scroller = GameObject.FindGameObjectWithTag("Scroller").GetComponent<Scroller>();
			scroller.enabled = false;
			scroller.Reset();
			Destroy(GameObject.FindGameObjectWithTag("Scroller"));
		}
		if (GameObject.FindGameObjectWithTag ("ImagePlayer") != null) {
			Destroy(GameObject.FindGameObjectWithTag("ImagePlayer"));
		}
	}
}
