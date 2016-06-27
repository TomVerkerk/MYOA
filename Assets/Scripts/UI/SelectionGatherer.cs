using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SelectionGatherer : MonoBehaviour {

	public List<ItemVariables> selections = new List<ItemVariables>();
	private bool enabled = false;
	private bool checking = false;
	private Images images;
	private Texture background;

	void Start(){
		images = GetComponent<Images> ();
		foreach (Texture image in images.images) {
			if (image.name == "backgroundRight") {
				background = image;
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
