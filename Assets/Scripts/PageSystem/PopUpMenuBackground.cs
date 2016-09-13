using UnityEngine;
using System.Collections;

public class PopUpMenuBackground : MonoBehaviour {

	private Vector3 scale = Vector3.zero;
	private Texture image;
	private ItemVariables itemVar;
	private Vector3 openScale;
	private Vector3 closedScale;
	private Vector3 scaleOffset;
	public bool scaling = false;
	public float scaleSpeed;
	public bool open = false;

	void Start(){
		itemVar = GetComponent<ItemVariables> ();
		image = itemVar.imageMaterial;
		closedScale = new Vector3 (itemVar.scale.x, 0, 1);
		openScale = new Vector3 (itemVar.scale.x, itemVar.scale.y, 1);
		transform.localScale = closedScale;
	}

	public void PopUpDown(bool upDown){
		scaling = true;
		open = upDown;
	}

	void Update(){
		if (scaling) {
			if(open){
				scale = Vector3.Lerp(transform.localScale,openScale,scaleSpeed*Time.deltaTime);
				if(transform.localScale == openScale){
					scaling = false;
				}
			}
			else{
				scale = Vector3.Lerp(transform.localScale,closedScale,scaleSpeed*Time.deltaTime);
				if(transform.localScale == closedScale){
					scaling = false;
				}
			}
			transform.localScale = scale;
			scaleOffset = new Vector3(5.625f - scale.x/2,-10 + scale.y/2);
			transform.position = new Vector3(itemVar.position.x-scaleOffset.x,itemVar.position.y-scaleOffset.y,-1);
			//transform.localScale = scale;
		}
	}
}
