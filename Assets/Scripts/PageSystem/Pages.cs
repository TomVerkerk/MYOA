using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Pages : MonoBehaviour {

	public List<PageTemplate> PageArray;

	// Use this for initialization
	void Start(){
		openPage (0);
	}

	public void openPage (int pageNumber) {
		PageArray [pageNumber].OpenPage ();
	}
	
	// Update is called once per frame
	public void closePage (int pageNumber) {
		PageArray [pageNumber].ClosePage ();
	}
}
