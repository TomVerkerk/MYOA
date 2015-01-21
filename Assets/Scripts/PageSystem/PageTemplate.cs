using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PageTemplate : MonoBehaviour {

	public bool template;
	public List<GameObject> objects;
	private ItemVariables variables;

	public void OpenPage(){
		foreach (GameObject element in objects) {
			variables = element.gameObject.GetComponent<ItemVariables>();
			element.transform.localScale = new Vector3(variables.scale.x,variables.scale.y,1);
			Instantiate(element,variables.position,transform.rotation);
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
