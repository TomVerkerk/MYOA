using UnityEngine;
using System.Collections;

public class Background : MonoBehaviour {

	public Texture uiBackgroundImageLeft;
	public Texture uiBackgroundImageRight;
	public GUITexture texture;
	public bool drawn = false;

	void Start ()
	{
	//	uiBackgroundImageLeft.
	//	texture.guiTexture.pixelInset = new Rect (0, 0, (Screen.width - (Screen.height * 0.5625f)) / 2, Screen.height);
	}

	void OnGUI(){

		/*if (!drawn) {
			GUI.DrawTexture (new Rect (0, 0, (Screen.width - (Screen.height * 0.5625f)) / 2, Screen.height), uiBackgroundImageLeft);

			GUI.DrawTexture (new Rect (((Screen.width - (Screen.height * 0.5625f)) / 2) + (Screen.height * 0.5625f), 0, (Screen.width - (Screen.height * 0.5625f)) / 2, Screen.height), uiBackgroundImageRight);
			//drawn = true;
		}*/
	}
}
