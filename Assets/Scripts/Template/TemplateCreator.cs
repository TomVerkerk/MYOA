using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TemplateCreator : MonoBehaviour {

	public enum Choise {
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
	public Choise Templates; 
	private int index;
	public List<GameObject> Objects = new List<GameObject>();

	private float indexer;
//	private bool touch = false;


	// Use this for initialization
	void Update () {
		switch (Templates) {
		case Choise.Template1:
			index = 0;
			break;
		case Choise.Template2:
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
		/*if (Input.touchCount > 0 && touch == false) {
			index++;
			index = index % 10;
			setTemplate ();
			touch = true;
		}
		if(Input.touchCount == 0){
			touch = false;
		}*/
		setTemplate ();
	}

	void setTemplate(){
		foreach(GameObject Object in Objects){
			Object.GetComponent<Template>().SetObject(index);
		}
	}
}
