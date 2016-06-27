using UnityEngine;
using System.Collections;
using System.IO;
using System.Text;
using System.Threading;
using System.Linq;

public class TextFields : MonoBehaviour {

	//public string name;
	public string placeHolder;
	public float x;
	public float y;
	public float width;
	public float height;
	public GUIStyle gui;

	void OnGUI(){
		name = GUI.TextField (new Rect (Screen.width * x, Screen.height * y, Screen.width * width, Screen.height * height), name.Replace("\n",""), 16, gui).Replace(" ","");
		if(name == ""){
			GUI.TextField (new Rect (Screen.width * x, Screen.height * y, Screen.width * width, Screen.height * height), placeHolder, 16, gui);
		}

	}
}
