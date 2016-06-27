using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PageTemplate : MonoBehaviour {

	public bool template;
	public bool templateOnly = false;
	public string pageName;
	public float scrollSpeed;
	private float length;
	public Scroller scroller;
	public int index;
	public List<GameObject> templateObjects;
	public List<GameObject> objects;
	private ItemVariables variables;
	private Vector3 scaleOffset = Vector3.zero;
	private float lengthCount;

	public void OpenPage(){
		lengthCount = 0;
		scroller = (Resources.Load ("Scroller") as GameObject).GetComponent<Scroller> ();

		scroller.attached.Clear ();
		scroller.menubuttons.Clear ();
		if(!templateOnly){
			foreach (GameObject element in objects) {
				variables = element.GetComponent<ItemVariables> ();
				if (variables.image) {
					if (variables.scale.y > 0) {
						if ((variables.position.y - variables.scale.y) < -20) {
							if (-(variables.position.y - variables.scale.y) > lengthCount) {
								lengthCount = -(variables.position.y - variables.scale.y);

							}
						}
					} else {
						if (variables.position.y < -20) {
							if (-variables.position.y > lengthCount) {
								lengthCount = -variables.position.y;
							}
						}
					}
				} else if (variables.button) {
					if (variables.buttonHeight > 0) {
						if (variables.buttonTopStart + variables.buttonHeight > 1) {
							if ((variables.buttonTopStart + variables.buttonHeight) * 20 > lengthCount) {
								lengthCount = (variables.buttonTopStart + variables.buttonHeight) * 20;
							}
						}
					} else {
						if (variables.buttonTopStart > 1) {
							if (variables.buttonTopStart * 20 > lengthCount) {
								lengthCount = variables.buttonTopStart * 20;
							}
						}
					}
				}
				variables.templateItem = false;
				element.transform.localScale = new Vector3 (variables.scale.x, variables.scale.y, 1);
				scaleOffset = new Vector3 (5.625f - variables.scale.x / 2, -10 + variables.scale.y / 2);
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
		}
		foreach(GameObject element in templateObjects){
			element.GetComponent<ItemVariables>().templateItem = false;
			variables = element.GetComponent<ItemVariables>();
			if(variables.image){
				if(variables.scale.y>0){
					if((variables.position.y-variables.scale.y)<-20){
						if(-(variables.position.y-variables.scale.y)>lengthCount){
							lengthCount = -(variables.position.y-variables.scale.y);
						}
					}
				}
				else{
					if(variables.position.y<-20){
						if(-variables.position.y>lengthCount){
							lengthCount = -variables.position.y;
						}
					}
				}
			}
			else if(variables.button){
				if(variables.buttonHeight>0){
					if(variables.buttonTopStart+variables.buttonHeight>1){
						if((variables.buttonTopStart+variables.buttonHeight)*20>lengthCount){
							lengthCount = (variables.buttonTopStart+variables.buttonHeight)*20;
						}
					}
				}
				else{
					if(variables.buttonTopStart>1){
						if(variables.buttonTopStart*20>lengthCount){
							lengthCount = variables.buttonTopStart*20;
						}
					}
				}
			}
			variables.templateItem = true;
			element.transform.localScale = new Vector3(variables.scale.x,variables.scale.y,1);
			scaleOffset = new Vector3(5.625f - variables.scale.x/2,-10 + variables.scale.y/2);
			if(variables.menuBar){
				element.GetComponent<MenuBar>().buttonsObj.Clear();
				foreach(GameObject button in element.GetComponent<MenuBar>().buttons){
					button.GetComponent<ItemVariables>().buttonTopStart = button.GetComponent<ItemVariables>().buttonTop;
					GameObject buttonObj = Instantiate(button,transform.position,transform.rotation) as GameObject;
					element.GetComponent<MenuBar>().buttonsObj.Add(buttonObj);
					scroller.attached.Add(buttonObj);
					buttonObj.GetComponent<ItemVariables>().button = false;
				}
			}
			if(variables.slider){
				element.GetComponent<Slider>().parentVar = variables;
				element.GetComponent<Slider>().SpawnStaticImage();
				element.GetComponent<Slider>().SpawnImage();
				GameObject obj = element.GetComponent<Slider>().spawnedObject;
				scroller.attached.Add(obj);
			}
			scroller.attached.Add(Instantiate(element,variables.position - scaleOffset,element.transform.rotation) as GameObject);
		}
		if (lengthCount > 20) {
			scroller.on = true;
		} else {
			scroller.on=false;
		}
		scroller.scrollTest = 0;
		scroller.scrollSpeed = 4;
		scroller.length = lengthCount - 20;
		Instantiate (scroller);
	}

	public void ClosePage(){
		GameObject[] buttons = GameObject.FindGameObjectsWithTag ("Button");
		foreach (GameObject button in buttons) {
			if(button!=null){
				Destroy(button.gameObject);
			}
		}
		foreach (GameObject element in objects) {
			if(element!=null){
				Destroy(element.gameObject);
			}
		}
		if (scroller.gameObject != null) {
			Destroy(scroller.gameObject);
		}
	}
}
