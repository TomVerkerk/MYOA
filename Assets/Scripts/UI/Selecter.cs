using UnityEngine;
using System.Collections;

public class Selecter : MonoBehaviour {

	public bool enabled = false;
	public RaycastHit[] hits;
	public bool nothingClicked = true;
	public bool clicked=false;
	private bool shift = false;
	private ItemVariables objVar;


	
	// Update is called once per frame
	void Update () {
		if (enabled) {
			GameObject[] Buttons = GameObject.FindGameObjectsWithTag ("Button");
			if(Buttons != null){
				foreach (GameObject obj in Buttons) {
					if(obj.GetComponent<ItemVariables> ()!=null){
						obj.GetComponent<ItemVariables> ().shift = shift;
					}
				}
			}
		}
	}

	void OnGUI(){
		if (Event.current.shift) {
			shift = true;
		} else {
			shift=false;
		}
		if (Input.GetMouseButtonDown (0) && Input.GetKey (KeyCode.LeftShift)) {
			clicked=false;
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			hits = Physics.RaycastAll(ray,100);
			foreach(RaycastHit hit in hits){
				if(hit.collider.GetComponent<ItemVariables>().image && hit.collider.GetComponent<ItemVariables>().imageTapple == false){
					GetComponent<AppChangeImage>().enabled = false;
					Pages pages=GameObject.FindGameObjectWithTag("Pages").GetComponent<Pages>();
					foreach(GameObject obj in pages.PageArray[GetComponent<Database>().selectedPage].objects){
						if(obj.GetComponent<ItemVariables>().itemName == hit.collider.GetComponent<ItemVariables>().itemName){
							if(!GameObject.FindGameObjectWithTag("UI").GetComponent<App_TemplateEditor>().enabled){
								clicked=true;
								objVar = hit.collider.GetComponent<ItemVariables>();
								GetComponent<AppChangeImage> ().item =obj.GetComponent<ItemVariables>();
								GetComponent<AppChangeImage>().itemObject = obj;
								break;
							}
						}
						/*else if(obj.GetComponent<ItemVariables>().slider){
							if(GetComponent<Slider>().spawnedObject.GetComponent<ItemVariables>().itemName == itemName ||
							   GetComponent<Slider>().oldObject.GetComponent<ItemVariables>().itemName == itemName ||
							   GetComponent<Slider>().oldestObject.GetComponent<ItemVariables>().itemName == itemName){
							}
						}*/
					}
					foreach(GameObject obj in pages.PageArray[GetComponent<Database>().selectedPage].templateObjects){
						if(obj.GetComponent<ItemVariables>().itemName == hit.collider.GetComponent<ItemVariables>().itemName){
							if(GameObject.FindGameObjectWithTag("UI").GetComponent<App_TemplateEditor>().enabled){
								clicked=true;
								objVar = hit.collider.GetComponent<ItemVariables>();
								GetComponent<AppChangeImage> ().item =obj.GetComponent<ItemVariables>();
								GetComponent<AppChangeImage>().itemObject = obj;
								break;
							}
						}
						/*else if(obj.GetComponent<ItemVariables>().slider){
							if(GetComponent<Slider>().spawnedObject.GetComponent<ItemVariables>().itemName == itemName ||
							   GetComponent<Slider>().oldObject.GetComponent<ItemVariables>().itemName == itemName ||
							   GetComponent<Slider>().oldestObject.GetComponent<ItemVariables>().itemName == itemName){
							}
						}*/
					}
				}
			}
		}
	}

	public void Check(){	
		if(nothingClicked){
			SetImage();
			nothingClicked = false;
		}
	}

	public void SetImage(){
		if (clicked) {
			GetComponent<App_NewPage>().enabled = false;
			GetComponent<App_Button>().enabled=false;
			GetComponent<App_Image>().enabled=false;
			if (!objVar.selected) {
				GameObject[] Buttons = GameObject.FindGameObjectsWithTag("Button");
				foreach(GameObject obj in Buttons){
					obj.GetComponent<ItemVariables>().selected = false;
				}
				objVar.selected = true;
				GetComponent<AppChangeImage> ().pageOpened = true;
				GetComponent<AppChangeImage> ().Reset ();
				GetComponent<AppChangeImage> ().enabled = true;
				GetComponent<AppChangeButton> ().enabled = false;
			} else {
				objVar.selected = false;
				GetComponent<AppChangeImage> ().enabled = false;
				GetComponent<AppChangeButton> ().enabled = false;

			}
		}
	}
}
