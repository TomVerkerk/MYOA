using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Template : MonoBehaviour {

	public List<Vector2> ObjectPositions = new List<Vector2> ();
	public List<Vector2> ObjectScale = new List<Vector2> ();
	public float Rotation;

	public void SetObject(int templateIndex){
		transform.position = new Vector3(ObjectPositions [templateIndex].x,0,ObjectPositions[templateIndex].y);
		transform.localScale = new Vector3 (ObjectScale [templateIndex].x, 1, ObjectScale [templateIndex].y);
		transform.rotation = Quaternion.Euler (0, Rotation,0);
	}
}
