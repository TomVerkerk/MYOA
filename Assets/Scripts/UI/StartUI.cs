using UnityEngine;
using System.Collections;

public class StartUI : MonoBehaviour {

	private Object UIelement;
	public string openApp;
	
	void Start () {
		#if UNITY_EDITOR
		GameObject Ui = Resources.Load ("UI") as GameObject;
		Instantiate (Resources.Load ("UI"));
#else
		foreach(GameObject app in Ui.GetComponent<Load_App>().databases){
			if(app!=null){
				if(app.name == openApp){
					Instantiate(app);
					app.GetComponent<Pages>().openPage(0);
				}
			}
		}
		#endif
	}
}
