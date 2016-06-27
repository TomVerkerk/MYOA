using UnityEngine;
using System.Collections;

public class ButtonLibrary : MonoBehaviour {

	public bool enabled = false;
	//public GameObject[] templateButtons;
	private int index = 0;
	private Vector2 offset = new Vector2(0.15f,0.15f);
	private Vector2 scale = new Vector2(0.05f,0.05f);
	private Texture background;
	private Texture white;
	public Texture[] icons;
	private GUIStyle style;
	private Images images;

	void Start(){
		style = new GUIStyle ();
		foreach (Texture image in GetComponent<Images>().images) {
			if(image.name == "ButtonLibraryBackground"){
				background = image;
			}
			if(image.name == "White"){
				white = image;
			}
		}
	}

	void OnGUI(){
		if (enabled) {
			GUI.DrawTexture (new Rect (0, 0, Screen.width * 0.3418f, Screen.height), white);
			GUI.DrawTexture (new Rect (0, 0, Screen.width * 0.3418f, Screen.height), background);
			foreach (Texture button in icons) {
				/*GUI.DrawTexture (new Rect (Screen.width * (0.05f + ((index % 3) * offset.x)), Screen.height + (0.2f + (Mathf.Floor (index / 3) * offset.y)), Screen.width * scale.x, Screen.width * scale.y), icons [index]);
				if (Input.GetMouseButtonDown(0)&&
					Input.mousePosition.x > Screen.width * (0.05f + ((index % 3) * offset.x)) &&
					Input.mousePosition.x < Screen.width * (0.05f + (((index % 3) * offset.x) + scale.x)) &&
					Input.mousePosition.y > Screen.height * (0.2f + (Mathf.Floor (index / 3) * offset.y)) &&
					Input.mousePosition.y < Screen.height * (0.2f + (Mathf.Floor (index / 3) * offset.y) + scale.y)) {
					Debug.Log ("" + index);
				}
				index++;
			}*/
				if(GUI.Button(new Rect(Screen.width*(0.05f + ((index % 3) * offset.x)),Screen.height*(0.2f + (Mathf.Floor (index / 3) * offset.y)),Screen.width*scale.x,Screen.width*scale.y),icons[index],style)){
					Debug.Log(""+index);
				}
				index++;
			}
			index = 0;
		}
	}
}
