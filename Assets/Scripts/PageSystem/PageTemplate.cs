using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PageTemplate : MonoBehaviour {

	public List<GameObject> Objects;
	private ElementVariables variables;

	public void OpenPage(){
		foreach (GameObject element in Objects) {
			variables = element.gameObject.GetComponent<ElementVariables>();
			Instantiate(element,variables.position,transform.rotation);
		}
	}
	
	public void ClosePage(){
		foreach (GameObject element in Objects) {
			Destroy(element.gameObject);
		}
	}
}
