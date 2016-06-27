using UnityEngine;
using System.Collections;

public class UIElement : MonoBehaviour {

	public Vector2 pos;
	public bool background;
	public Texture uiBackgroundImage;

	void OnGUI(){
		if (!background) {
			GUI.TextArea (new Rect (pos.x, pos.y, 200, 100), "pos =" + pos);
		}
		else{
			GUI.DrawTexture (new Rect (0, 0, Screen.width * 0.3418f, Screen.height), uiBackgroundImage);
			GUI.DrawTexture (new Rect (Screen.width * 0.6582f, 0, Screen.width * 0.3418f, Screen.height), uiBackgroundImage);
		}
	}
}
