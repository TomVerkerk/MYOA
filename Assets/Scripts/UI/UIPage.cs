using UnityEngine;
using System.Collections;

public class UIPage : MonoBehaviour {

	public UIElement[] elements;

	public void Open(bool left){
		foreach (UIElement element in elements) {
			Instantiate(element);
		}
	}
}
