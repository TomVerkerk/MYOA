﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PageTemplate : MonoBehaviour {

	public bool template;
/*	private enum Choise {
		Template1,
		Template2,
		Template3,
		Template4,
		Template5,
		Template6,
		Template7,
		Template8,
		Template9,
		Template10
	};
	public Choise Templates; */
	public int index;
	//public List<GameObject> templateObjects;
	public List<GameObject> objects;
	private ItemVariables variables;
	private Template templateItem;

	/*void Start(){
		switch (Templates) {
		case Choise.Template1:
			Debug.Log("P");
			index = 0;
			break;
		case Choise.Template2:
			Debug.Log("P");
			index = 1;
			break;
		case Choise.Template3:
			index = 2;
			break;
		case Choise.Template4:
			index = 3;
			break;
		case Choise.Template5:
			index = 4;
			break;
		case Choise.Template6:
			index = 5;
			break;
		case Choise.Template7:
			index = 6;
			break;
		case Choise.Template8:
			index = 7;
			break;
		case Choise.Template9:
			index = 8;
			break;
		case Choise.Template10:
			index = 9;
			break;
		}
	}*/

	public void OpenPage(){
		if(template){
			foreach(GameObject element in objects){
				templateItem = element.GetComponent<Template>();
				if(templateItem != null){
					GameObject Gobject = Instantiate(element,templateItem.ObjectPositions[index],transform.rotation) as GameObject;
					//Gobject.gameObject.GetComponent<Template>().SetObject(index);
					Gobject.gameObject.GetComponent<Template>().pageIndex = this;
				}
				else{
					Debug.Log("Can't find templatescript in " + element);
				}
			}
		}
		else{
			foreach (GameObject element in objects) {
				variables = element.gameObject.GetComponent<ItemVariables>();
				element.transform.localScale = new Vector3(variables.scale.x,variables.scale.y,1);
				Instantiate(element,variables.position,transform.rotation);
			}
		}
	}

	public void ClosePage(){
		foreach (GameObject element in objects) {
			if(element!=null){
				Destroy(element.gameObject);
			}
		}
	}
}
