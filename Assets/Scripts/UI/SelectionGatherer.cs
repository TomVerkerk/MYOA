using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SelectionGatherer : MonoBehaviour {

	public List<ItemVariables> selections = new List<ItemVariables>();
	private bool enabled = false;
	private bool checking = false;
	private Images images;
	private Texture background;
	private int index = 0;
	private Texture buttonBackground;
	private GUIStyle style;

	void Start(){
		style = new GUIStyle ();
		images = GetComponent<Images> ();
		style.fontSize = (55*Screen.width)/1920;
		foreach (Texture image in images.images) {
			if (image.name == "backgroundRight") {
				background = image;
			}
			if(image.name == "buttonBackground 1"){
				buttonBackground = image;
			}
		}
	}

	public void clearSelection(){
		foreach (ItemVariables obj in selections) {
			obj.gathered = false;
		}
		selections.Clear ();
	}

	public void addToSelection(ItemVariables obj){
		if (!obj.gathered) {
			selections.Add (obj);
			obj.gathered = true;
		}
	}

	public void checkSelection(){
		if (!enabled) {
			if (selections.Count == 1) {
				selections [0].setSelection ();
			} else if (selections.Count > 1) {
				enabled = true;
				GetComponent<AppChangeImage> ().enabled = false;
				GetComponent<AppChangeButton> ().enabled = false;
				GetComponent<ObjectLibrary> ().enabled = false;
			}
		}
	}

	void OnGUI(){
		if (enabled) {
			GUI.DrawTexture(new Rect(Screen.width* 0.6582f, 0, Screen.width * 0.3418f, Screen.height), background);
			GUI.TextArea(new Rect (Screen.width * 0.723f, Screen.height * 0.03f, Screen.width * 0.23f, Screen.height * 0.05f), "Choose Object", style);
			foreach(ItemVariables item in selections){
				if(item!=null){
					if (GUI.Button (new Rect (Screen.width * 0.723f, Screen.height * (0.16f + (0.07f * (index))), Screen.width * 0.23f, Screen.height * 0.05f), buttonBackground, style)) {
						item.setSelection();
						clearSelection();
						enabled=false;
						index=0;
						break;
					}
					GUI.TextArea(new Rect (Screen.width * (0.823f - (item.itemName.Length * 0.0052f)), Screen.height * (0.16f + (0.07f * (index))), Screen.width * 0.23f, Screen.height * 0.05f), item.itemName, style);
					index++;
				}
			}
			index=0;
		}
		if(Event.current.shift&&Input.GetMouseButtonDown(0) && !checking){
			checking = true;
			StartCoroutine(Check());
		}
	}

	IEnumerator Check()
	{
		yield return new WaitForSeconds(0.1f);
			checkSelection ();
			checking = false;
	}
}
