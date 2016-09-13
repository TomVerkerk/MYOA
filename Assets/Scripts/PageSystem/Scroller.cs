using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Scroller : MonoBehaviour {

	public bool on = false;
	public List<GameObject> attached;
	public List<GameObject> menubuttons;
	public float length;
	private Vector2 touchBegin;
	private Vector2 touchEnd = Vector3.zero;
	public float scrollSpeed;
	public float scrollTest;
	private bool pc = false;
	private ItemVariables item;
	private GameObject cameraObj;
	private Vector2 startPos;
	public Vector2 currentPos = Vector2.zero;
	public Vector2 movement = Vector2.zero;
	public Vector2 testScroll;
	private Vector2 testFloat;
	private Vector2 screenVector = Vector2.zero;
	private Vector2 extraMovement = Vector2.zero;
	private bool extra = false;
	public bool moved = false;

	void Start(){
		#if UNITY_EDITOR
			pc = true;
		#endif
		cameraObj = Camera.main.gameObject;
		startPos = new Vector2 (cameraObj.transform.position.x, cameraObj.transform.position.y);
	}

	public void Reset(){
		Camera.main.gameObject.transform.position = new Vector3(startPos.x,startPos.y,-20);
		extraMovement = Vector2.zero;
		extra = false;
		screenVector = Vector2.zero;
		currentPos = Vector2.zero;
		testScroll = Vector2.zero;
		scrollTest = 0;
		scrollSpeed = 4;
		length = 0;
		foreach (GameObject attachedObject in attached) {
			if(attachedObject!=null){
				item = attachedObject.GetComponent<ItemVariables> ();
				if (item.button) {
					item.buttonTop = item.buttonTopStart;
				}
			}
		}
	}

	public void CheckUse(){
		length = 0;
		foreach (GameObject obj in attached) {
			if (obj != null) {
				ItemVariables variables = obj.GetComponent<ItemVariables> ();
				if (variables != null) {
					if (variables.image) {
						if (variables.scale.y > 0) {
							if ((variables.position.y - variables.scale.y/2) < -20) {
								if (-(variables.position.y - variables.scale.y) > length + 20) {
									length = -(variables.position.y - variables.scale.y) - 20;
								}
							}
						} else {
							if (variables.position.y < -20) {
								if (-variables.position.y > length + 20) {
									length = -variables.position.y - 20;
								}
							}
						}
					}
					if (variables.button) {
						if (variables.buttonHeight > 0) {
							if (variables.buttonTopStart + variables.buttonHeight > 1) {
								if ((variables.buttonTopStart + variables.buttonHeight) * 20 > length + 20) {
									length = ((variables.buttonTopStart + variables.buttonHeight) * 20) - 20;
								}
							}
						} else {
							if (variables.buttonTopStart > 1) {
								if (variables.buttonTopStart * 20 > length + 20) {
									length = (variables.buttonTopStart * 20) - 20;
								}
							}
						}
					}
				}
			}
		}
		if (length == 0) {
			Reset ();
			on = false;
		} else {
			Reset();
			on=true;
		}
	}

	void Update () {
		Input.multiTouchEnabled = false;
		if (on) {
			if (!pc) {
				foreach (var T in Input.touches) {
					if (T.phase == TouchPhase.Began) {
						touchBegin = T.position;
						screenVector = Vector2.zero;
						currentPos += extraMovement;
						extraMovement = Vector2.zero;
						extra = false;
						moved = false;
					} else if (T.phase == TouchPhase.Ended) {
						currentPos += touchEnd;
						if (currentPos.y > 0) {
							currentPos.y = 0;
						}
						if (currentPos.y < -length) {
							currentPos.y = -length;
						}
						touchEnd = Vector2.zero;
						extra = true;
					} else if (T.phase == TouchPhase.Moved) {
						if (movement.y <= 0 && touchBegin.y - T.position.y < 0 ||
							movement.y >= -length && touchBegin.y - T.position.y > 0) {
							touchEnd = ((touchBegin - T.position) / 1920) * 20;
							screenVector = (touchEnd - testFloat) * 14;
							testFloat = touchEnd;
							moved = true;
						}
					}
				}
			} else {
				if (Input.GetAxis ("Mouse ScrollWheel") != 0) {
					if (testScroll.y <= 0 && testScroll.y >= -length) {
						testScroll.y += (Input.GetAxis ("Mouse ScrollWheel") * 8);
					}
					if (testScroll.y > 0) {
						testScroll.y = 0;
					}
					if (testScroll.y < -length) {
						testScroll.y = -length;
					}
				}
			}
			if (Input.touchCount == 0 && extra) {
				moved = false;
				extraMovement = Vector2.Lerp (extraMovement, screenVector, 0.12f);
				if (extraMovement == screenVector) {
					currentPos += extraMovement;
					extraMovement = Vector2.zero;
					extra = false;
				}
			}
			if (movement.y <= 0 && movement.y >= -length) {
				movement = currentPos + touchEnd + testScroll + extraMovement;
			} else {
				currentPos += extraMovement;
				extraMovement = Vector2.zero;
				extra = false;
			}
			if (movement.y > 0) {
				cameraObj.transform.position = new Vector3 (startPos.x, startPos.y, -20);
				foreach (GameObject attachedObject in attached) {
					item = attachedObject.GetComponent<ItemVariables> ();
					if (item.button && item.attachedToCam == false) {
						item.buttonTop = item.buttonTopStart;
					}
					else if(item.image && item.attachedToCam){
						attachedObject.transform.position = item.position+new Vector3(0,8.5f,0);
					}
				}
				movement.y = 0;
				screenVector = Vector2.zero;
				currentPos += extraMovement;
				extraMovement = Vector2.zero;
				extra = false;
			} else if (movement.y < -length) {
				cameraObj.transform.position = new Vector3 (startPos.x, startPos.y - length, -20);
				foreach (GameObject attachedObject in attached) {
					item = attachedObject.GetComponent<ItemVariables> ();
					if (item.button && item.attachedToCam == false) {
						item.buttonTop = item.buttonTopStart + (-length * 0.05f);
					}
					else if(item.image && item.attachedToCam){
						attachedObject.transform.position = item.position+new Vector3(0,8.5f-length,0);
					}
				}
				movement.y = -length;
				screenVector = Vector2.zero;
				currentPos += extraMovement;
				extraMovement = Vector2.zero;
				extra = false;
			} else {
				cameraObj.transform.position = new Vector3 (startPos.x, startPos.y + movement.y, -20);
				foreach (GameObject attachedObject in attached) {
					if(attachedObject!=null){
						item = attachedObject.GetComponent<ItemVariables> ();
						if (item.button && item.attachedToCam == false) {
							item.buttonTop = item.buttonTopStart + (movement.y * 0.05f);
						}
						else if(item.image && item.attachedToCam){
							attachedObject.transform.position = item.position+new Vector3(0,8.5f+movement.y,0);
						}
					}
				}
			}
		}
	}
}
