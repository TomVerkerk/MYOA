using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Pages : MonoBehaviour {

	public int startPage;
	public bool template = true;
	public Texture templateImage;
	public Texture explainImage;
	public List<GameObject> templateObjects;
	public List<PageTemplate> PageArray;

	public void openPage (int pageNumber) {
		PageArray [pageNumber].templateObjects = templateObjects;
		PageArray [pageNumber].OpenPage ();
	}

	public void closePage (int pageNumber) {
		PageArray [pageNumber].ClosePage ();
	}
}
