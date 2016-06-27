using UnityEngine;
using System.Collections;

public class StartUI : MonoBehaviour {

	private Object UIelement;
	private bool pc = false;
	public string openApp;

	// Use this for initialization
	void Start () {
		#if UNITY_EDITOR
		pc = true;
		#endif
		/*UIelement = Resources.Load("Assets/Pre-fabs/UI.prefab");
		Debug.Log (UIelement);*/
		GameObject Ui = Resources.Load ("UI") as GameObject;
		if (pc) {
			Instantiate (Resources.Load ("UI"));
		}
		else{
			foreach(GameObject app in Ui.GetComponent<Load_App>().databases){
				if(app!=null){
					if(app.name == openApp){
						Instantiate(app);
						app.GetComponent<Pages>().openPage(0);
					}
				}
			}
		}
	}
}
