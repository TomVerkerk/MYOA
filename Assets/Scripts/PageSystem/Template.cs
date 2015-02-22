using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(ItemVariables))]
public class Template : MonoBehaviour {

	public List<Vector2> ObjectPositions = new List<Vector2> ();
	public List<Vector2> ObjectScale = new List<Vector2> ();
	public float Rotation;
	public PageTemplate pageIndex;

	/*public void SetObject(int templateIndex){
		this.gameObject.transform.position = new Vector3(ObjectPositions [templateIndex].x,ObjectPositions[templateIndex].y,0);
		this.gameObject.transform.localScale = new Vector3 (ObjectScale [templateIndex].x, ObjectScale [templateIndex].y,1);
		this.gameObject.transform.rotation = Quaternion.Euler (0, Rotation,0);
	}*/

	void Update(){
		if(pageIndex != null){
			this.gameObject.transform.position = new Vector3(ObjectPositions [pageIndex.index].x,ObjectPositions[pageIndex.index].y,0);
			this.gameObject.transform.localScale = new Vector3 (ObjectScale [pageIndex.index].x, ObjectScale [pageIndex.index].y,1);
			this.gameObject.transform.rotation = Quaternion.Euler (0, Rotation,0);
		}
	}
}
