using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MenuBar : MonoBehaviour {

	public GameObject background;
	public GameObject backgroundobj;
	public GameObject[] buttons;
	public List<GameObject> buttonsObj;
	private Vector3 scaleOffset;
	//private Vector3 butOffset;
	private int count = 0;
	private int count1 = 0;
	//public Scroller scroller;
	//dpublic bool created = false;

	void Start(){
		//scroller = GameObject.FindGameObjectWithTag ("Scroller").GetComponent<Scroller> ();
		ItemVariables itemvar = background.GetComponent<ItemVariables> ();
		scaleOffset = new Vector3(5.625f - itemvar.scale.x/2,-10 + itemvar.scale.y/2);
		background.transform.localScale = new Vector3 (itemvar.scale.x, itemvar.scale.y, 1);
		backgroundobj = Instantiate (background,itemvar.position-scaleOffset,background.transform.rotation) as GameObject;
		backgroundobj.transform.localScale = Vector3.zero;
		//backgroundobj.gameObject.renderer.enabled = false;
		//backgroundobj.gameObject.SetActive (false);
		/*foreach (GameObject button in buttons) {
			ItemVariables buttonvar = button.GetComponent<ItemVariables> ();
			buttonsObj[count] = Instantiate(button) as GameObject;
			//buttons[count].GetComponent<ItemVariables>().buttonTopStart = 0.4f;
			//if (scroller != null) {
			//scroller.attached.Add(buttonsObj[count]);
			//scroller.menubuttons.Add(buttonsObj[count]);
			//	buttonsObj[count].gameObject.SetActive(false);
			//}
			count++;
		}*/
		//created = true;
		//count = 0;
	}

	public void OpenClose(bool state){
		//backgroundobj.gameObject.renderer.enabled = state;
		backgroundobj.GetComponent<PopUpMenuBackground> ().PopUpDown (state);
		foreach (GameObject button in buttonsObj) {
			button.gameObject.GetComponent<ItemVariables> ().button = state;
			count1++;
		}
		count1=0;
	}
}
