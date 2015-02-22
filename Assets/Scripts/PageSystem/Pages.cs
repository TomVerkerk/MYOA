using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Pages : MonoBehaviour {

	public int startPage;
	public List<PageTemplate> PageArray;

	// Use this for initialization
	void Start(){
		openPage (startPage);
	}

	public void openPage (int pageNumber) {
		PageArray [pageNumber].OpenPage ();
	}
	
	// Update is called once per frame
	public void closePage (int pageNumber) {
		PageArray [pageNumber].ClosePage ();
	}

	void Update(){
		if(Input.GetKeyDown(KeyCode.UpArrow)){
			PageArray[13].index++;
		}
		if(Input.GetKeyDown(KeyCode.DownArrow)){
			PageArray[13].index--;
		}
	}
}
